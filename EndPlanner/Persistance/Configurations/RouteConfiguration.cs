using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations;
public class RouteConfiguration : IEntityTypeConfiguration<Route>
{
	public void Configure(EntityTypeBuilder<Route> builder)
	{
		builder.Property(m => m.Order).HasDefaultValue(1);
		builder.Property(m => m.CountryId).IsRequired();
		builder.Property(m => m.TripId).IsRequired();
		builder.OwnsOne(m => m.Address).Property(m=>m.City).HasColumnName("City").HasMaxLength(100);
		builder.OwnsOne(m => m.Address).Property(m=>m.PostalCode).HasColumnName("PostalCode").HasMaxLength(20);
		builder.OwnsOne(m => m.Address).Property(m=>m.Street).HasColumnName("Street").HasMaxLength(100);
		builder.OwnsOne(m => m.Address).Property(m=>m.House).HasColumnName("House").HasMaxLength(5);
	}
}