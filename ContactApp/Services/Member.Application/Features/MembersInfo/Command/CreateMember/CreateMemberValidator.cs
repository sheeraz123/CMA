using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Member.Application.Features.MembersInfo.Command.CreateMember
{
    public class CreateMemberValidator : AbstractValidator<CreateMemberCommand>
    {
        public CreateMemberValidator() {
            RuleFor(x => x.FirstName).NotEmpty().WithErrorCode(HttpStatusCode.BadRequest.ToString()).WithMessage("First name is required");
            RuleFor(x => x.LastName).NotEmpty().WithErrorCode(HttpStatusCode.BadRequest.ToString()).WithMessage("Last name is required");
            RuleFor(x => x.Email).NotEmpty().WithErrorCode(HttpStatusCode.BadRequest.ToString()).WithMessage("Email is required").EmailAddress().WithErrorCode(HttpStatusCode.BadRequest.ToString()).WithMessage("Invalid Email id");
        }
    }
}
