using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace IdentityServer;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
            {
                new ApiScope(name: "api1", displayName: "My API")
            };

    public static IEnumerable<Client> Clients =>
        new Client[]
            {
                new Client{
                    ClientId="client",
                    AllowedGrantTypes=GrantTypes.ClientCredentials, // no interactive user, use the clientid/secret for authentication
                    ClientSecrets={ // secret for authentication
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes={ "api1" } // scopes that client has access to
                },
                new Client{
                    ClientId="web",
                    ClientSecrets= { new Secret("secret".Sha256())},
                    AllowedGrantTypes=GrantTypes.Code,
                    RedirectUris={"https://localhost:5002/signin-oidc"},
                    PostLogoutRedirectUris={"https://localhost:5002/signout-callback-oidc"},
                    AllowedScopes={
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                    }
                }
            };
}