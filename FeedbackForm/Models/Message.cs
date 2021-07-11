using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackForm.Models
{
    public class Message
    {
        public Message(int userId, int subjectId, string message)
        {
            UserId = userId;
            SubjectId = subjectId;
            Text = message;
        }

        public Message()
        {
        }

        public int MessageId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }              
        public string Text { get; set; }
    }
}
