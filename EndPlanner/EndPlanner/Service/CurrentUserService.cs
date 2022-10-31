using Application.Common.Interfaces;
using IdentityModel;
using System.Security.Claims;

namespace EndPlanner.Service;
public class CurrentUserService : ICurrentUserService
{
	public string Id { get; set; } = "";
	public string Email { get; set; } = "";
	public bool IsAuthenticated { get; set; }

	public CurrentUserService()
	{
		Email = "DummyEmail@dummy.com";
		Id = "DummyId";
		IsAuthenticated = true;
	}

	public CurrentUserService(IHttpContextAccessor accessor)
	{
		if (accessor != null)
		{
			var id = accessor.HttpContext?.User?.FindFirstValue(JwtClaimTypes.Id);
			var email = accessor.HttpContext?.User?.FindFirstValue(JwtClaimTypes.Email);

			Email = email;
			Id = id;
			IsAuthenticated = !string.IsNullOrEmpty(Email);
		}
	}
}
