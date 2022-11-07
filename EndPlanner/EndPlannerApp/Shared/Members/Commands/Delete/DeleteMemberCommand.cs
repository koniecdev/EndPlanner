using Domain.Entities;
using Domain.Entities.Fuel;

namespace EndPlannerApp.Shared.Members.Commands;

public class DeleteMemberCommand : IRequest<Unit>
{
	public int Id { get; set; }
}
