using Bitnovo.Customers.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bitnovo.Customers.Infrastructure.Data
{ 
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(c => c.Username, a =>
            {
                a.Property(p => p.Value)
                    .HasColumnName("Username")
                    .IsRequired();
            });

            builder.OwnsOne(c => c.Password, a =>
            {
                a.Property(p => p.Value)
                    .HasColumnName("Password")
                    .IsRequired();
            });

            builder.HasOne(x => x.Customer)
                .WithOne(x => x.User)
                .HasForeignKey<User>(x => x.CustomerId);
        }
    }
}
