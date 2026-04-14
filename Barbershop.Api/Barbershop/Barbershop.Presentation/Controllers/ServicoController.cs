using Ardalis.Result;
using Barbershop.Application.Command.Request.ServicoRequestCommand;
using Barbershop.Application.Interfaces;
using Barbershop.Application.Query.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Barbershop.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class ServicoController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IServicoService _servicoService;

    public ServicoController(IMediator mediator, IServicoService servicoService)
    {
        _mediator = mediator;
        _servicoService = servicoService;
    }

    /// <summary>
    /// Retorna todos os serviços cadastrados.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(List<ServicoViewModel>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<ServicoViewModel>>> Get()
    {
        var result = await _servicoService.Get();
        return Ok(result);
    }

    /// <summary>
    /// Retorna um serviço pelo seu ID.
    /// </summary>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ServicoViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ServicoViewModel>> Get(int id)
    {
        var result = await _servicoService.Get(id);
        if (result == null)
            return NotFound($"Serviço com ID {id} não encontrado.");

        return Ok(result);
    }

    /// <summary>
    /// Adiciona um novo serviço.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(ServicoViewModel), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(IEnumerable<ValidationError>), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Create([FromBody] CreateServicoCommand command)
    {
        var result = await _mediator.Send(command);

        if (result.IsSuccess)
        {
            return CreatedAtAction(nameof(Get), new { id = result.Value.ServicoId }, result.Value);
        }

        return BadRequest(result.ValidationErrors);
    }

    /// <summary>
    /// Atualiza os dados de um serviço já cadastrado.
    /// </summary>
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Update(int id, [FromBody] UpdateServicoCommand command)
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
    /// Remove um serviço.
    /// </summary>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteServicoCommand(id);
        var result = await _mediator.Send(command);

        if (result.Status == ResultStatus.NotFound)
        {
            return NotFound();
        }

        return NoContent();
    }
}
