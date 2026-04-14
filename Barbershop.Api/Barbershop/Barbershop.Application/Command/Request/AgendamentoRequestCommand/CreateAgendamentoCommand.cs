using Ardalis.Result;
using Barbershop.Application.Command.Response;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Barbershop.Application.Command.Request.AgendamentoRequestCommand;
public class CreateAgendamentoCommand : IRequest<Result<CreateAgendamentoResponse>>
{
    [Required]
    public DateTime DataHora { get; set; }
    [Required]
    public int ServicoId { get; set; }
    [Required]
    public int ProfissionalId { get; set; }
    [Required]
    public int ClienteId { get; set; }
}
