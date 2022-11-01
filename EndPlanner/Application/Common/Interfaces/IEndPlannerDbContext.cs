using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;
public interface IEndPlannerDbContext
{
    DbSet<Country> Countries { get; set; }
    DbSet<Member> Members { get; set; }
    DbSet<Car> Cars { get; set; }
    DbSet<Route> Routes { get; set; }
    DbSet<Trip> Trips { get; set; }
    DbSet<Rule> Rules { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
