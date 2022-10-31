﻿using Domain.Common;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistance;
public static class DependencyInjection
{
	public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<EndPlannerDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("EndPlannerDatabase")));
		return services;
	}
}