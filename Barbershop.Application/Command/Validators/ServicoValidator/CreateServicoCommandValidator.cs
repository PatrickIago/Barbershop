using Barbershop.Application.Command.Request.ServicoRequestCommand;
using FluentValidation;
namespace Barbershop.Application.Command.Validators.ServicoValidator;
public class CreateServicoCommandValidator : AbstractValidator<CreateServicoCommand>
{
    public CreateServicoCommandValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("O nome é obrigatório.")
            .MinimumLength(3).WithMessage("O nome deve ter pelo menos 3 caracteres.")
            .MaximumLength(50).WithMessage("O nome deve ter no máximo 50 caracteres.");

        RuleFor(x => x.Preco)
            .GreaterThan(0).WithMessage("O preço deve ser maior que zero.")
            .LessThanOrEqualTo(9999.99m).WithMessage("O preço não pode ultrapassar 9999.99.");

        RuleFor(x => x.Duracao)
            .GreaterThan(TimeSpan.FromMinutes(5)).WithMessage("A duração mínima é de 5 minutos.")
            .LessThanOrEqualTo(TimeSpan.FromHours(4)).WithMessage("A duração máxima é de 4 horas.");
    }
}
