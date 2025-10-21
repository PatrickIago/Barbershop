using Ardalis.Result;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Barbershop.Application.Command.Request.AgendamentoRequestCommand;
public class UpdateAgendamentoCommand : IRequest<Result>
{
    [Required]
    public int Id { get; set; }
    [Required]
    public DateTime DataHora { get; set; }
    [Required]
    public int ServicoId { get; set; }
    [Required]
    public int ProfissionalId { get; set; }
    [Required]
    public int ClienteId { get; set; }
}
