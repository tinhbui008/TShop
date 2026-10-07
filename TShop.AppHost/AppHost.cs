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
    .WaitFor(identity)
    // Cổng public cố định cho gateway (dev): không qua proxy Aspire nên URL ổn định giữa các lần chạy.
    .WithHttpEndpoint(port: 28547, name: "public", isProxied: false);

builder.Build().Run();