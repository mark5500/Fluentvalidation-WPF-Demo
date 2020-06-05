using FluentValidation;

namespace ExampleWPFValidation
{
    public class PetValidator : AbstractValidator<Pet>, IValidator<Pet>
    {
        public PetValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).MaximumLength(12).WithMessage("Too many characters.");
        }
    }
}
