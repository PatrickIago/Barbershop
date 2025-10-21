using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using Barbershop.Application.Command.Request.ServicoRequestCommand;
using Barbershop.Application.Command.Validators.ServicoValidator;
using Barbershop.Application.Interfaces;
using MediatR;
namespace Barbershop.Application.Handlers.ServicoHandlers;
public class DeleteServicoCommandHandler : IRequestHandler<DeleteServicoCommand, Result>
{
    private readonly IServicoService _repo;
    private readonly DeleteServicoCommandValidator _validator;
    private readonly IMediator _mediator;

    public DeleteServicoCommandHandler(IServicoService repo, DeleteServicoCommandValidator validator, IMediator mediator)
    {
        _repo = repo;
        _validator = validator;
        _mediator = mediator;
    }

    public async Task<Result> Handle(DeleteServicoCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return Result.Invalid(validationResult.AsErrors());

        var servico = await _repo.Get(request.Id);
        if (servico == null)
            return Result.NotFound($"Nenhum registro encontrado pelo Id: {request.Id}");

        await _repo.Delete(servico.Id);
        return Result.SuccessWithMessage("Removido com sucesso!");

    }
}
