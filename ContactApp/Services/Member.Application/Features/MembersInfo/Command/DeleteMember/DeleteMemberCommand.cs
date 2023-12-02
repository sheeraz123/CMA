using MediatR;
using Member.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Member.Application.Features.MembersInfo.Command.DeleteMember
{
    public class DeleteMemberCommand : IRequest<bool>
    {
       

        public int Id { get; set; }
      
    }
}
