using Ardalis.Result;
using Barbershop.Application.Command.Request.ClienteRequestCommand;
using Barbershop.Application.Interfaces;
using Barbershop.Application.Query.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Barbershop.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class ClienteController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IClienteService _clienteService;

    public ClienteController(IMediator mediator, IClienteService clienteService)
    {
        _mediator = mediator;
        _clienteService = clienteService;
    }

    /// <summary>
    /// Retorna todos os clientes cadastrados.
    /// </summary>
    /// <returns>Uma lista de clientes.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<ClienteViewModel>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<ClienteViewModel>>> Get()
    {
        var result = await _clienteService.Get();
        return Ok(result);
    }

    /// <summary>
    /// Retorna um cliente pelo seu ID.
    /// </summary>
    /// <param name="id">O ID do cliente.</param>
    /// <returns>Os dados do cliente.</returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ClienteViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ClienteViewModel>> Get(int id)
    {
        var result = await _clienteService.Get(id);
        if (result == null)
            return NotFound($"Cliente com ID {id} não encontrado.");

        return Ok(result);
    }

    /// <summary>
    /// Adiciona um novo cliente.
    /// </summary>
    /// <param name="command">Os dados para criar o cliente.</param>
    /// <returns>A localização do novo cliente.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ClienteViewModel), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(IEnumerable<ValidationError>), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Create([FromBody] CreateClienteCommand command)
    {
        var result = await _mediator.Send(command);

        if (result.IsSuccess)
        {
            return CreatedAtAction(nameof(Get), new { id = result.Value.ClienteId }, result.Value);
        }

        return BadRequest(result.ValidationErrors);
    }

    /// <summary>
    /// Atualiza os dados de um cliente já cadastrado.
    /// </summary>
    /// <param name="id">O ID do cliente a ser atualizado.</param>
    /// <param name="command">Os dados do cliente.</param>
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Update(int id, [FromBody] UpdateClienteCommand command)
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
    /// Remove um cliente.
    /// </summary>
    /// <param name="id">O ID do cliente a ser removido.</param>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteClienteCommand(id);
        var result = await _mediator.Send(command);

        if (result.Status == ResultStatus.NotFound)
        {
            return NotFound();
        }

        return NoContent();
    }
}
