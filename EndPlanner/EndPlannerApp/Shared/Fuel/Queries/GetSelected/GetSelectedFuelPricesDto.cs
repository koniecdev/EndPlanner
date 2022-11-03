using Domain.Entities.Fuel;

namespace EndPlannerApp.Shared.Fuel.Queries.GetSelected;

public class GetSelectedFuelPricesDto : IMapFrom<FuelData>
{
	public string Date { get; set; } = "";
	public string CountryName { get; set; } = "";
	public string CountryCode { get; set; } = "";
	public double PricePerLiter { get; set; }
	public void Mapping(Profile profile)
	{
		profile.CreateMap<FuelData, GetSelectedFuelPricesDto>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
}
