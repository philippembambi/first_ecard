using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace First.Ecard.Infrastructure.Persistence
{
    public class FirstDbContextFactory : IDesignTimeDbContextFactory<FirstDbContext>
    {
        public FirstDbContext CreateDbContext(string[] args)
        {
            //var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                //.AddJsonFile(Path.Combine(basePath, ""), optional: true)
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection")
                ?? "Host=localhost;Port=5432;Database=first_e_card;Username=costa;Password=Costa";

            var optionsBuilder = new DbContextOptionsBuilder<FirstDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new FirstDbContext(optionsBuilder.Options);
        }
    }
}