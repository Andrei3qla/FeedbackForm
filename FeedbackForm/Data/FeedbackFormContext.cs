using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FeedbackForm.Models;

namespace FeedbackForm.Data
{
    public class FeedbackFormContext : DbContext
    {
        public FeedbackFormContext (DbContextOptions<FeedbackFormContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}
