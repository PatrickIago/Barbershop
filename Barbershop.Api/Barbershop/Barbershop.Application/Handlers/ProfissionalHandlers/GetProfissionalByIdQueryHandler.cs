using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using Barbershop.Application.Interfaces;
using Barbershop.Application.Query.Request.ProfissionalRequest;
using Barbershop.Application.Query.Validators;
using Barbershop.Application.Query.ViewModels;
using MediatR;

namespace Barbershop.Application.Handlers.ProfissionalHandlers;
public class GetProfissionalByIdQueryHandler : IRequestHandler<GetProfissionalByIdQuery, Result<ProfissionalViewModel>>
{
    private readonly IProfissionalService _repo;
    private readonly GetProfissionalByIdQueryValidator _validator;

    public GetProfissionalByIdQueryHandler(IProfissionalService repo, GetProfissionalByIdQueryValidator validator)
    {
        _repo = repo;
        _validator = validator;
    }
    public async Task<Result<ProfissionalViewModel>> Handle(GetProfissionalByIdQuery request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return Result<ProfissionalViewModel>.Invalid(validationResult.AsErrors());


        var profissional = await _repo.Get(request.Id);

        if (profissional == null)
            return Result<ProfissionalViewModel>.NotFound();

        return Result<ProfissionalViewModel>.Success(profissional);

    }
}
