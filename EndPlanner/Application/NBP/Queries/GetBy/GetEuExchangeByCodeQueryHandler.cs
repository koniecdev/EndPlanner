using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities.NBP;
using EndPlannerApp.Shared.NBP.Queries.GetBy;

namespace Application.NBP.Queries.GetBy;
public class GetEuExchangeByCodeQueryHandler : IRequestHandler<GetEuExchangeQuery, GetEuExchangeVm>
{
	private readonly INBPClient _NBPClient;
	private readonly IMapper _mapper;
	public GetEuExchangeByCodeQueryHandler(INBPClient NBPClient, IMapper mapper)
	{
		_NBPClient = NBPClient;
		_mapper = mapper;
	}
	public async Task<GetEuExchangeVm> Handle(GetEuExchangeQuery request, CancellationToken cancellationToken)
	{
		EuExchangeCurrency? vm = await _NBPClient.GetExchangeRateByCurrency(request.CurrencyCode.ToUpper(), cancellationToken);
		if(vm == null)
		{
			throw new NotFoundException(request.CurrencyCode, new Exception());
		}
		GetEuExchangeVm mapped = _mapper.Map<GetEuExchangeVm>(vm);
		if (mapped == null)
		{
			throw new MappingException(nameof(GetEuExchangeVm), new Exception());
		}
		return mapped;

	}
}
