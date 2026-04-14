using Ardalis.Result;
using Barbershop.Application.Command.Response;
using MediatR;
using System.ComponentModel.DataAnnotations;
namespace Barbershop.Application.Command.Request.ClienteRequestCommand;
public class CreateClienteCommand : IRequest<Result<CreateClienteResponse>>
{
    [Required]
    [MaxLength(100)]
    public string Nome { get; set; }
    [Required]
    [MaxLength(100)]
    public string Email { get; set; }
    [Required]
    [MaxLength(100)]
    public string Celular { get; set; }
    [Required]
    [MaxLength(100)]
    public string CPF { get; set; }
    public DateTime DataCadastro { get; set; } = DateTime.Now;
}
