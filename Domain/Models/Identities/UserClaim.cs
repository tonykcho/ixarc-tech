using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Identities
{
    public class UserClaim : BaseEntity
    {
        public string ClaimValue { get; set; }

        public string ClaimType { get; set; }

        public int UserId { get; set; }

        public Claim toClaim()
        {
            return new Claim(ClaimType, ClaimValue);
        }
    }
}
