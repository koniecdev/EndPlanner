namespace Domain.Entities.NBP;
public class EuExchangesData
{
	public string Table { get; set; } = "";
	public string No { get; set; } = "";
	public string EffectiveDate { get; set; } = "";
	public ICollection<EuExchangesRate> Rates { get; set; } = new List<EuExchangesRate>();
}