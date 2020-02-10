using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackForm.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public int UserId { get; set; }
        public int SubjectId { get; set; }
        public string MessageText { get; set; }
    }
}
