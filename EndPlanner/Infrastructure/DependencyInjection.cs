using Application.Common.Interfaces;
using Infrastructure.ExternalAPIs.FuelPrices;
using Infrastructure.ExternalAPIs.NBP;
using Infrastructure.FileStore;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;
public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddHttpClient("NBPClient", options =>
		{
			options.BaseAddress = new Uri("http://api.nbp.pl/api");
			options.Timeout = new TimeSpan(0, 0, 15);
			options.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
		}).ConfigurePrimaryHttpMessageHandler(sp => new HttpClientHandler());

		services.AddScoped<INBPClient, NBPClient>();
		services.AddScoped<IFuelPricesClient, FuelPricesClient>();

		services.AddTransient<IDateTime, DateTimeService>();
		services.AddTransient<IFileWrapper, FileWrapper>();
		services.AddTransient<IDirectoryWrapper, DirectoryWrapper>();
		services.AddTransient<IFileStore, FileStore.FileStore>();
		return services;
	}
}