using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using Barbershop.Application.Command.Request.ProfissionalRequestCommand;
using Barbershop.Application.Command.Validators.ProfissionalValidator;
using Barbershop.Application.Interfaces;
using Barbershop.Domain.Entities;
using MediatR;
namespace Barbershop.Application.Handlers.ProfissionalHandlers;
public class UpdateProfissionalCommandHandler : IRequestHandler<UpdateProfissionalCommand, Result>
{
    private readonly IProfissionalService _repo;
    private readonly UpdateProfissionalCommandValidator _validator;
    private readonly IMediator _mediator;

    public UpdateProfissionalCommandHandler(IProfissionalService repo, UpdateProfissionalCommandValidator validator
        , IMediator mediator)
    {
        _repo = repo;
        _validator = validator;
        _mediator = mediator;
    }

    public async Task<Result> Handle(UpdateProfissionalCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return Result.Invalid(validationResult.AsErrors());

        var profissional = await _repo.Get(request.Id);
        if (profissional == null)
            return Result.NotFound($"Nenhum registro encontrado pelo Id: {request.Id}");

        var entity = new Profissional(request.CPF, request.Nome, request.Celular, request.Ativo);
        entity.SetProfissionalId(request.Id);

        var success = await _repo.Update(entity);

        if (!success)
        {
            return Result.Error($"Falha ao atualizar o registro com Id: {request.Id}");
        }

        return Result.SuccessWithMessage("Atualizado com sucesso!");
    }
}
