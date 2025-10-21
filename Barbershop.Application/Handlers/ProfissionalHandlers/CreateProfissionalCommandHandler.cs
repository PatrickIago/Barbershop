using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using Barbershop.Application.Command.Request.ProfissionalRequestCommand;
using Barbershop.Application.Command.Response;
using Barbershop.Application.Command.Validators.ProfissionalValidator;
using Barbershop.Application.Interfaces;
using Barbershop.Domain.Entities;
using MediatR;
namespace Barbershop.Application.Handlers.ProfissionalHandlers;
public class CreateProfissionalCommandHandler : IRequestHandler<CreateProfissionalCommand, Result<CreateProfissionalResponse>>
{
    private readonly IProfissionalService _repo;
    private readonly CreateProfissionalCommandValidator _validator;
    private readonly IMediator _mediator;

    public CreateProfissionalCommandHandler(IProfissionalService repo,
    CreateProfissionalCommandValidator validator, IMediator mediator)
    {
        _repo = repo;
        _validator = validator;
        _mediator = mediator;
    }

    public async Task<Result<CreateProfissionalResponse>> Handle(CreateProfissionalCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return Result.Invalid(validationResult.AsErrors());

        var entity = new Profissional(request.CPF, request.Nome, request.Celular, request.Ativo);

        await _repo.Create(entity);

        return Result.Success(new CreateProfissionalResponse(entity.Id), "Cadastrado com sucesso!");
    }
}
