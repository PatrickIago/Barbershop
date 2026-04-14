using Barbershop.Domain.Entities;

namespace Barbershop.Application.DTO;
public class ProfissionalDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Celular { get; set; }
    public string CPF { get; set; }
    public bool Ativo { get; set; }

    public Profissional MapToResult()
    {
        return new Profissional(Id, Nome, Celular, CPF, Ativo);
    }
}
