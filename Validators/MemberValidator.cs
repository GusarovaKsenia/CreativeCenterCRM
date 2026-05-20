using CreativeCenterCRM.Models;
using FluentValidation;

namespace CreativeCenterCRM.Validators
{
    public class MemberValidator : AbstractValidator<Member>
    {
        public MemberValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().Length(2, 50);
            RuleFor(x => x.LastName).NotEmpty().Length(2, 50);
            RuleFor(x => x.Phone).NotEmpty().Matches(@"^\+?[0-9]{10,15}$").WithMessage("Неверный формат телефона");
        }
    }
}