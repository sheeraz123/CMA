using MediatR;
using Member.Domain.Entities;


namespace Member.Application.Features.MembersInfo.Queries.GetMemberById
{
	public class MemberByIdQuery : IRequest<MemberInfo>
	{
		public int Id { get; set; }
	}
}
