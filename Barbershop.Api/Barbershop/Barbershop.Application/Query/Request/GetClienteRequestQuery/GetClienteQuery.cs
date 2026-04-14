using Ardalis.Result;
using Barbershop.Application.Query.ViewModels;
using MediatR;

namespace Barbershop.Application.Query.Request.GetClienteRequestQuery;
public class GetClienteQuery : IRequest<Result<List<ClienteViewModel>>>
{
    public GetClienteQuery()
    {
    }
}
