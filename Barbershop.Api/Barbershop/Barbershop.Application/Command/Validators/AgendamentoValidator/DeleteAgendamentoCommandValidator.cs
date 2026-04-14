using Barbershop.Application.Command.Request.AgendamentoRequestCommand;
using FluentValidation;
namespace Barbershop.Application.Command.Validators.AgendamentoValidator;
public class DeleteAgendamentoCommandValidator : AbstractValidator<DeleteAgendamentoCommand>
{
    public DeleteAgendamentoCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("O Id deve ser informado!");
    }
}
