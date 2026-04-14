using Ardalis.Result;
using Barbershop.Application.Query.ViewModels;
using MediatR;

namespace Barbershop.Application.Query.Request.ProfissionalRequest;
public class GetProfissionalQuery : IRequest<Result<List<ProfissionalViewModel>>>
{
    public GetProfissionalQuery()
    {
    }
}
