﻿using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace AuthorizationServer
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("resourceApi", "API Application")
            };
        }

        // scopes define the resources in your system
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        private static string spaClientUrl = "http://localhost:4200";
        private static string swaggerClientUrl = "https://localhost:44340";

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "spaCodeClient",
                    ClientName = "SPA Code Client",
                    AccessTokenType = AccessTokenType.Jwt,
                    // RequireConsent = false,
                    AccessTokenLifetime = 330,// 330 seconds, default 60 minutes
                    IdentityTokenLifetime = 30,

                    RequireClientSecret = false,
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,

                    AllowAccessTokensViaBrowser = true,
                    RedirectUris = new List<string>
                    {
                        $"{spaClientUrl}/callback",
                        $"{spaClientUrl}/silent-renew.html",
                        "http://localhost:4200",
                        "http://localhost:4200/silent-renew.html"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        $"{spaClientUrl}/unauthorized",
                        $"{spaClientUrl}",
                        "http://localhost:4200/unauthorized",
                        "http://localhost:4200"
                    },
                    AllowedCorsOrigins = new List<string>
                    {
                        $"{spaClientUrl}",
                        "http://localhost:4200"
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "resourceApi"
                    }
                },
                // machine to machine client
                new Client
                {
                    ClientId = "swagger",
                    ClientName = "Swagger API Documentation",
                    //ClientSecrets = { new Secret("swagger".Sha256()) },

                    //AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris = new List<string>
                    {
                        $"{swaggerClientUrl}/oauth2-redirect.html",
                    },
                    //RequireClientSecret = false,
                    // scopes that client has access to
                    AllowedScopes = new List<string>
                    {
                        "resourceApi"
                    },
                    
                },/*
                //// interactive ASP.NET Core MVC client
                //new Client
                //{
                //    ClientId = "mvc",
                //    ClientSecrets = { new Secret("secret".Sha256()) },

                //    AllowedGrantTypes = GrantTypes.Code,
                //    RequireConsent = false,
                //    RequirePkce = true,
                
                //    // where to redirect to after login
                //    RedirectUris = { "http://localhost:5002/signin-oidc" },

                //    // where to redirect to after logout
                //    PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },

                //    AllowedScopes = new List<string>
                //    {
                //        IdentityServerConstants.StandardScopes.OpenId,
                //        IdentityServerConstants.StandardScopes.Profile,
                //        "api1"
                //    },

                //    AllowOfflineAccess = true
                //},
                //new Client
                //{
                //    ClientId = "clientApp",

                //    // no interactive user, use the clientid/secret for authentication
                //    AllowedGrantTypes = GrantTypes.ClientCredentials,

                //    // secret for authentication
                //    ClientSecrets =
                //    {
                //        new Secret("secret".Sha256())
                //    },

                //    // scopes that client has access to
                //    AllowedScopes = { "resourceApi" }
                //},

                // OpenID Connect implicit flow client (MVC)
                //new Client
                //{
                //    ClientId = "mvc",
                //    ClientName = "MVC Client",
                //    AllowedGrantTypes = GrantTypes.Hybrid,

                //    ClientSecrets =
                //    {
                //        new Secret("secret".Sha256())
                //    },

                //    RedirectUris = { $"{spaClientUrl}/signin-oidc" },
                //    PostLogoutRedirectUris = { $"{spaClientUrl}/signout-callback-oidc" },
                //    AllowedScopes =
                //    {
                //        IdentityServerConstants.StandardScopes.OpenId,
                //        IdentityServerConstants.StandardScopes.Profile,
                //        "resourceApi"
                //    },
                //    AllowOfflineAccess = true
                //},
                //new Client
                //{
                //    ClientId = "spaClient",
                //    ClientName = "SPA Client",
                //    AllowedGrantTypes = GrantTypes.Implicit,
                //    AllowAccessTokensViaBrowser = true,

                //    RedirectUris = { $"{spaClientUrl}/callback" },
                //    PostLogoutRedirectUris = { $"{spaClientUrl}/" },
                //    AllowedCorsOrigins = { $"{spaClientUrl}" },
                //    AllowedScopes =
                //    {
                //        IdentityServerConstants.StandardScopes.OpenId,
                //        IdentityServerConstants.StandardScopes.Profile,
                //        "resourceApi"
                //    }
                //}*/
                //new Client
                //{
                //    ClientId = "clientApp",

                //    // no interactive user, use the clientid/secret for authentication
                //    AllowedGrantTypes = GrantTypes.ClientCredentials,

                //    // secret for authentication
                //    ClientSecrets =
                //    {
                //        new Secret("secret".Sha256())
                //    },

                //    // scopes that client has access to
                //    AllowedScopes = { "resourceApi" }
                //},

                //// OpenID Connect implicit flow client (MVC)
                //new Client
                //{
                //    ClientId = "mvc",
                //    ClientName = "MVC Client",
                //    AllowedGrantTypes = GrantTypes.Hybrid,

                //    ClientSecrets =
                //    {
                //        new Secret("secret".Sha256())
                //    },

                //    RedirectUris = { $"{spaClientUrl}/signin-oidc" },
                //    PostLogoutRedirectUris = { $"{spaClientUrl}/signout-callback-oidc" },
                //    AllowedScopes =
                //    {
                //        IdentityServerConstants.StandardScopes.OpenId,
                //        IdentityServerConstants.StandardScopes.Profile,
                //        "resourceApi"
                //    },
                //    AllowOfflineAccess = true
                //},
                //new Client
                //{
                //    ClientId = "spaClient",
                //    ClientName = "SPA Client",
                //    AllowedGrantTypes = GrantTypes.Implicit,
                //    AllowAccessTokensViaBrowser = true,

                //    RedirectUris = { $"{spaClientUrl}/callback" },
                //    PostLogoutRedirectUris = { $"{spaClientUrl}/" },
                //    AllowedCorsOrigins = { $"{spaClientUrl}" },
                //    AllowedScopes =
                //    {
                //        IdentityServerConstants.StandardScopes.OpenId,
                //        IdentityServerConstants.StandardScopes.Profile,
                //        "resourceApi"
                //    }
                //},
                //new Client
                //{
                //    ClientId = "spaCodeClient",
                //    ClientName = "SPA Code Client",
                //    AccessTokenType = AccessTokenType.Jwt,
                //    // RequireConsent = false,
                //    AccessTokenLifetime = 330,// 330 seconds, default 60 minutes
                //    IdentityTokenLifetime = 30,

                //    RequireClientSecret = false,
                //    AllowedGrantTypes = GrantTypes.Code,
                //    RequirePkce = true,

                //    AllowAccessTokensViaBrowser = true,
                //    RedirectUris = new List<string>
                //    {
                //        $"{spaClientUrl}/callback",
                //        $"{spaClientUrl}/silent-renew.html",
                //        "http://localhost:4200",
                //        "http://localhost:4200/silent-renew.html"
                //    },
                //    PostLogoutRedirectUris = new List<string>
                //    {
                //        $"{spaClientUrl}/unauthorized",
                //        $"{spaClientUrl}",
                //        "http://localhost:4200/unauthorized",
                //        "http://localhost:4200"
                //    },
                //    AllowedCorsOrigins = new List<string>
                //    {
                //        $"{spaClientUrl}",
                //        "http://localhost:4200"
                //    },
                //    AllowedScopes = new List<string>
                //    {
                //        IdentityServerConstants.StandardScopes.OpenId,
                //        IdentityServerConstants.StandardScopes.Profile,
                //        "resourceApi"
                //    }
                //}
            };
        }

        public static List<TestUser> GetTestUsers()
        {
            return new List<TestUser>
            {
                new TestUser{SubjectId = "818727", Username = "alice", Password = "alice",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Alice Smith"),
                        new Claim(JwtClaimTypes.GivenName, "Alice"),
                        new Claim(JwtClaimTypes.FamilyName, "Smith"),
                        new Claim(JwtClaimTypes.Email, "AliceSmith@email.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                        new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json)
                    }
                },
                new TestUser{SubjectId = "88421113", Username = "bob", Password = "bob",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Bob Smith"),
                        new Claim(JwtClaimTypes.GivenName, "Bob"),
                        new Claim(JwtClaimTypes.FamilyName, "Smith"),
                        new Claim(JwtClaimTypes.Email, "BobSmith@email.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                        new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json),
                        new Claim("location", "somewhere")
                    }
                }
            };
        }
    }
}
