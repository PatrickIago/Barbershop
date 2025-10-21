using Barbershop.Application.Query.Request.GetAgendamentoRequestQuery;
using FluentValidation;
namespace Barbershop.Application.Query.Validators;
public class GetAgendamentoByIdQueryValidator : AbstractValidator<GetAgendamentoByIdQuery>
{
    public GetAgendamentoByIdQueryValidator()
    {
        RuleFor(command => command.Id)
           .NotEmpty()
           .WithMessage("O Id não pode estar vazio");
    }
}
