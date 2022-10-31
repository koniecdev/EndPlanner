namespace Persistance;
public class EndPlannerContextFactory : DesignTimeDbContextFactoryBase<EndPlannerDbContext>
{
	protected override EndPlannerDbContext CreateNewInstance(DbContextOptions<EndPlannerDbContext> options)
	{
		return new EndPlannerDbContext(options);
	}
}