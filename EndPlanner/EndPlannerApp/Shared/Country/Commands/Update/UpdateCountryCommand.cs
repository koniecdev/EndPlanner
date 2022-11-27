using Domain.Entities;

namespace EndPlannerApp.Shared.Countries.Commands;

public class UpdateCountryCommand : IMapFrom<Country>, IRequest<Unit>
{
	public int Id { get; set; }
	public string? Name { get; set; }
	public string? CountryCode { get; set; }
	public string? CountryCode3 { get; set; }
	public string? CurrencyCode { get; set; }

	public void Mapping(Profile profile)
	{
		profile.CreateMap<UpdateCountryCommand, Country>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

	}
}
