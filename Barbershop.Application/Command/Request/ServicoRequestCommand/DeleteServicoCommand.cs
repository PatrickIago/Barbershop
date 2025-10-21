using Ardalis.Result;
using MediatR;
namespace Barbershop.Application.Command.Request.ServicoRequestCommand;
public class DeleteServicoCommand : IRequest<Result>
{
    public DeleteServicoCommand(int id) => Id = id;
    public int Id { get; set; }
}
