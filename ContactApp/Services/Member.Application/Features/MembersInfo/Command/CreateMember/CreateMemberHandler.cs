using AutoMapper;
using MediatR;
using Member.Application.Contracts.Persistence;
using Member.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Member.Application.Features.MembersInfo.Command.CreateMember
{
    public class CreateMemberHandler : IRequestHandler<CreateMemberCommand, MemberInfo>
    {
        private readonly IMemberRepository memberRepository;
        private readonly ILogger<CreateMemberHandler> logger;
        private readonly IMapper mapper;

        public CreateMemberHandler(IMemberRepository memberRepository, ILogger<CreateMemberHandler> logger, IMapper mapper)
        {
            this.memberRepository = memberRepository ?? throw new ArgumentNullException(nameof(memberRepository));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.mapper = mapper;
        }

        public async Task<MemberInfo> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            var memberInfo = mapper.Map<MemberInfo>(request);
            var response = await memberRepository.AddAsync(memberInfo);
            return mapper.Map<MemberInfo>(response);
        }
    }
}
