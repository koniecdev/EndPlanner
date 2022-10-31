namespace Domain.Entities;
public class Trip : AuditableEntity
{
	public string Name { get; set; } = "";
	public DateTime? StartingDate { get; set; }
	public Address Address { get; set; } = new();
	public int CarId { get; set; }
	public Car Car { get; set; }
	public ICollection<Route> Routes { get; set; }
	public ICollection<Member> Members { get; set; }
}