using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations;
public class RuleConfiguration : IEntityTypeConfiguration<Rule>
{
	public void Configure(EntityTypeBuilder<Rule> builder)
	{
		builder.Property(m => m.Description).HasMaxLength(300).IsRequired();
		builder.Property(m => m.CountryId).IsRequired();
		builder.Property(m => m.TripId).IsRequired();
	}
}