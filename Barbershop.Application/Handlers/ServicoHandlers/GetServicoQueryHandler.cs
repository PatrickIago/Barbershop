using Ardalis.Result;
using Barbershop.Application.Interfaces;
using Barbershop.Application.Query.Request.GetServicoRequestQuery;
using Barbershop.Application.Query.ViewModels;
using MediatR;
namespace Barbershop.Application.Handlers.ServicoHandlers;

public class GetServicoQueryHandler : IRequestHandler<GetServicoQuery, Result<List<ServicoViewModel>>>
{
    private readonly IServicoService _repo;

    public GetServicoQueryHandler(IServicoService repo)
    {
        _repo = repo;
    }

    public async Task<Result<List<ServicoViewModel>>> Handle(GetServicoQuery request, CancellationToken cancellationToken)
    {
        var servicos = await _repo.Get();

        if (servicos == null || !servicos.Any())
            return Result<List<ServicoViewModel>>.NotFound();

        return Result<List<ServicoViewModel>>.Success(servicos);
    }
}
