using AutoMapper;
using MediatR;
using Member.Application.Contracts.Persistence;
using Member.Domain.Entities;

namespace Member.Application.Features.MembersInfo.Queries
{
    public class MemberInfoHandler : IRequestHandler<MemberInfoQuery, List<MemberInfo>>
    {
        private readonly IMemberRepository memberRepository;
        private readonly IMapper _mapper;

        public MemberInfoHandler(IMemberRepository memberRepository, IMapper mapper)
        {
            this.memberRepository = memberRepository ?? throw new ArgumentNullException(nameof(memberRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<MemberInfo>> Handle(MemberInfoQuery request, CancellationToken cancellationToken)
        {
            var result = await memberRepository.GetAllAsync();
            return _mapper.Map<List<MemberInfo>>(result);
        }
    }
}
