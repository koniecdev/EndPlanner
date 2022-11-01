namespace Domain.Entities;
public class Country : AuditableEntity
{
	public string Name { get; set; } = "";
	public string CountryCode { get; set; } = "";
	public string CurrencyCode { get; set; } = "";
	public ICollection<Route> Routes { get; set; }
	public ICollection<Rule> Rules { get; set; }
}