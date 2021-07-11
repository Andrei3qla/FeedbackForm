using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackForm.Models
{
    public class Subject
    {
        public Subject(string name)
        {
            SubjectName = name;
        }

        public Subject()
        {
        }

        public Subject(int id, string name)
        {
            SubjectId = id;
            SubjectName = name;
        }

        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
    }
}
