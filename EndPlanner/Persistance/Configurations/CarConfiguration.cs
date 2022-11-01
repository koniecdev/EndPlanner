using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations;
public class CarConfiguration : IEntityTypeConfiguration<Car>
{
	public void Configure(EntityTypeBuilder<Car> builder)
	{
		builder.Property(m => m.Name).HasMaxLength(100).IsRequired();
		builder.Property(m => m.Seats).IsRequired();
		builder.Property(m => m.FuelConsumption).IsRequired();
		builder.Property(m => m.FuelType).IsRequired();
		builder.Property(m => m.MemberId).IsRequired();
		builder.Property(m => m.TankLiters).IsRequired();
	}
}