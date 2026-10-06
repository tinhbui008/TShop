var builder = DistributedApplication.CreateBuilder(args);

///POSTGRESQL

var postgres = builder.AddPostgres("postgres")
    .WithPgWeb();

var identityDb = postgres.AddDatabase("identitydb");

builder.AddProject<Projects.TShop_Identity_API>("identity")
    .WithReference(identityDb)
    .WaitFor(identityDb);

var identity = builder.AddProject<Projects.TShop_Identity_API>("identity")
    .WithReference(identityDb)
    // .WithEnvironment("Jwt__Key", jwtKey)
    // .WithEnvironment("Jwt__Issuer", jwtIssuer)
    // .WithEnvironment("Jwt__Audience", jwtAudience)
    .WaitFor(identityDb);

var gateway = builder.AddProject<Projects.TShop_Gateway>("gateway")
    .WithReference(identity)
    .WaitFor(identity);
builder.Build().Run();