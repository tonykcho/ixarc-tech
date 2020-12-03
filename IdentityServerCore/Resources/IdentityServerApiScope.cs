using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServerCore.Resources
{
    public class IdentityServerApiScope
    {
        public static readonly IList<ApiScope> DefaultServerApiScopes = new List<ApiScope>()
        {
            new ApiScope(){ Name = "api1" }
        };
    }
}
