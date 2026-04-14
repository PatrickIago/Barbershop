namespace Barbershop.Application.Command.Response;
public class CreateAgendamentoResponse
{
    public CreateAgendamentoResponse(int id) => AgendamentoId = id;
    public int AgendamentoId { get; set; }
}
