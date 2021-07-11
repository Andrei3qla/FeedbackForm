using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackForm.Models
{
    public class User
    {
        public User(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }

        public User()
        {
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
