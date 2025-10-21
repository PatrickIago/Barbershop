namespace Barbershop.Application.Command.Response;
public class CreateProfissionalResponse
{
    public CreateProfissionalResponse(int id) => ProfissionalId = id;
    public int ProfissionalId { get; }
}
