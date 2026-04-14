using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using Barbershop.Application.Command.Request.ProfissionalRequestCommand;
using Barbershop.Application.Command.Validators.ProfissionalValidator;
using Barbershop.Application.Interfaces;
using MediatR;

namespace Barbershop.Application.Handlers.ProfissionalHandlers;
public class DeleteProfissionalCommandHandler : IRequestHandler<DeleteProfissionalCommand, Result>
{
    private readonly IProfissionalService _repo;
    private readonly DeleteProfissionalCommandValidator _validator;
    private readonly IMediator _mediator;

    public DeleteProfissionalCommandHandler(IProfissionalService repo,
        DeleteProfissionalCommandValidator validator, IMediator mediator)
    {
        _repo = repo;
        _validator = validator;
        _mediator = mediator;
    }

    public async Task<Result> Handle(DeleteProfissionalCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return Result.Invalid(validationResult.AsErrors());

        var profissional = await _repo.Get(request.Id);
        if (profissional == null)
            return Result.NotFound($"Nenhum registro encontrado pelo Id: {request.Id}");

        await _repo.Delete(profissional.Id);
        return Result.SuccessWithMessage("Removido com sucesso!");
    }
}
