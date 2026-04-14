using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using Barbershop.Application.Command.Request.ClienteRequestCommand;
using Barbershop.Application.Command.Validators.ClienteValidator;
using Barbershop.Application.Interfaces;
using MediatR;
namespace Barbershop.Application.Handlers.ClienteHandlers;
public class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommand, Result>
{
    private readonly IClienteService _repo;
    private readonly DeleteClienteCommandValidator _validator;
    private readonly IMediator _mediator;

    public DeleteClienteCommandHandler(IClienteService repo,
        DeleteClienteCommandValidator validator, IMediator mediator)
    {
        _repo = repo;
        _validator = validator;
        _mediator = mediator;
    }

    public async Task<Result> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return Result.Invalid(validationResult.AsErrors());

        var cliente = await _repo.Get(request.Id);
        if (cliente == null)
            return Result.NotFound($"Nenhum registro encontrado pelo Id: {request.Id}");

        await _repo.Delete(cliente.Id);
        return Result.SuccessWithMessage("Removido com sucesso!");
    }
}
