using Barbershop.Application.Command.Request.ClienteRequestCommand;
using FluentValidation;
namespace Barbershop.Application.Command.Validators.ClienteValidator;
public class UpdateClienteCommandValidator : AbstractValidator<UpdateClienteCommand>
{
    public UpdateClienteCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty()
            .WithMessage("O Id é obrigatório!");

        RuleFor(c => c.Nome).NotEmpty()
            .WithMessage("O nome é obrigatório!");

        RuleFor(c => c.CPF)
               .NotEmpty().WithMessage("O CPF é obrigatório!")
               .Matches(@"^\d{11}$").WithMessage("O CPF deve conter exatamente 11 dígitos numéricos!");

        RuleFor(c => c.Email).NotEmpty()
            .WithMessage("O Email é obrigatório");

        RuleFor(c => c.Celular).NotEmpty()
            .WithMessage("O Celular é obrigatório");
    }
}
