using Application.Common.Interfaces;
using Domain.Entities.NBP;
using EndPlannerApp.Shared.NBP.Queries.GetAll;

namespace Application.NBP.Queries.GetAll;
public class GetEuExchangesQueryHandler : IRequestHandler<GetEuExchangesQuery, GetEuExchangesVm>
{
	private readonly INBPClient _NBPClient;
	private readonly IMapper _mapper;
	public GetEuExchangesQueryHandler(INBPClient NBPClient, IMapper mapper)
	{
		_NBPClient = NBPClient;
		_mapper = mapper;
	}
	public async Task<GetEuExchangesVm> Handle(GetEuExchangesQuery request, CancellationToken cancellationToken)
	{
		EuExchangesData? dataFromApi = await _NBPClient.GetAllPlnExchangeRates(cancellationToken);
		if(dataFromApi == null)
		{
			throw new Exception();
		}
		var mapped = _mapper.Map<GetEuExchangesVm>(dataFromApi);
		if(mapped == null)
		{
			throw new Exception();
		}
		return mapped;
	}
}
