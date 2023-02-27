using FluentValidation;
using MyAPI2.Application.Dtos;

namespace MyAPI2.Application.Validators
{
    public class PersonValidator : AbstractValidator<PersonDto>
    {
        public PersonValidator()
        {
            RuleFor(p => p.Names).NotEmpty().WithMessage("The 'Names' field is required.");
            RuleFor(p => p.GenderId).NotNull().WithMessage("The 'GenderId' field is required.");
        }
    }
}