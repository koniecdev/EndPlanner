using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations;
public class TripConfiguration : IEntityTypeConfiguration<Trip>
{
	public void Configure(EntityTypeBuilder<Trip> builder)
	{
		builder.Property(m => m.Name).HasMaxLength(100).IsRequired();
		builder.OwnsOne(m => m.Address).Property(m=>m.City).HasColumnName("City").HasMaxLength(100);
		builder.OwnsOne(m => m.Address).Property(m=>m.PostalCode).HasColumnName("PostalCode").HasMaxLength(20);
		builder.OwnsOne(m => m.Address).Property(m=>m.Street).HasColumnName("Street").HasMaxLength(100);
		builder.OwnsOne(m => m.Address).Property(m=>m.House).HasColumnName("House").HasMaxLength(5);
	}
}