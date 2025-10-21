using Barbershop.Application.Query.Request.ProfissionalRequest;
using FluentValidation;

namespace Barbershop.Application.Query.Validators;
public class GetProfissionalByIdQueryValidator : AbstractValidator<GetProfissionalByIdQuery>
{
    public GetProfissionalByIdQueryValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty()
            .WithMessage("O Id não pode estar vazio");
    }
}
