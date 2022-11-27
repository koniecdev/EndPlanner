using Domain.Entities;

namespace EndPlannerApp.Shared.Countries.Commands;

public class CreateCountryCommand : IMapFrom<Country>, IRequest<int>
{
	public string Name { get; set; } = "";
	public string CountryCode { get; set; } = "";
	public string CountryCode3 { get; set; } = "";
	public string CurrencyCode { get; set; } = "";

	public void Mapping(Profile profile)
	{
		profile.CreateMap<CreateCountryCommand, Country>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
}
