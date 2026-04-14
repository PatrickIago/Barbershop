using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using Barbershop.Application.Command.Request.AgendamentoRequestCommand;
using Barbershop.Application.Command.Validators.AgendamentoValidator;
using Barbershop.Application.Interfaces;
using MediatR;

namespace Barbershop.Application.Handlers.AgendamentoHandlers;
public class DeleteAgendamentoCommandHandler : IRequestHandler<DeleteAgendamentoCommand, Result>
{
    private readonly IAgendamentoService _repo;
    private readonly DeleteAgendamentoCommandValidator _validator;
    private readonly IMediator _mediator;

    public DeleteAgendamentoCommandHandler(IAgendamentoService repo,
        DeleteAgendamentoCommandValidator validator, IMediator mediator)
    {
        _repo = repo;
        _validator = validator;
        _mediator = mediator;
    }

    public async Task<Result> Handle(DeleteAgendamentoCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return Result.Invalid(validationResult.AsErrors());

        var agendamento = await _repo.Get(request.Id);
        if (agendamento == null)
            return Result.NotFound($"Nenhum registro encontrado pelo Id: {request.Id}");

        await _repo.Delete(agendamento.Id);
        return Result.SuccessWithMessage("Removido com sucesso!");
    }
}
