using FluentValidation;

namespace ExampleWPFValidation
{
    public class PersonValidator : AbstractValidator<Person>, IValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty();
            RuleFor(c => c.FirstName).MaximumLength(12).WithMessage("Too many characters.");
            RuleFor(c => c.LastName).NotEmpty();
            RuleFor(c => c.LastName).MaximumLength(12).WithMessage("Too many characters.");
        }
    }
}
