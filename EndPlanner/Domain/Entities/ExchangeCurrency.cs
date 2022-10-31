namespace Domain.Entities;
public class ExchangeCurrency
{
	public string Table { get; set; } = "";
	public string Currency { get; set; } = "";
	public string Code { get; set; } = "";
	public ICollection<ExchangeRate> Rates { get; set; } = new List<ExchangeRate>();
}