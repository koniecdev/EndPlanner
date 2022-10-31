using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistance.Configurations;
public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
	public void Configure(EntityTypeBuilder<Country> builder)
	{
		builder.Property(m => m.Name).HasMaxLength(50).IsRequired();
		builder.Property(m => m.CountryCode).HasMaxLength(3).IsRequired();
		builder.Property(m => m.CurrencyCode).HasMaxLength(3).IsRequired();
	}
}