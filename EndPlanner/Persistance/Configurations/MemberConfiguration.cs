using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations;
public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
	public void Configure(EntityTypeBuilder<Member> builder)
	{
		builder.Property(m => m.UserEmail).HasMaxLength(100).IsRequired();
		builder.Property(m => m.UserId).IsRequired();
	}
}