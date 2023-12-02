using AutoMapper;
using Member.Application.Features.MembersInfo.Command.CreateMember;
using Member.Application.Features.MembersInfo.Command.UpdateMember;
using Member.Application.Features.MembersInfo.Queries;
using Member.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Member.Application.AutoMappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MemberInfo, MemberInfoVM>().ReverseMap();
            CreateMap<MemberInfo, CreateMemberCommand>().ReverseMap();
            CreateMap<MemberInfo, UpdateMemberCommand>().ReverseMap();
        }
    }
}
