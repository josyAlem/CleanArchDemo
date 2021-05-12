using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.IdenSvr
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetAllApiResources() {
            var sampleAPI = new ApiResource()
            {
                Name = "cleanArchApi",   //This is the name of the API
                Enabled = true,
                DisplayName = "University Courses",
            };
            return new List<ApiResource> {
            sampleAPI
            };
        }

        public static IEnumerable<Client> GetClients() {
            return new List<Client> { new Client {
                ClientId="client",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("secret".Sha256()) },
                AllowedScopes={ "cleanArchApi" }
        } };
        }
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                new ApiScope("cleanArchApi")
            };
        }

        public static List<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
               new IdentityResources.OpenId(),
               new IdentityResources.Profile(),
               new IdentityResource("roles", "Your role(s)", new []{"role"}),
            };
        }
    }
}
