using Bitnovo.Banking.Domain.Entities;
using Bitnovo.Banking.Infrastructure.Data.Configurations;
using Bitnovo.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Bitnovo.Banking.Infrastructure.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        { }

        public DbSet<Account> Accounts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<StringValue>();
            modelBuilder.Ignore<PositiveDecimal>();

            modelBuilder.ForNpgsqlUseIdentityColumns()
                .ApplyConfiguration(new AccountConfiguration());
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
