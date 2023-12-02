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

namespace Member.Application.Features.MembersInfo.Command.UpdateMember
{
    public class UpdateMemberHandler : IRequestHandler<UpdateMemberCommand, List<MemberInfo>>
    {
        private readonly IMemberRepository memberRepository;
        private readonly ILogger<UpdateMemberHandler> logger;
        private readonly IMapper mapper;

        public UpdateMemberHandler(IMemberRepository memberRepository, ILogger<UpdateMemberHandler> logger, IMapper mapper)
        {
            this.memberRepository = memberRepository ?? throw new ArgumentNullException(nameof(memberRepository));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.mapper = mapper;
        }

        public async Task<List<MemberInfo>> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
        {
            var memberInfo = mapper.Map<MemberInfo>(request);
            var response = await memberRepository.UpdateAsync(memberInfo);
            return mapper.Map<List<MemberInfo>>(response);
        }
    }
}
