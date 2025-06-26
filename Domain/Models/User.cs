using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        public long Id { get; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; }
        public User(string username, string password, string email, string firstName, string lastName, Role role)
        {
            this.Username = username;
            this.Password = password;   
            this.Email = email;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Role = role;
        }
    }
}