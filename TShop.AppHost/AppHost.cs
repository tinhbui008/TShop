var builder = DistributedApplication.CreateBuilder(args);

///POSTGRESQL

var postgres = builder.AddPostgres("postgres")
    .WithPgWeb();

var identityDb = postgres.AddDatabase("identitydb");

var identity = builder.AddProject<Projects.TShop_Identity_API>("identity")
    .WithReference(identityDb)
    .WaitFor(identityDb);

var gateway = builder.AddProject<Projects.TShop_Gateway>("gateway")
    .WithReference(identity)
    .WaitFor(identity);

builder.Build().Run();