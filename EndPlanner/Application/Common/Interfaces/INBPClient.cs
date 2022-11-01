using Domain.Entities.NBP;
namespace Application.Common.Interfaces;

public interface INBPClient
{
	Task<EuExchangesData> GetAllPlnExchangeRates(CancellationToken cancellationToken);
	Task<ExchangeCurrency> GetExchangeRateByCurrency(string requiredCurrencyCode, CancellationToken cancellationToken);
}
