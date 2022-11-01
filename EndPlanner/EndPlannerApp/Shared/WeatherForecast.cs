global using MediatR;
global using AutoMapper;
global using EndPlannerApp.Shared.Common.Mappings;


namespace EndPlannerApp.Shared
{
	public class WeatherForecast
	{
		public DateTime Date { get; set; }

		public int TemperatureC { get; set; }

		public string? Summary { get; set; }

		public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
	}
}