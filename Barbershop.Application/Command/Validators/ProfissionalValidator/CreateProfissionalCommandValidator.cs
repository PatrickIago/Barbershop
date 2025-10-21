using Barbershop.Application.Command.Request.ProfissionalRequestCommand;
using FluentValidation;
namespace Barbershop.Application.Command.Validators.ProfissionalValidator;
public class CreateProfissionalCommandValidator : AbstractValidator<CreateProfissionalCommand>
{
    public CreateProfissionalCommandValidator()
    {
        RuleFor(p => p.Nome)
            .NotEmpty().WithMessage("O nome é obrigatório!")
            .MaximumLength(100)
            .WithMessage("O nome deve ter no maximo 100 caracteres!");

        RuleFor(p => p.CPF)
                .NotEmpty().WithMessage("O CPF é obrigatório!")
                .Matches(@"^\d{11}$").WithMessage("O CPF deve conter exatamente 11 dígitos numéricos!");

        RuleFor(p => p.Celular).NotEmpty().WithMessage("O Celular é obrigadtório");

    }
}
