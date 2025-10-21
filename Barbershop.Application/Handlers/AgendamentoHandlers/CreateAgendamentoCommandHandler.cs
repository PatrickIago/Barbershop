using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using Barbershop.Application.Command.Request.AgendamentoRequestCommand;
using Barbershop.Application.Command.Response;
using Barbershop.Application.Command.Validators.AgendamentoValidator;
using Barbershop.Application.Interfaces;
using Barbershop.Domain.Entities;
using Barbershop.Domain.Events;
using MediatR;

namespace Barbershop.Application.Handlers.AgendamentoHandlers;

public class CreateAgendamentoCommandHandler : IRequestHandler<CreateAgendamentoCommand, Result<CreateAgendamentoResponse>>
{
    private readonly IAgendamentoService _repo;
    private readonly CreateAgendamentoCommandValidator _validator;
    private readonly IMediator _mediator;

    public CreateAgendamentoCommandHandler(IAgendamentoService  repo, IMediator mediator, CreateAgendamentoCommandValidator validator)
    {
        _repo = repo;
        _validator = validator;
        _mediator = mediator;
    }
    public async Task<Result<CreateAgendamentoResponse>> Handle(CreateAgendamentoCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return Result.Invalid(validationResult.AsErrors());

        var entity = new Agendamento(request.DataHora, request.ServicoId, request.ProfissionalId, request.ClienteId);

        await _repo.Create(entity);

        await _mediator.Publish(new AgendamentoCriadoEvent(entity.Id, entity.ClienteId, entity.DataHora), cancellationToken);

        return Result.Success(new CreateAgendamentoResponse(entity.Id), "Cadastrado com sucesso!");

    }
}
