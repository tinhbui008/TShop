using Duende.IdentityServer.Models;

namespace TShopping.Identity
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources() =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> GetApiScopes() =>
            new List<ApiScope>
            {
                new ApiScope("catalogapi"),
                //new ApiScope("basketapi"),
                //new ApiScope("catalogapi.read"),
                //new ApiScope("catalogapi.write"),
                //new ApiScope("eshoppinggateway")
            };


        public static IEnumerable<ApiResource> GetApiResource() =>
         new List<ApiResource>
         {
              new ApiResource("Catalog", "Catalog.API")
              {
                    Scopes = {"catalogapi.read", "catalogapi.write"}
              },
         };

        public static IEnumerable<Client> GetClients() =>
            new List<Client>
            {
                new Client
                {
                    ClientName = "Catalog API Client",
                    ClientId = "CatalogApiClient",
                    ClientSecrets = {new Secret("5c6eb3b4-61a7-4668-ac57-2b4591ec26d2".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    //AllowedScopes = {"catalogapi.read", "catalogapi.write"}
                    AllowedScopes = {"catalogapi"}
                },
            };
    }

}
