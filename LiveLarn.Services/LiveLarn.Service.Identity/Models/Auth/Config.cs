using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using LiveLarn.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveLarn.Service.Identity.Models.Auth
{
    public class Config
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public Config(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
            };
        }


        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource(AppConfiguration.Instance.Configuration.GetValue<string>("Auth0:ApiResource"), "LiveLarn.Service.User"),
                new ApiResource(AppConfiguration.Instance.Configuration.GetValue<string>("Auth0:ApiResource"), "LiveLarn.Service.Company")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "LiveLarn.Service.User.Client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    ClientSecrets =
                    {
                        new Secret("LiveLarn.Service.User.Secret".Sha256())
                    },
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Address,
                        AppConfiguration.Instance.Configuration.GetValue<string>("Auth0:ApiResource")
                    }
                },
                 new Client
                {
                    ClientId = "LiveLarn.Service.Company.Client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    ClientSecrets =
                    {
                        new Secret("LiveLarn.Service.Company.Secret".Sha256())
                    },
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Address,
                        AppConfiguration.Instance.Configuration.GetValue<string>("Auth0:ApiResource")
                    }
                }
            };
        }
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "LiveLarn",
                    Password = "password"
                }

            };
        }
    }
}