using Barbershop.Application.Command.Request.AgendamentoRequestCommand;
using FluentValidation;

namespace Barbershop.Application.Command.Validators.AgendamentoValidator;
public class CreateAgendamentoCommandValidator : AbstractValidator<CreateAgendamentoCommand>
{
    public CreateAgendamentoCommandValidator()
    {
        RuleFor(x => x.DataHora)
            .NotEmpty()
            .WithMessage("A data deve ser informada!")
            .Must(d => d > DateTime.Now)
            .WithMessage("A data/hora do agendamento deve ser futura.");

        RuleFor(x => x.ServicoId)
            .NotEmpty()
            .WithMessage("O Id do serviço deve ser informado!");

        RuleFor(x => x.ProfissionalId)
            .NotEmpty()
            .WithMessage("O Id do Profissional deve ser informado!");

        RuleFor(x => x.ClienteId)
            .NotEmpty()
            .WithMessage("O Id do cliente deve ser informado!");
    }
}
