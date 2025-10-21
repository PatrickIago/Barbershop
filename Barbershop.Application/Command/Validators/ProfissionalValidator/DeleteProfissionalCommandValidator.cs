using Barbershop.Application.Command.Request.ProfissionalRequestCommand;
using FluentValidation;

namespace Barbershop.Application.Command.Validators.ProfissionalValidator;
public class DeleteProfissionalCommandValidator : AbstractValidator<DeleteProfissionalCommand>
{
    public DeleteProfissionalCommandValidator()
    {
        RuleFor(p => p.Id).NotEmpty().WithMessage("O Id deve ser informado!");
    }
}
