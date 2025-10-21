using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using Barbershop.Application.Command.Request.ClienteRequestCommand;
using Barbershop.Application.Command.Validators.ClienteValidator;
using Barbershop.Application.Interfaces;
using Barbershop.Domain.Entities;
using MediatR;
namespace Barbershop.Application.Handlers.ClienteHandlers;

public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, Result>
{
    private readonly IClienteService _repo;
    private readonly UpdateClienteCommandValidator _validator;
    private readonly IMediator _mediator;

    public UpdateClienteCommandHandler(IClienteService repo, UpdateClienteCommandValidator validator, IMediator mediator)
    {
        _repo = repo;
        _validator = validator;
        _mediator = mediator;
    }

    public async Task<Result> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return Result.Invalid(validationResult.AsErrors());

        var cliente = await _repo.Get(request.Id);
        if (cliente == null)
            return Result.NotFound($"Nenhum registro encontrado pelo Id: {request.Id}");

        var entity = new Cliente(request.Nome, request.Email, request.Celular, request.CPF);
        entity.SetClienteId(request.Id);

        var success = await _repo.Update(entity);

        if (!success)
        {
            return Result.Error($"Falha ao atualizar o registro com Id: {request.Id}");
        }

        return Result.SuccessWithMessage("Atualizado com sucesso!");

    }
}
