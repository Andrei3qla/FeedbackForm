using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FeedbackForm.Data;
using FeedbackForm.Models;

namespace FeedbackForm.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserDatasController : ControllerBase
    {
        private readonly FeedbackFormContext _context;
        public UserDatasController(FeedbackFormContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<ActionResult<UserData>> PostUserData(UserData userData)
        {
            var founded = _context.Users.FirstOrDefault(t => t.Email == userData.Email &&
                 t.Phone == userData.Phone);

            var userId = 0;
            if (founded is null)
            {
                var addedUser = new User()
                {
                    Name = userData.Name,
                    Email = userData.Email,
                    Phone = userData.Phone
                };
                _context.Users.Add(addedUser);
                await _context.SaveChangesAsync();
                userId = addedUser.UserId;
            }
            else
                userId = founded.UserId;

            var subject = _context.Subjects.FirstOrDefault(t => t.SubjectName == userData.Subject);

            if (subject is null)
            {
                subject = new Subject() { SubjectName = userData.Subject };
                _context.Subjects.Add(subject);
                await _context.SaveChangesAsync();
            }

            var message = new Message()
            {
                UserId = userId,
                SubjectId = subject.SubjectId,
                MessageText = userData.Message
            };
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            Console.WriteLine();


            return CreatedAtAction(nameof(PostUserData), new { id = userData.UserDataId }, message);
        }
    }
}
