using Domain.Entities.Fuel;
using EndPlannerApp.Shared.Fuel.Queries.GetSelected;

namespace Application.NBP.Queries.GetBy;
public class GetSelectedFuelPricesQueryHandler : IRequestHandler<GetSelectedFuelPricesQuery, GetSelectedFuelPricesVm>
{
	private readonly IFuelPricesClient _fuelClient;
	private readonly IMapper _mapper;
	public GetSelectedFuelPricesQueryHandler(IFuelPricesClient fuelClient, IMapper mapper)
	{
		_fuelClient = fuelClient;
		_mapper = mapper;
	}
	public async Task<GetSelectedFuelPricesVm> Handle(GetSelectedFuelPricesQuery request, CancellationToken cancellationToken)
	{
		List<FuelData> fuelPrices = await _fuelClient.GetSelectedEuropeanCountryPrices(request.FuelType, request.ProvidedCountries, cancellationToken);
		if (fuelPrices.Count == 0)
		{
			throw new NotFoundException(string.Concat(request.FuelType, " / ", request.ProvidedCountries), new Exception());
		}
		List<GetSelectedFuelPricesDto> mapped = _mapper.Map<List<GetSelectedFuelPricesDto>>(fuelPrices);
		GetSelectedFuelPricesVm vm = new() { FuelExchanges = mapped };
		return vm;

	}
}
