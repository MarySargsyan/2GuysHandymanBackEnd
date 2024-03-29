﻿using _2GuysHandyman.ApiModels;
using FluentValidation;

namespace _2GuysHandyman.ApiModelsValidators
{
    public class UsersApiModelValidator : AbstractValidator<UsersApiModel>
    {
        public UsersApiModelValidator()
        {
            RuleFor(u => u.FirstName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50)
                .Must(f => f.All(Char.IsLetter) == true);

            RuleFor(u => u.LastName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50)
                .Must(f => f.All(Char.IsLetter) == true);

            RuleFor(u => u.Email)
                .EmailAddress();

            RuleFor(u => u.Mobile)
                .NotEmpty()
                .MaximumLength(20)
                .Must(m => m.All( c => Char.IsDigit(c)
                    || c == '+'
                    || c == '('
                    || c == ')'
                    || c == '-'
                    || c == ' '
                    )
                == true
                );

            RuleFor(u => u.Adress)
                .NotEmpty()
                .MaximumLength(50)
                .Must(a => a?.All(c => Char.IsLetterOrDigit(c)
                    || c == '/'
                    || c == ' '
                    )
                == true
                );

        }
    }
}
