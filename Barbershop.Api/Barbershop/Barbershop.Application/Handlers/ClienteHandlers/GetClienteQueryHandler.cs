using Ardalis.Result;
using Barbershop.Application.Interfaces;
using Barbershop.Application.Query.Request.GetClienteRequestQuery;
using Barbershop.Application.Query.ViewModels;
using MediatR;

namespace Barbershop.Application.Handlers.ClienteHandlers;
public class GetClienteQueryHandler : IRequestHandler<GetClienteQuery, Result<List<ClienteViewModel>>>
{
    private readonly IClienteService _repo;

    public GetClienteQueryHandler(IClienteService repo)
    {
        _repo = repo;
    }
    public async Task<Result<List<ClienteViewModel>>> Handle(GetClienteQuery request, CancellationToken cancellationToken)
    {
        var clientes = await _repo.Get();

        if (clientes == null || !clientes.Any())
            return Result<List<ClienteViewModel>>.NotFound();

        return Result<List<ClienteViewModel>>.Success(clientes);
    }
}
