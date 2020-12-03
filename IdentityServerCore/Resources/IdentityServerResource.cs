using System;
using System.Collections.Generic;
using IdentityServer4.Models;

namespace IdentityServerCore.Resources
{
    public class IdentityServerResource
    {
        public static readonly IList<IdentityResource> DefaultResources = new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
            //new IdentityResource()
            //{
            //    Name = "profile",
            //    UserClaims = new[] {"name"},
            //    DisplayName = "Profile Data",
            //}
        };
    }
}
