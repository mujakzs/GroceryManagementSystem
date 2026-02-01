using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrocerySys.Domain.Entities
{
    public class User
    {
        public Guid UserId { get; private set; }

        public string Username { get; private set; }

        public string PasswordHash { get; private set; }

        public string Role { get; private set; }

        public bool IsActive { get; private set; }

        public DateTime CreatedAt { get; private set; }

        private User() { } // EF Core requires a parameterless constructor

        public User(string username, string passwordHash, string role)
        {
            UserId = Guid.NewGuid();
            Username = username;
            PasswordHash = passwordHash;
            Role = role;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
        }

        public void Deactivate()
        {
            IsActive = false;
        }
    }

}
