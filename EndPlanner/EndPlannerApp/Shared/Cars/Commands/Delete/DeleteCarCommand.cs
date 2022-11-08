using Domain.Entities;
using Domain.Entities.Fuel;

namespace EndPlannerApp.Shared.Cars.Commands;

public class DeleteCarCommand : IRequest<Unit>
{
	public int Id { get; set; }
}
