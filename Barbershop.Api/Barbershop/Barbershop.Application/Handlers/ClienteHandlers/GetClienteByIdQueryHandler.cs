using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using Barbershop.Application.Interfaces;
using Barbershop.Application.Query.Request.GetClienteRequestQuery;
using Barbershop.Application.Query.Validators;
using Barbershop.Application.Query.ViewModels;
using MediatR;

namespace Barbershop.Application.Handlers.ClienteHandlers;
public class GetClienteByIdQueryHandler : IRequestHandler<GetClienteByIdQuery, Result<ClienteViewModel>>
{
    private readonly IClienteService _repo;
    private readonly GetClienteByIdQueryValidator _validator;

    public GetClienteByIdQueryHandler(IClienteService repo, GetClienteByIdQueryValidator validator)
    {
        _repo = repo;
        _validator = validator;
    }
    public async Task<Result<ClienteViewModel>> Handle(GetClienteByIdQuery request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return Result<ClienteViewModel>.Invalid(validationResult.AsErrors());

        var cliente = await _repo.Get(request.Id);

        if (cliente == null)
            return Result<ClienteViewModel>.NotFound();

        return Result<ClienteViewModel>.Success(cliente);
    }
}
