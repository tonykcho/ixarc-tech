using System;
namespace Domain.Models.Identities
{
    public class AppUser : BaseEntity
    {
        public string Name { get; set; }

        public string PasswordHash { get; set; }
        public AppUser() { }
    }
}
