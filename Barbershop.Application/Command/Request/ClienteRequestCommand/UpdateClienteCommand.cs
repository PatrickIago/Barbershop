using Ardalis.Result;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Barbershop.Application.Command.Request.ClienteRequestCommand;
public class UpdateClienteCommand : IRequest<Result>
{
    [Required]
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Nome { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Celular { get; set; }
    [Required]
    public string CPF { get; set; }
    public DateTime DataCadastro { get; set; } = DateTime.Now;
}
