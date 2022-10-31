namespace Domain.Entities;
public class Car : AuditableEntity
{
	public string Name { get; set; } = "";
	public int Seats { get; set; }
	public double FuelConsumption { get; set; }
	public int FuelType { get; set; }
	public int TankLiters { get; set; }
	public int DriversAvailable { get; set; }
	public int MemberId { get; set; }
	public Member Member { get; set; }
	public ICollection<Trip> Trips { get; set; }
}