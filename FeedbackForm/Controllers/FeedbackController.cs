using System.Collections.Generic;
using System.Threading.Tasks;
using FeedbackForm.Models;
using FeedbackForm.Repositories;
using FeedbackForm.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackForm.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly MainRepository MainRepository;

        public FeedbackController(MainRepository mainRepository)
        {
            MainRepository = mainRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddMessage(FeedbackRequest feedback)
        {
            var user = await MainRepository.FindUserAsync(feedback.Email, feedback.Phone);
            if (user == null)
            {
                user = new User(feedback.Name, feedback.Email, feedback.Phone);
                await MainRepository.AddUserAsync(user);
            }

            var subject = await MainRepository.GetSubjectByIdAsync(feedback.SubjectId);
            var message = new Message(user.UserId, subject.SubjectId, feedback.Message);
            await MainRepository.AddMessageAsync(message);
            var response = new FeedbackResponse(
                message.UserId, message.MessageId, message.User.Phone, message.User.Email, message.Subject.SubjectName, message.Text);
            return CreatedAtAction(nameof(AddMessage), response);
        }

        [HttpGet("subjects")]
        public async Task<IActionResult> GetSubjects()
        {
            var subjects = await MainRepository.GetSubjects();
            return this.Ok(subjects);
        }
    }
}