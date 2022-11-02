using EndPlannerApp.Shared.NBP.Queries.GetAll;
using EndPlannerApp.Shared.NBP.Queries.GetBy;
using Microsoft.AspNetCore.Mvc;

namespace EndPlanner.Controllers
{
	[Route("api/nbp-apis")]
	public class NBPController : BaseController
	{
		[HttpGet]
		[Route("eu")]
		public async Task<ActionResult<GetEuExchangesVm>> GetMemberTripsCarsVm()
		{
			var response = await Mediator.Send(new GetEuExchangesQuery());
			return response;
		}

		[HttpGet]
		[Route("eu/{currencyCode}")]
		public async Task<ActionResult<GetEuExchangeVm>> GetMemberTripsCarsVm(string currencyCode)
		{
			var response = await Mediator.Send(new GetEuExchangeQuery() { CurrencyCode = currencyCode });
			return response;
		}

		//[HttpPost]
		//public async Task<ActionResult<int>> Member(CreateMemberCommand command)
		//{
		//	int response = await Mediator.Send(command);
		//	return response;
		//}
	}
}