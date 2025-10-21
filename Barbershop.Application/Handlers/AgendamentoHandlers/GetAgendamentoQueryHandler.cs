using Ardalis.Result;
using Barbershop.Application.Interfaces;
using Barbershop.Application.Query.Request.GetAgendamentoRequestQuery;
using Barbershop.Application.Query.ViewModels;
using MediatR;
namespace Barbershop.Application.Handlers.AgendamentoHandlers;
public class GetAgendamentoQueryHandler : IRequestHandler<GetAgendamentoQuery, Result<List<AgendamentoViewModel>>>
{
    private readonly IAgendamentoService _repo;

    public GetAgendamentoQueryHandler(IAgendamentoService repo)
    {
        _repo = repo;
    }

    public async Task<Result<List<AgendamentoViewModel>>> Handle(GetAgendamentoQuery request, CancellationToken cancellationToken)
    {
        var agendamentos = await _repo.Get();

        if (agendamentos == null || !agendamentos.Any())
            return Result<List<AgendamentoViewModel>>.NotFound();

        return Result<List<AgendamentoViewModel>>.Success(agendamentos);
    }
}
