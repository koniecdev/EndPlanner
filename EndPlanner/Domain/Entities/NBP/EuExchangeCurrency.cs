namespace Domain.Entities.NBP;
public class EuExchangeCurrency
{
	public string Table { get; set; } = "";
	public string Currency { get; set; } = "";
	public string Code { get; set; } = "";
	public ICollection<EuExchangeRate> Rates { get; set; } = new List<EuExchangeRate>();
}