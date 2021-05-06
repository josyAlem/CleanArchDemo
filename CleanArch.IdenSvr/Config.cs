﻿using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.IdenSvr
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetAllApiResources() {
            return new List<ApiResource> { 
            new ApiResource("cleanArchApi","University Courses")
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
