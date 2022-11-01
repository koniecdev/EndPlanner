using Moq;
using Persistance;
using System;
using Xunit;
namespace UnitTests;

public class CommandTestBase : IDisposable
{
	protected readonly EndPlannerDbContext _context;
	protected readonly Mock<EndPlannerDbContext> _contextMock;
	public CommandTestBase()
	{
		_contextMock = EndPlannerDbContextFactory.Create();
		_context = _contextMock.Object;
	}
	public void Dispose()
	{
		EndPlannerDbContextFactory.Destroy(_context);
	}
}
