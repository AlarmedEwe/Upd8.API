using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Upd8.Domain.Entities;

namespace Upd8.Data.Mapping
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey("Id");

            builder.Property(c => c.Cpf)
                   .HasColumnType("varchar(20)")
                   .IsRequired();

            builder.Property(c => c.Name)
                   .HasColumnType("varchar(150)")
                   .IsRequired();

            builder.Property(c => c.Birthday)
                   .HasColumnType("date")
                   .IsRequired();

            builder.Property(c => c.Gender)
                   .HasColumnType("varchar(1)")
                   .IsRequired();

            builder.Property(c => c.Address)
                   .HasColumnType("varchar(max)");

            builder.Property(c => c.State)
                   .HasColumnType("varchar(2)");

            builder.Property(c => c.City)
                   .HasColumnType("varchar(max)");

            builder.Property(c => c.CreatedAt)
                   .HasColumnType("datetime")
                   .HasDefaultValueSql("getdate()")
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            builder.Property(c => c.UpdatedAt)
                   .HasColumnType("datetime")
                   .HasDefaultValueSql("getdate()")
                   .ValueGeneratedOnUpdate();

            builder.Property(c => c.IsDeleted)
                   .HasColumnType("bit")
                   .HasDefaultValue(false)
                   .ValueGeneratedOnAdd()
                   .IsRequired();
        }
    }
}
