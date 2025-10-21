using Ardalis.Result;
using MediatR;

namespace Barbershop.Application.Command.Request.AgendamentoRequestCommand;
public class DeleteAgendamentoCommand : IRequest<Result>
{
    public DeleteAgendamentoCommand(int id) => Id = id;
    public int Id { get; set; }
}
