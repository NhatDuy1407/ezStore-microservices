﻿using IdentityServer4;
using IdentityServer4.Models;
using Ws4vn.Microservices.ApplicationCore.SharedKernel;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Microservices.IdentityServer
{
    public static class Config
    {
        // scopes define the resources in your system
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource(MicroservicesConstants.IdentityServerAPIName, "My API")
            };
        }

        // clients want to access resources (aka scopes)
        public static IEnumerable<Client> GetClients(IConfiguration configuration)
        {
            // client credentials client
            return new List<Client>
            {
                new Client
                {
                    ClientId = "clientApp",

                    //// no interactive user, use the clientid/secret for authentication
                    //AllowedGrantTypes = GrantTypes.ClientCredentials,

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret(MicroservicesConstants.IdentityServerSecret.Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        MicroservicesConstants.IdentityServerAPIName
                    }
                },

                // OpenID Connect implicit flow client (MVC)
                new Client
                {
                    ClientId = "mvc",
                    ClientName = "MVC Client",
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,

                    RequireConsent = true,

                    ClientSecrets =
                    {
                        new Secret(MicroservicesConstants.IdentityServerSecret.Sha256())
                    },

                    RedirectUris = { $"{configuration["ClientAddress"]}/signin-oidc" },
                    PostLogoutRedirectUris = { $"{configuration["ClientAddress"]}/signout-callback-oidc" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        MicroservicesConstants.IdentityServerAPIName
                    },
                    AllowOfflineAccess = true
                },

                // OpenID Connect implicit flow client (Angular)
                new Client
                {
                    ClientId = "ng",
                    ClientName = "Angular Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = true,

                    RedirectUris = { $"{configuration["ClientAddress"]}/callback" },
                    PostLogoutRedirectUris = { $"{configuration["ClientAddress"]}/home" },
                    AllowedCorsOrigins = { configuration["ClientAddress"] },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        MicroservicesConstants.IdentityServerAPIName
                    },

                }

            };
        }
    }
}