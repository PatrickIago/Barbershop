using Ardalis.Result;
using Barbershop.Application.Query.ViewModels;
using MediatR;

namespace Barbershop.Application.Query.Request.GetServicoRequestQuery;
public class GetServicoQuery : IRequest<Result<List<ServicoViewModel>>>
{
    public GetServicoQuery()
    {

    }
}
