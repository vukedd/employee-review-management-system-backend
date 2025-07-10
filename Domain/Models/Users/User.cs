using Domain.Enums.User;
using Domain.Models.Auth;
using Domain.Models.Memberships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Users
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
        public IEnumerable<RefreshToken> RefreshTokens { get; set; }
        public IEnumerable<Membership> Memberships { get; set; } = new List<Membership>();
        public string VerificationToken { get; set; }
        public bool Verified { get; set; }

        public User(string username, string password, string email, string firstName, string lastName, Role role)
        {
            Username = username;
            Password = password;   
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Role = role;
            Verified = false;
        }
    }
}