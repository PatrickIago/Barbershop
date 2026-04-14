using Barbershop.Application.Command.Request.ServicoRequestCommand;
using FluentValidation;
namespace Barbershop.Application.Command.Validators.ServicoValidator;
public class DeleteServicoCommandValidator : AbstractValidator<DeleteServicoCommand>
{
    public DeleteServicoCommandValidator()
    {
        RuleFor(s => s.Id).NotEmpty().WithMessage("O Id deve ser informado!");
    }
}
