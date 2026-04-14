using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using Barbershop.Application.Command.Request.ClienteRequestCommand;
using Barbershop.Application.Command.Response;
using Barbershop.Application.Command.Validators.ClienteValidator;
using Barbershop.Application.Interfaces;
using Barbershop.Domain.Entities;
using MediatR;
namespace Barbershop.Application.Handlers.ClienteHandlers;
public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, Result<CreateClienteResponse>>
{
    private readonly IClienteService _repo;
    private readonly CreateClienteCommandValidator _validator;
    private readonly IMediator _mediator;

    public CreateClienteCommandHandler(IClienteService repo,
        CreateClienteCommandValidator validator, IMediator mediator)
    {
        _repo = repo;
        _validator = validator;
        _mediator = mediator;
    }

    public async Task<Result<CreateClienteResponse>> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return Result.Invalid(validationResult.AsErrors());

        var entity = new Cliente(request.Nome, request.Email, request.Celular, request.CPF);

        await _repo.Create(entity);

        return Result.Success(new CreateClienteResponse(entity.Id), "Cadastrado com sucesso!");
    }
}

