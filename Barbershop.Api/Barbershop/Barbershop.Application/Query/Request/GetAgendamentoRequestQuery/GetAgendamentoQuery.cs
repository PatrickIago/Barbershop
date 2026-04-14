using Ardalis.Result;
using Barbershop.Application.Query.ViewModels;
using MediatR;
namespace Barbershop.Application.Query.Request.GetAgendamentoRequestQuery;

public class GetAgendamentoQuery : IRequest<Result<List<AgendamentoViewModel>>>
{
    public GetAgendamentoQuery()
    { }
}
