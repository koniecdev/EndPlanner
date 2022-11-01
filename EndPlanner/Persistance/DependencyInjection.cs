using Application.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistance;
public static class DependencyInjection
{
	public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<EndPlannerDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("EndPlannerDatabase")));
		services.AddScoped<IEndPlannerDbContext, EndPlannerDbContext>();
		return services;
	}
}