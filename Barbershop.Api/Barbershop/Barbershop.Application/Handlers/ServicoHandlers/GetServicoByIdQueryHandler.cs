using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using Barbershop.Application.Interfaces;
using Barbershop.Application.Query.Request.GetServicoRequestQuery;
using Barbershop.Application.Query.Validators;
using Barbershop.Application.Query.ViewModels;
using MediatR;

namespace Barbershop.Application.Handlers.ServicoHandlers;
public class GetServicoByIdQueryHandler : IRequestHandler<GetServicoByIdQuery, Result<ServicoViewModel>>
{
    private readonly IServicoService _repo;
    private readonly GetServicoByIdQueryValidator _validator;

    public GetServicoByIdQueryHandler(IServicoService repo, GetServicoByIdQueryValidator validator)
    {
        _repo = repo;
        _validator = validator;
    }

    public async Task<Result<ServicoViewModel>> Handle(GetServicoByIdQuery request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return Result<ServicoViewModel>.Invalid(validationResult.AsErrors());

        var servico = await _repo.Get(request.Id);

        if (servico == null)
            return Result<ServicoViewModel>.NotFound();

        return Result<ServicoViewModel>.Success(servico);
    }
}
