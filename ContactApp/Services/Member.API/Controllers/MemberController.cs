using MediatR;
using Member.Application.Features.MembersInfo.Command.CreateMember;
using Member.Application.Features.MembersInfo.Command.DeleteMember;
using Member.Application.Features.MembersInfo.Command.UpdateMember;
using Member.Application.Features.MembersInfo.Queries;
using Member.Application.Features.MembersInfo.Queries.GetMemberById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Member.API.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]/")]
	[Produces("application/json")]
	[Consumes("application/json")]
	public class MemberController : ControllerBase
	{
		private readonly IMediator mediator;
		private readonly ILogger<MemberController> logger;

		public MemberController(IMediator mediator, ILogger<MemberController> logger)
		{
			this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
			this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult> GetMemberDetails()
		{
			MemberInfoQuery query = new MemberInfoQuery();
			logger.LogInformation($"Controller : MemberController, MethodName : Get Start");
			var result = await mediator.Send(query);
			return Ok(result);

		}
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult> Post([FromBody] CreateMemberCommand request)
		{
			logger.LogInformation($"Controller : MemberController, MethodName : Post Start");
			var result = await mediator.Send(request);
			return Ok(result);

		}
		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult> Put([FromBody] UpdateMemberCommand request)
		{
			logger.LogInformation($"Controller : MemberController, MethodName : Put Start");
			var result = await mediator.Send(request);
			return Ok(result);

		}
		[HttpDelete]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult> Delete(int id)
		{
			var command = new DeleteMemberCommand() { Id = id };
			logger.LogInformation($"Controller : MemberController, MethodName : Delete Start");
			var result = await mediator.Send(command);
			return Ok(result);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesDefaultResponseType]
		public async Task<ActionResult> memberDetailById(int id)
		{
			var command = new MemberByIdQuery() { Id = id };
			logger.LogInformation($"Controller : MemberController, MethodName : memberDetailById Start");
			var result = await mediator.Send(command);
			return Ok(result);

		}
	}
}
