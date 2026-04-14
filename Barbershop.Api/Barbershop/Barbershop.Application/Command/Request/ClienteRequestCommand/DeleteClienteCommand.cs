using Ardalis.Result;
using MediatR;
namespace Barbershop.Application.Command.Request.ClienteRequestCommand;
public class DeleteClienteCommand : IRequest<Result>
{
    public DeleteClienteCommand(int id) => Id = id;
    public int Id { get; set; }
}
