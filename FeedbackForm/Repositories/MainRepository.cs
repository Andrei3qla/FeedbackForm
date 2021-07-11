using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FeedbackForm.Data;
using FeedbackForm.Models;
using Microsoft.EntityFrameworkCore;

namespace FeedbackForm.Repositories
{
    public class MainRepository
    {
        private readonly FeedbackContext context;

        public MainRepository(FeedbackContext context)
        {
            this.context = context;
        }

        public Task<User> FindUserAsync(string email, string phone)
        {
            var user = context.Users.FirstOrDefaultAsync(t => t.Email == email && t.Phone == phone);
            return user;
        }

        public async Task AddUserAsync(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }

        public async Task<Subject> AddOrGetSubjectByNameAsync(string name)
        {
            var subject = await context.Subjects
                .FirstOrDefaultAsync(s => s.SubjectName.ToLower() == name.ToLower());
            if (subject == null)
            {
                subject = new Subject(name);
                await context.Subjects.AddAsync(subject);
                await context.SaveChangesAsync();
            }

            return subject;
        }

        public async Task AddMessageAsync(Message message)
        {
            await context.AddAsync(message);
            await context.SaveChangesAsync();
        }

        public Task<List<Subject>> GetSubjects()
        {
            var subjects = context.Subjects.ToListAsync();
            return subjects;
        }

        public async Task<Subject> GetSubjectByIdAsync(int subjectId)
        {
            var subject = await context.Subjects.FirstOrDefaultAsync(s => s.SubjectId == subjectId);
            return subject;

        }
    }
}