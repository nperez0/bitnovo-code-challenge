using Bitnovo.Common;
using Bitnovo.Customers.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Bitnovo.Customers.Infrastructure.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<StringValue>();

            modelBuilder.ForNpgsqlUseIdentityColumns()
                .ApplyConfiguration(new CustomerConfiguration())
                .ApplyConfiguration(new UserConfiguration());
        }

        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<Context>
        {
            public Context CreateDbContext(string[] args)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var builder = new DbContextOptionsBuilder<Context>();
                var connectionString = configuration["ConnectionString"];

                builder.UseNpgsql(connectionString);

                return new Context(builder.Options);
            }
        }
    }
}
