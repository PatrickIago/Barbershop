using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using Barbershop.Application.Command.Request.AgendamentoRequestCommand;
using Barbershop.Application.Command.Validators.AgendamentoValidator;
using Barbershop.Application.Interfaces;
using Barbershop.Domain.Entities;
using MediatR;

namespace Barbershop.Application.Handlers.AgendamentoHandlers;
public class UpdateAgendamentoCommandHandler : IRequestHandler<UpdateAgendamentoCommand, Result>
{
    private readonly IAgendamentoService _repo;
    private readonly UpdateAgendamentoCommandValidator _validator;
    private readonly IMediator _mediator;

    public UpdateAgendamentoCommandHandler(IAgendamentoService repo, UpdateAgendamentoCommandValidator validator, IMediator mediator)
    {
        _repo = repo;
        _validator = validator;
        _mediator = mediator;
    }

    public async Task<Result> Handle(UpdateAgendamentoCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return Result.Invalid(validationResult.AsErrors());

        var agendamento = await _repo.Get(request.Id);
        if (agendamento == null)
            return Result.NotFound($"Nenhum registro encontrado pelo Id: {request.Id}");

        var entity = new Agendamento(request.DataHora, request.ServicoId, request.ProfissionalId, request.ClienteId);
        entity.SetAgendamentoId(request.Id);

        var success = await _repo.Update(entity);

        if (!success)
        {
            return Result.Error($"Falha ao atualizar o registro com Id: {request.Id}");
        }

        return Result.SuccessWithMessage("Atualizado com sucesso!");

    }
}
