using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;

namespace ProiectDaw.Models.Entities
{
    public class User : IdentityUser<int>
    {
        public User() : base() { }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }

    }
}
