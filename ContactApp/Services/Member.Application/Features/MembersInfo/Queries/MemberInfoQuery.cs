using MediatR;
using Member.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Member.Application.Features.MembersInfo.Queries
{
    public class MemberInfoQuery : IRequest<List<MemberInfo>>
    {
        public MemberInfoQuery() { }
    }
}
