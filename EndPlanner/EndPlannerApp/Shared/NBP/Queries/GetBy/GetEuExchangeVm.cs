using Domain.Entities.NBP;

namespace EndPlannerApp.Shared.NBP.Queries.GetBy;

public class GetEuExchangeVm : IMapFrom<EuExchangeCurrency>
{
	public string Currency { get; set; } = "";
	public string Code { get; set; } = "";
	public ICollection<GetEuExchangeDto> Rates { get; set; } = new List<GetEuExchangeDto>();
	public void Mapping(Profile profile)
	{
		profile.CreateMap<EuExchangeCurrency, GetEuExchangeVm>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
	
}
