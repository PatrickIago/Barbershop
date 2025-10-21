using Ardalis.Result;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Barbershop.Application.Command.Request.ProfissionalRequestCommand;
public class UpdateProfissionalCommand : IRequest<Result>
{
    [Required]
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Nome { get; set; }
    [Required(ErrorMessage = "O CPF é obrigatório.")]
    public string CPF { get; set; }
    [Required]
    public string Celular { get; set; }
    public bool Ativo { get; set; }
}
