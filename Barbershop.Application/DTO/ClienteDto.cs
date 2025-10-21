using Barbershop.Domain.Entities;

namespace Barbershop.Application.DTO;
public class ClienteDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Celular { get; set; }
    public string CPF { get; set; }
    public DateTime DataCadastro { get; set; }

    public Cliente MapToResult()
    {
        return new Cliente(Id, Nome, Email, Celular, CPF);
    }
}
