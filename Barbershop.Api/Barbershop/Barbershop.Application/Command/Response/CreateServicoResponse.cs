namespace Barbershop.Application.Command.Response;
public class CreateServicoResponse
{
    public CreateServicoResponse(int id) => ServicoId = id;
    public int ServicoId { get; }
}
