using Domain.Entities.NBP;

namespace EndPlannerApp.Shared.NBP.Queries.GetBy;

public class GetEuExchangeDto : IMapFrom<EuExchangeRate>
{
	public string EffectiveDate { get; set; } = "";
	public double Mid { get; set; }
	public void Mapping(Profile profile)
	{
		profile.CreateMap<EuExchangeRate, GetEuExchangeDto>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
}
