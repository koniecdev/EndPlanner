using Domain.Entities.NBP;

namespace EndPlannerApp.Shared.NBP.Queries.GetAll;

public class GetEuExchangesDto : IMapFrom<EuExchangesRate>
{
	public string Currency { get; set; } = "";
	public string Code { get; set; } = "";
	public double Mid { get; set; }
	public void Mapping(Profile profile)
	{
		profile.CreateMap<EuExchangesRate, GetEuExchangesDto>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
}
