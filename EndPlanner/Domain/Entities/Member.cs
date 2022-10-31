namespace Domain.Entities;
public class Member : AuditableEntity
{
	public string UserId { get; set; } = "";
	public string UserEmail { get; set; } = "";
	public ICollection<Car> Cars { get; set; }
	public ICollection<Trip> Trips { get; set; }
}