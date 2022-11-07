using AutoMapper;
using EndPlannerApp.Shared.Common.Mappings;
using Moq;
using Persistance;
using System;
using Xunit;
namespace UnitTests;

public class CommandTestBase : IDisposable
{
	protected EndPlannerDbContext _db { get; private set; }
	protected IMapper _mapper { get; private set; }
	protected CancellationToken _token { get; private set; }
	public CommandTestBase()
	{
		_db = EndPlannerDbContextFactory.Create().Object;
		var configurationProvider = new MapperConfiguration(cfg =>
		{
			cfg.AddProfile<MappingProfile>();
		});
		_mapper = configurationProvider.CreateMapper();
		_token = CancellationToken.None;
	}
	public void Dispose()
	{
		EndPlannerDbContextFactory.Destroy(_db);
	}
}
