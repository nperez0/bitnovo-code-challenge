using Bitnovo.Customers.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bitnovo.Customers.Infrastructure.Data
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.OwnsOne(c => c.FirstName, a =>
            {
                a.Property(p => p.Value)
                    .HasColumnName("FirstName")
                    .IsRequired();
            });

            builder.OwnsOne(c => c.Surname, a =>
            {
                a.Property(p => p.Value)
                    .HasColumnName("Surname")
                    .IsRequired();
            });

            builder.OwnsOne(c => c.Email, a =>
            {
                a.Property(p => p.Value)
                    .HasColumnName("Email")
                    .IsRequired();
            });

            builder.HasOne(x => x.User)
                .WithOne(x => x.Customer)
                .HasForeignKey<Customer>(x => x.UserId);
        }
    }
}
