using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServerCore.Resources
{
    public class IdentityServerApiResource
    {
        public static readonly IList<ApiResource> DefaultApiResources = new List<ApiResource>()
        {
            new ApiResource()
            {
                Name = "test",
                DisplayName = "Test Api",
                Scopes = { "test.read", "test.write", "api1" },
            }
        };
    }
}
