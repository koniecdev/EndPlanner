using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations;
public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
	public void Configure(EntityTypeBuilder<Country> builder)
	{
		builder.Property(m => m.Name).HasMaxLength(50).IsRequired();
		builder.Property(m => m.CountryCode).HasMaxLength(2).IsRequired();
		builder.Property(m => m.CountryCode3).HasMaxLength(3).IsRequired();
		builder.Property(m => m.CurrencyCode).HasMaxLength(3).IsRequired();
	}
}