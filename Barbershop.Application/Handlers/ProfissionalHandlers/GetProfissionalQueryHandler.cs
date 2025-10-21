using Ardalis.Result;
using Barbershop.Application.Interfaces;
using Barbershop.Application.Query.Request.ProfissionalRequest;
using Barbershop.Application.Query.ViewModels;
using MediatR;

namespace Barbershop.Application.Handlers.ProfissionalHandlers;
public class GetProfissionalQueryHandler : IRequestHandler<GetProfissionalQuery, Result<List<ProfissionalViewModel>>>
{
    private readonly IProfissionalService _repo;

    public GetProfissionalQueryHandler(IProfissionalService repo)
    {
        _repo = repo;
    }
    public async Task<Result<List<ProfissionalViewModel>>> Handle(GetProfissionalQuery request, CancellationToken cancellationToken)
    {
        var profissionais = await _repo.Get();

        if (profissionais == null || !profissionais.Any())
            return Result<List<ProfissionalViewModel>>.NotFound();

        return Result<List<ProfissionalViewModel>>.Success(profissionais);
    }
}

