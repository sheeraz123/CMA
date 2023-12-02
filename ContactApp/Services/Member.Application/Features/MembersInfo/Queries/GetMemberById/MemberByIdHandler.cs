using AutoMapper;
using MediatR;
using Member.Application.Contracts.Persistence;
using Member.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Member.Application.Features.MembersInfo.Queries.GetMemberById
{
	public class MemberByIdHandler : IRequestHandler<MemberByIdQuery, MemberInfo>
	{
		private readonly IMemberRepository memberRepository;
		private readonly IMapper _mapper;

		public MemberByIdHandler(IMemberRepository memberRepository, IMapper mapper)
		{
			this.memberRepository = memberRepository ?? throw new ArgumentNullException(nameof(memberRepository));
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		public async Task<MemberInfo> Handle(MemberByIdQuery request, CancellationToken cancellationToken)
		{
			var result = await memberRepository.GetByIdAsync(request.Id);
			return _mapper.Map<MemberInfo>(result);
		}
	}
}

