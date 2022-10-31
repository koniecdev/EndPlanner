using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace EndPlanner.Controllers
{
	[EnableCors("MyOrigins")]
	[ApiController]
	public class BaseController : ControllerBase
	{
		private IMediator _mediator;
		protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
	}
}