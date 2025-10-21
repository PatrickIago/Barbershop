using Ardalis.Result;
using Barbershop.Application.Query.ViewModels;
using MediatR;

namespace Barbershop.Application.Query.Request.ProfissionalRequest;
public class GetProfissionalByIdQuery : IRequest<Result<ProfissionalViewModel>>
{
    public GetProfissionalByIdQuery(int id)
    {
        Id = id; ;
    }

    public int Id { get; set; }
}
