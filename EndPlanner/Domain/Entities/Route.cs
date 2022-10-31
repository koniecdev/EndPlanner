namespace Domain.Entities;
public class Route : AuditableEntity
{
	public int Order { get; set; }
	public int? BorderDistance { get; set; }
	public double? SleepoverCost { get; set; }
	public DateTime? LeavingDate { get; set; }
	public Address Address { get; set; } = new();
	public int CountryId { get; set; }
	public Country Country { get; set; }
	public int TripId { get; set; }
	public Trip Trip { get; set; }
}