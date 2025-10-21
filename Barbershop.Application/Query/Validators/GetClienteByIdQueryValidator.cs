using Barbershop.Application.Query.Request.GetClienteRequestQuery;
using FluentValidation;

namespace Barbershop.Application.Query.Validators;
public class GetClienteByIdQueryValidator : AbstractValidator<GetClienteByIdQuery>
{
    public GetClienteByIdQueryValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty()
            .WithMessage("O Id não pode estar vazio");
    }
}
