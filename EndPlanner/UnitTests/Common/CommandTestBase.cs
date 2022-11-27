using EndPlannerApp.Shared.Common.Mappings;
using Moq;
using Persistance;
using System;
namespace UnitTests;

public class CommandTestBase : IDisposable
{
	protected EndPlannerDbContext _db { get; private set; }
	protected IMapper _mapper { get; private set; }
	protected IDateTime _dateTime { get; private set; }
	protected CancellationToken _token { get; private set; }
	public CommandTestBase()
	{
		_db = EndPlannerDbContextFactory.Create().Object;
		var configurationProvider = new MapperConfiguration(cfg =>
		{
			cfg.AddProfile<MappingProfile>();
		});
		_mapper = configurationProvider.CreateMapper();
		var dateTimeMock = new Mock<IDateTime>();
		dateTimeMock.Setup(m => m.Now).Returns(new DateTime(2025, 1, 1));
		_dateTime = dateTimeMock.Object;
		_token = CancellationToken.None;
	}
	public void Dispose()
	{
		EndPlannerDbContextFactory.Destroy(_db);
	}
}
