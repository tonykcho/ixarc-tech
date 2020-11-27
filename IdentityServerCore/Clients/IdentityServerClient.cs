using System;
using System.Collections.Generic;
using IdentityServer4.Models;

namespace IdentityServerCore.Clients
{
    public class IdentityServerClient
    {
        public static readonly IList<Client> DefaultClients = new List<Client>
        {
            new Client()
            {
                ClientId = "api_client",
                ClientSecrets = { new Secret("secret".Sha256())},

                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = { "api1" }
            },

            new Client()
            {
                ClientId = "real_user_client",
                ClientSecrets = { new Secret("secret".Sha256())},
                AllowedGrantTypes = GrantTypes.Code,
                AllowedScopes = { "api1" }
            }
        };
    }
}
