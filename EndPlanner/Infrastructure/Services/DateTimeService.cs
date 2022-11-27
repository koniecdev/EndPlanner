using Application.Common.Interfaces;

namespace Infrastructure.Services
{
	public class DateTimeService : IDateTime
	{
		public DateTime Now => DateTime.Now.ToUniversalTime();
		public DateTime Yesterday => DateTime.Now.AddDays(-1).ToUniversalTime();
	}
}
