using Barbershop.Application.Command.Request.ClienteRequestCommand;
using FluentValidation;
namespace Barbershop.Application.Command.Validators.ClienteValidator;
public class DeleteClienteCommandValidator : AbstractValidator<DeleteClienteCommand>
{
    public DeleteClienteCommandValidator()
    {
        RuleFor(p => p.Id).NotEmpty().WithMessage("O Id deve ser informado!");
    }
}
