using FluentValidation;
using LoanProject.Domain;
using LoanProject.Models;
using System;

namespace LoanProject.Validation
{
    public class UserValidator : AbstractValidator<UserModel>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName)
    .NotEmpty().WithMessage("name is empty")
    .Length(1, 10).WithMessage("Length is not correct");

            RuleFor(x => x.LastName)
.NotEmpty().WithMessage("name is empty")
.Length(1, 10).WithMessage("Length is not correct");

            RuleFor(x => x.Email)
            .NotNull().WithMessage("email is empty")
            .Length(1, 200).WithMessage("Length is not correct").EmailAddress();
            RuleFor(p => p.Password).NotEmpty().WithMessage("Your password cannot be empty")
                   .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                   .MaximumLength(16).WithMessage("Your password length must not exceed 16.")
                   .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                   .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                   .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
                   .Matches(@"[\!\?\*\.]+").WithMessage("Your password must contain at least one (!? *.).");
        }
    }
}
