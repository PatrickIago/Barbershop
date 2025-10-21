using Ardalis.Result;
using Barbershop.Application.Query.ViewModels;
using MediatR;

namespace Barbershop.Application.Query.Request.GetClienteRequestQuery;
public class GetClienteByIdQuery : IRequest<Result<ClienteViewModel>>
{
    public GetClienteByIdQuery(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
}
