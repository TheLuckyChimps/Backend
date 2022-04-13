using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TPL.Data.Dtos;
using TPL.Data.Entities;

namespace TPL.Data.Validations
{
    public class UserValidator : AbstractValidator<UserCreateDto>
    {
        public UserValidator()
        {
            //RuleFor(x => x.).notnull();
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("Is your first name that long?")
    .NotEmpty().MinimumLength(3);
            RuleFor(x => x.Email).EmailAddress().NotEmpty();
            RuleFor(x => x.Surname).MaximumLength(20).WithMessage("Is your first surname that long?")
    .NotEmpty().MinimumLength(3);
            RuleFor(x => x.Address).Length(3, 100).NotEmpty();
            RuleFor(x => x.Password).NotEmpty().Must(x => HasValidPassword(x)).WithMessage("Passwords invalid. It must contain atleast a capital letter, numbers and atleast a special character"); ;
        }

        private bool HasValidPassword(string pw)
        {
            var lowercase = new Regex("[a-z]+");
            var uppercase = new Regex("[A-Z]+");
            var digit = new Regex("(\\d)+");
            var symbol = new Regex("(\\W)+");

            return (lowercase.IsMatch(pw) && uppercase.IsMatch(pw) && digit.IsMatch(pw) && symbol.IsMatch(pw));
        }
    }
}
