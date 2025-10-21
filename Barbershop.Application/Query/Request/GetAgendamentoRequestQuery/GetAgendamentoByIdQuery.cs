using Ardalis.Result;
using Barbershop.Application.Query.ViewModels;
using MediatR;
namespace Barbershop.Application.Query.Request.GetAgendamentoRequestQuery;

public class GetAgendamentoByIdQuery : IRequest<Result<AgendamentoViewModel>>
{
    public GetAgendamentoByIdQuery(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
}
