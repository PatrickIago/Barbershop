using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using Barbershop.Application.Command.Request.ServicoRequestCommand;
using Barbershop.Application.Command.Response;
using Barbershop.Application.Command.Validators.ServicoValidator;
using Barbershop.Application.Interfaces;
using MediatR;

namespace Barbershop.Application.Handlers.ServicoHandlers;
internal class CreateServicoCommandHandler : IRequestHandler<CreateServicoCommand, Result<CreateServicoResponse>>
{
    private readonly IServicoService _repo;
    private readonly CreateServicoCommandValidator _validator;
    private readonly IMediator _mediator;

    public CreateServicoCommandHandler(IServicoService repo, CreateServicoCommandValidator validator, IMediator mediator)
    {
        _repo = repo;
        _validator = validator;
        _mediator = mediator;
    }

    public async Task<Result<CreateServicoResponse>> Handle(CreateServicoCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return Result.Invalid(validationResult.AsErrors());

        var entity = new Servico(request.Nome, request.Preco, request.Duracao);

        await _repo.Create(entity);

        return Result.Success(new CreateServicoResponse(entity.Id), "Cadastrado com sucesso! ");
    }
}
