using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using Barbershop.Application.Interfaces;
using Barbershop.Application.Query.Request.GetAgendamentoRequestQuery;
using Barbershop.Application.Query.Validators;
using Barbershop.Application.Query.ViewModels;
using MediatR;
namespace Barbershop.Application.Handlers.AgendamentoHandlers;

internal class GetAgendamentoByIdQueryHandler : IRequestHandler<GetAgendamentoByIdQuery, Result<AgendamentoViewModel>>
{
    private readonly IAgendamentoService _repo;
    private readonly GetAgendamentoByIdQueryValidator _validator;

    public GetAgendamentoByIdQueryHandler(IAgendamentoService repo, GetAgendamentoByIdQueryValidator validator)
    {
        _repo = repo;
        _validator = validator;
    }
    public async Task<Result<AgendamentoViewModel>> Handle(GetAgendamentoByIdQuery request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return Result<AgendamentoViewModel>.Invalid(validationResult.AsErrors());

        var agendamento = await _repo.Get(request.Id);

        if (agendamento == null)
            return Result<AgendamentoViewModel>.NotFound();

        return Result<AgendamentoViewModel>.Success(agendamento);
    }
}
