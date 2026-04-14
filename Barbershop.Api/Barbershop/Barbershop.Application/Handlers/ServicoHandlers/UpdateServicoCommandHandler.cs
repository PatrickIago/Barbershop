using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using Barbershop.Application.Command.Request.ServicoRequestCommand;
using Barbershop.Application.Command.Validators.ServicoValidator;
using Barbershop.Application.Interfaces;
using MediatR;
namespace Barbershop.Application.Handlers.ServicoHandlers;
public class UpdateServicoCommandHandler : IRequestHandler<UpdateServicoCommand, Result>
{
    private readonly IServicoService _repo;
    private readonly UpdateServicoCommandValidator _validator;
    private readonly IMediator _mediator;

    public UpdateServicoCommandHandler(IServicoService repo, UpdateServicoCommandValidator validator, IMediator mediator)
    {
        _repo = repo;
        _validator = validator;
        _mediator = mediator;
    }

    public async Task<Result> Handle(UpdateServicoCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return Result.Invalid(validationResult.AsErrors());

        var servico = await _repo.Get(request.Id);
        if (servico == null)
            return Result.NotFound($"Nenhum registro encontrado pelo Id: {request.Id}");

        var entity = new Servico(request.Nome, request.Preco, request.Duracao);
        entity.Id = request.Id;

        var success = await _repo.Update(entity);

        if (!success)
        {
            return Result.Error($"Falha ao atualizar o registro com Id: {request.Id}");
        }

        return Result.SuccessWithMessage("Atualizado com sucesso!");

    }

}
