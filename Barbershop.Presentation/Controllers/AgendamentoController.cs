using Ardalis.Result;
using Barbershop.Application.Command.Request.AgendamentoRequestCommand;
using Barbershop.Application.Interfaces;
using Barbershop.Application.Query.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Barbershop.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class AgendamentoController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IAgendamentoService _agendamentoService;

    public AgendamentoController(IMediator mediator, IAgendamentoService agendamentoService)
    {
        _mediator = mediator;
        _agendamentoService = agendamentoService;
    }

    /// <summary>
    /// Retorna todos os agendamentos cadastrados.
    /// </summary>
    /// <returns>Uma lista de agendamentos.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<AgendamentoViewModel>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<AgendamentoViewModel>>> Get()
    {
        var result = await _agendamentoService.Get();
        return Ok(result);
    }

    /// <summary>
    /// Retorna um agendamento pelo seu ID.
    /// </summary>
    /// <param name="id">O ID do agendamento.</param>
    /// <returns>Os dados do agendamento.</returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(AgendamentoViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AgendamentoViewModel>> Get(int id)
    {
        var result = await _agendamentoService.Get(id);
        if (result == null)
            return NotFound($"Agendamento com ID {id} não encontrado.");
        return Ok(result);
    }

    /// <summary>
    /// Retorna todos os agendamentos cadastrados por uma data específica.
    /// </summary>
    /// <param name="data">Informe a data no formato <b>dd-MM-yyyy</b>, exemplo: 22-09-2025.</param>
    [HttpGet("por-data/{data:datetime}")]
    [ProducesResponseType(typeof(List<AgendamentoViewModel>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<AgendamentoViewModel>>> GetByDia(DateTime data)
    {
        var result = await _agendamentoService.GetByDia(data);
        return Ok(result);
    }
    /// <summary>
    /// Adiciona um novo Agendamento.
    /// </summary>
    /// <param name="command">Os dados para criar o agendamento.</param>
    /// <returns>A localização do novo Agendamento.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(CreateAgendamentoCommand), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(IEnumerable<ValidationError>), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Create([FromBody] CreateAgendamentoCommand command)
    {
        var result = await _mediator.Send(command);

        if (result.IsSuccess)
        {
            return CreatedAtAction(nameof(Get), new { id = result.Value.AgendamentoId }, result.Value);
        }

        return BadRequest(result.ValidationErrors);
    }

    /// <summary>
    /// Atualiza os dados de um agendamento já cadastrado.
    /// </summary>
    /// <param name="id">O ID do agendamento a ser atualizado.</param>
    /// <param name="command">Os dados do agendamento.</param>
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Update(int id, [FromBody] UpdateAgendamentoCommand command)
    {
        if (id != command.Id)
            return BadRequest("ID da rota não corresponde ao corpo da requisição.");

        var result = await _mediator.Send(command);

        return result.Status switch
        {
            ResultStatus.Ok => NoContent(),
            ResultStatus.Invalid => BadRequest(result.ValidationErrors),
            ResultStatus.NotFound => NotFound(),
            _ => StatusCode(StatusCodes.Status500InternalServerError, "Erro inesperado.")
        };
    }

    /// <summary>
    /// Remove um agendamento.
    /// </summary>
    /// <param name="id">O ID do agendamento a ser removido.</param>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteAgendamentoCommand(id);
        var result = await _mediator.Send(command);

        if (result.Status == ResultStatus.NotFound)
            return NotFound();

        return NoContent();
    }
}
