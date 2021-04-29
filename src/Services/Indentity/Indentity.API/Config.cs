using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace Indentity.API
{
    public class Config
    {
        //IdentityServer needs to know what client applications are allowed to use it.
        //Clients that need to access the Api resource are defined in the clients section.
        //Each client application is defined in the Client object on the IdentityServer side.
        //A list of applications that are allowed to use your system.
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                   new Client
                   {
                        ClientId = "client",
                        AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                        AllowAccessTokensViaBrowser= true,
                        ClientSecrets =
                        {
                            new Secret("secret".Sha256())
                        },
                        AllowedScopes = {
                           IdentityServerConstants.StandardScopes.OpenId,
                           IdentityServerConstants.StandardScopes.Profile,
                           IdentityServerConstants.StandardScopes.OfflineAccess,
                       }
                   },
            };

        //IdentityResource is information that includes user information such as userId, email, name, has a unique name and we can assign claim types linked to them.
        //Identity Resource information defined for a user is included in the identity token.
        //We can use Identity Resource that we defined with scope parameter in client settings.
        public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        //ApiResources
        //ApiScopes
        //An API is a resource in your system that you want to protect.
        //Resources or Apis is the part where the data source or web service we want to protect is defined.
        //So for that reason we have defined ApiResources and ApiScopes.
        //Scopes represent what a client application is allowed to do.
        public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>
        {
          //new ApiScope("catalog"),
          //new ApiScope("orders"),
          //new ApiScope("basket"),
          //new ApiScope("apigateway"),
        };

        //public static IEnumerable<ApiResource> ApiResources => new List<ApiResource>
        //    {
        //        new ApiResource("orders", "Orders Service"),
        //        new ApiResource("basket", "Basket Service"),
        //        new ApiResource("mobileshoppingagg", "Mobile Shopping Aggregator"),
        //        new ApiResource("webshoppingagg", "Web Shopping Aggregator"),
        //        new ApiResource("orders.signalrhub", "Ordering Signalr Hub"),
        //        new ApiResource("webhooks", "Webhooks registration Service"),
        //    };

        //Test users that will use the client applications need to access the Apis.
        //So for client application we should also defined test users.
        public static List<TestUser> TestUsers =>
            new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
                    Username = "tupv",
                    Password = "123456a@A",
                }
            };
    }
}