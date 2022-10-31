using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using System.Reflection;

namespace Persistance;
public class EndPlannerDbContext : DbContext
{
    private readonly IDateTime _dateTime;
    private readonly ICurrentUserService _userService;
	public EndPlannerDbContext()
	{
    }
    public EndPlannerDbContext(DbContextOptions<EndPlannerDbContext> options) : base(options)
    {
    }
    public EndPlannerDbContext(
        DbContextOptions<EndPlannerDbContext> options, IDateTime dateTime, ICurrentUserService userService) :base(options)
	{
        _dateTime = dateTime;
        _userService = userService;
	}

    public DbSet<Country> Countries { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Route> Routes { get; set; }
    public DbSet<Trip> Trips { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = _userService.Email;
                    entry.Entity.Created = _dateTime.Now;
                    entry.Entity.StatusId = 1;
                    break;
                case EntityState.Modified:
                    entry.Entity.ModifiedBy = _userService.Email;
                    entry.Entity.Modified = _dateTime.Now;
                    break;
                case EntityState.Deleted:
                    entry.Entity.ModifiedBy = _userService.Email;
                    entry.Entity.Modified = _dateTime.Now;
                    entry.Entity.Inactivated = _dateTime.Now;
                    entry.Entity.InactivatedBy = _userService.Email;
                    entry.Entity.StatusId = 0;
                    entry.State = EntityState.Modified;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}