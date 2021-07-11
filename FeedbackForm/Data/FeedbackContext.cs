using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FeedbackForm.Models;

namespace FeedbackForm.Data
{
    public class FeedbackContext : DbContext
    {
        public FeedbackContext (DbContextOptions<FeedbackContext> options)
            : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subject>().HasData(new []
            {
                new Subject(1, "Техподдержка"),
                new Subject(2, "Продажи"),
                new Subject(3, "Другое"),
            });
        }
    }
    
    
}
