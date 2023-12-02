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

namespace Member.Application.Features.MembersInfo.Command.DeleteMember
{
    public class DeleteMemberHandler : IRequestHandler<DeleteMemberCommand, bool>
    {
        private readonly IMemberRepository memberRepository;
        private readonly ILogger<DeleteMemberHandler> logger;
        private readonly IMapper mapper;

        public DeleteMemberHandler(IMemberRepository memberRepository, ILogger<DeleteMemberHandler> logger, IMapper mapper)
        {
            this.memberRepository = memberRepository ?? throw new ArgumentNullException(nameof(memberRepository));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.mapper = mapper;
        }

        public async Task<bool> Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
        {
            var result = await memberRepository.DeleteAsync(request.Id);
            return result;
        }
    }
}
