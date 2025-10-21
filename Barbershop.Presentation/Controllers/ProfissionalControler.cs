using Ardalis.Result;
using Barbershop.Application.Command.Request.ProfissionalRequestCommand;
using Barbershop.Application.Interfaces;
using Barbershop.Application.Query.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Barbershop.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class ProfissionalController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IProfissionalService _profissionalService;

    public ProfissionalController(IMediator mediator, IProfissionalService profissionalService)
    {
        _mediator = mediator;
        _profissionalService = profissionalService;
    }

    /// <summary>
    /// Retorna todos os profissionais cadastrados.
    /// </summary>
    /// <returns>Uma lista de profissionais.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<ProfissionalViewModel>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<ProfissionalViewModel>>> Get()
    {
        var result = await _profissionalService.Get();
        return Ok(result);
    }

    /// <summary>
    /// Retorna um profissional pelo seu ID.
    /// </summary>
    /// <param name="id">O ID do profissional.</param>
    /// <returns>Os dados do profissional.</returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ProfissionalViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProfissionalViewModel>> Get(int id)
    {
        var result = await _profissionalService.Get(id);
        if (result == null)
            return NotFound($"Profissional com ID {id} não encontrado.");

        return Ok(result);
    }

    /// <summary>
    /// Adiciona um novo profissional.
    /// </summary>
    /// <param name="command">Os dados para criar o profissional.</param>
    /// <returns>A localização do novo profissional.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ProfissionalViewModel), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(IEnumerable<ValidationError>), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Create([FromBody] CreateProfissionalCommand command)
    {
        var result = await _mediator.Send(command);

        if (result.IsSuccess)
        {
            return CreatedAtAction(nameof(Get), new { id = result.Value.ProfissionalId }, result.Value);
        }

        return BadRequest(result.ValidationErrors);
    }

    /// <summary>
    /// Atualiza os dados de um profissional já cadastrado.
    /// </summary>
    /// <param name="id">O ID do profissional a ser atualizado.</param>
    /// <param name="command">Os dados do profissional.</param>
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Update(int id, [FromBody] UpdateProfissionalCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest("O ID fornecido na rota não corresponde ao ID do corpo da requisição.");
        }

        var result = await _mediator.Send(command);

        return result.Status switch
        {
            ResultStatus.Ok => NoContent(),
            ResultStatus.Invalid => BadRequest(result.ValidationErrors),
            ResultStatus.NotFound => NotFound(),
            _ => StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro inesperado.")
        };
    }

    /// <summary>
    /// Remove um profissional.
    /// </summary>
    /// <param name="id">O ID do profissional a ser removido.</param>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteProfissionalCommand(id);
        var result = await _mediator.Send(command);

        if (result.Status == ResultStatus.NotFound)
        {
            return NotFound();
        }

        return NoContent();
    }
}