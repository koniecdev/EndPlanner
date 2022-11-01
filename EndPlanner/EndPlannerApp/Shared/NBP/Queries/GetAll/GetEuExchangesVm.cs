using Domain.Entities.NBP;

namespace EndPlannerApp.Shared.NBP.Queries.GetAll;

public class GetEuExchangesVm : IMapFrom<EuExchangesData>
{
	public string EffectiveDate { get; set; } = "";
	public ICollection<GetEuExchangesDto> Rates { get; set; } = new List<GetEuExchangesDto>();
	public void Mapping(Profile profile)
	{
		profile.CreateMap<EuExchangesData, GetEuExchangesVm>()
			.ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
	}
	
}
