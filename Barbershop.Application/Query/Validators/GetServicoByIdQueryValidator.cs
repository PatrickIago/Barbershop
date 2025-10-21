using Barbershop.Application.Query.Request.GetServicoRequestQuery;
using FluentValidation;

namespace Barbershop.Application.Query.Validators;
public class GetServicoByIdQueryValidator : AbstractValidator<GetServicoByIdQuery>
{
    public GetServicoByIdQueryValidator()
    {
        RuleFor(s => s.Id).NotEmpty().WithMessage("O Id deve ser informado");
    }
}
