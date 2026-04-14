using Ardalis.Result;
using Barbershop.Application.Command.Response;
using MediatR;
using System.ComponentModel.DataAnnotations;
namespace Barbershop.Application.Command.Request.ProfissionalRequestCommand;

public class CreateProfissionalCommand : IRequest<Result<CreateProfissionalResponse>>
{
    [Required]
    [MaxLength(100)]
    public string Nome { get; set; }
    [Required(ErrorMessage = "O CPF é obrigatório.")]
    public string CPF { get; set; }
    [Required]
    public string Celular { get; set; }
    public bool Ativo { get; set; }
}
