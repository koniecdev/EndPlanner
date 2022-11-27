using Domain.Entities.Fuel;
using EndPlannerApp.Shared.Fuel.Queries.GetAll;

namespace Application.NBP.Queries.GetAll;
public class GetAllFuelPricesQueryHandler : IRequestHandler<GetAllFuelPricesQuery, GetAllFuelPricesVm>
{
	private readonly IFuelPricesClient _FuelClient;
	private readonly IMapper _mapper;
	public GetAllFuelPricesQueryHandler(IMapper mapper, IFuelPricesClient FuelClient)
	{
		_FuelClient = FuelClient;
		_mapper = mapper;
	}
	public async Task<GetAllFuelPricesVm> Handle(GetAllFuelPricesQuery request, CancellationToken cancellationToken)
	{
		List<FuelData> fuelData = await _FuelClient.GetAllEuropeanCountryPrices(request.FuelCode, cancellationToken);
		if(fuelData.Count == 0)
		{
			throw new NotFoundException(request.FuelCode, new Exception());
		}
		List<GetAllFuelPricesDto> fuelPrices = _mapper.Map<List<GetAllFuelPricesDto>>(fuelData);
		GetAllFuelPricesVm vm = new() { FuelExchanges = fuelPrices };
		return vm;
	}
}
