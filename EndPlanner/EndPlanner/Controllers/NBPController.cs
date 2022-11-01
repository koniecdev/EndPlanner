using Microsoft.AspNetCore.Mvc;

namespace EndPlanner.Controllers
{
	[Route("api/nbp-apis")]
	public class NBPController : BaseController
	{
		[HttpGet]
		[Route("eu")]
		public async Task<ActionResult<ICollection<GetEuropeanExchangesVm>>> GetMemberTripsCarsVm()
		{
			var response = await Mediator.Send(new GetEuropeanExchangesVm());
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