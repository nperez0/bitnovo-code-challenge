using Bitnovo.Banking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bitnovo.Banking.Infrastructure.Data.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(c => c.Id);

            builder.OwnsOne(c => c.Number, a =>
            {
                a.Property(p => p.Value)
                    .HasColumnName("Number")
                    .IsRequired();
            });

            builder.OwnsOne(c => c.Balance, a =>
            {
                a.Property(p => p.Value)
                    .HasColumnName("Balance")
                    .IsRequired();
            });

            builder.Property(p => p.CustomerId)
                .IsRequired();
        }
    }
}
