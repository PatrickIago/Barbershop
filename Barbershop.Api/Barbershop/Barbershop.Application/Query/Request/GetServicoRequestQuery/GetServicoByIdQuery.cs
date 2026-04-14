using Ardalis.Result;
using Barbershop.Application.Query.ViewModels;
using MediatR;

namespace Barbershop.Application.Query.Request.GetServicoRequestQuery;
public class GetServicoByIdQuery : IRequest<Result<ServicoViewModel>>
{
    public GetServicoByIdQuery(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
}
