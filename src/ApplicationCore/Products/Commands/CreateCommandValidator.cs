using FluentValidation;

namespace ApplicationCore.Products.Commands;

public sealed class CreateCommandValidator : AbstractValidator<CreateCommand>
{
    public CreateCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Currency).NotEmpty();
        RuleFor(x => x.Price).NotEmpty();
    }
}
