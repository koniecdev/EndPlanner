using Domain.Entities.NBP;
namespace Application.Common.Interfaces;

public interface INBPClient
{
	Task<EuExchangesData> GetAllPlnExchangeRates(CancellationToken cancellationToken);
	Task<EuExchangeCurrency> GetExchangeRateByCurrency(string requiredCurrencyCode, CancellationToken cancellationToken);
}
