using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace TShop.Identity.API.Data;

public class IdentityDbContextDesignTimeFactory : IDesignTimeDbContextFactory<IdentityDBContext>
{
    public IdentityDBContext CreateDbContext(string[] args)
    {
        var services = new ServiceCollection();
        services.Configure<IdentityOptions>(options =>
        {
            options.Stores.SchemaVersion = IdentitySchemaVersions.Version3;
        });
        var appServices = services.BuildServiceProvider();

        var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__identitydb")
                               ?? "Host=postgres;Database=identitydb;Username=postgres;Password=XdHzf1GaT(gpV6RVacKguu";

        var options = new DbContextOptionsBuilder<IdentityDBContext>()
            .UseNpgsql(connectionString)
            .UseApplicationServiceProvider(appServices);

        return new IdentityDBContext(options.Options);
    }
}