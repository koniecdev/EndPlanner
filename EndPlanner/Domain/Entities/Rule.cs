namespace Domain.Entities;
public class Rule : AuditableEntity
{
	public string Description { get; set; } = "";
	public int CountryId { get; set; }
	public Country Country { get; set; }
	public int TripId { get; set; }
	public Trip Trip { get; set; }
}