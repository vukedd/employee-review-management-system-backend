using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Auth
{
    public class RefreshToken
    {
        public long Id { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Token { get; set; }
        public bool IsRevoked { get; set; }
        public Domain.Models.Users.User User { get; set; }
        public long UserId { get; set; }
    }
}
