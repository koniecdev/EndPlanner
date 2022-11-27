using Domain.Entities;

namespace EndPlannerApp.Shared.Countries.Queries;

public class GetCountriesDto : IMapFrom<Country>
{
	public int Id { get; set; }
	public string Name { get; set; } = "";
	public string CountryCode { get; set; } = "";
	public string CountryCode3 { get; set; } = "";
	public string CurrencyCode { get; set; } = "";
	public void Mapping(Profile profile)
	{
		profile.CreateMap<Country, GetCountriesDto>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
}