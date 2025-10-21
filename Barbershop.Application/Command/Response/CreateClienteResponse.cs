namespace Barbershop.Application.Command.Response;
public class CreateClienteResponse
{
    public CreateClienteResponse(int id) => ClienteId = id;
    public int ClienteId { get; }
}
