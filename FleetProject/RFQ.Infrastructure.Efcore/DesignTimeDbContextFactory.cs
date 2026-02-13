using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace RFQ.Infrastructure.Efcore
{
    // This factory is used by the EF tools at design-time to create the DbContext
    // when the application's Program/Startup is not executed. It tries to locate
    // an appsettings.json file by walking up the directory tree and reads the
    // connection string named "RfqDBConnection".
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<FleetLynkDbContext>
    {
        public FleetLynkDbContext CreateDbContext(string[] args)
        {
            // Find an appsettings.json by walking up parent directories
            string? basePath = Directory.GetCurrentDirectory();
            string? configFile = null;

            while (!string.IsNullOrEmpty(basePath))
            {
                var candidate = Path.Combine(basePath, "appsettings.json");
                if (File.Exists(candidate))
                {
                    configFile = candidate;
                    break;
                }

                var parent = Directory.GetParent(basePath);
                if (parent == null) break;
                basePath = parent.FullName;
            }

            var configurationBuilder = new ConfigurationBuilder();

            if (configFile != null)
            {
                configurationBuilder.AddJsonFile(configFile, optional: false);
            }
            else
            {
                // Fall back to environment variables if no appsettings.json is found
                configurationBuilder.AddEnvironmentVariables();
            }

            var configuration = configurationBuilder.Build();
            var connectionString = configuration.GetConnectionString("RfqDBConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Could not find a connection string named 'RfqDBConnection'. Please ensure appsettings.json contains it or set environment variable.");
            }

            var optionsBuilder = new DbContextOptionsBuilder<FleetLynkDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new FleetLynkDbContext(optionsBuilder.Options);
        }
    }
}
