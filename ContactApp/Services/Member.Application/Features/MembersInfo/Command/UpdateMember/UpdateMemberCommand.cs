using MediatR;
using Member.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Member.Application.Features.MembersInfo.Command.UpdateMember
{
    public class UpdateMemberCommand : IRequest<List<MemberInfo>>
    {
        public UpdateMemberCommand(string firstName, string lastName, string email, int id)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Id = id;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
