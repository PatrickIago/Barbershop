using Ardalis.Result;
using MediatR;
namespace Barbershop.Application.Command.Request.ProfissionalRequestCommand;
public class DeleteProfissionalCommand : IRequest<Result>
{
    public DeleteProfissionalCommand(int id) => Id = id;
    public int Id { get; set; }

}
