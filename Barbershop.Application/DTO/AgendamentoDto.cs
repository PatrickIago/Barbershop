using Barbershop.Domain.Entities;

public class AgendamentoDto
{
    public int Id { get; set; }
    public DateTime DataHora { get; set; }

    public int ServicoId { get; set; }
    public string ServicoNome { get; set; }

    public int ProfissionalId { get; set; }
    public string ProfissionalNome { get; set; }  

    public int ClienteId { get; set; }
    public string ClienteNome { get; set; }       
    public string ClienteEmail { get; set; }

    public Agendamento MapToResult()
    {
        return new Agendamento(Id, DataHora, ServicoId, ProfissionalId, ClienteId)
        {
            Servico = new Servico(ServicoId, ServicoNome, 0, TimeSpan.Zero),
            Profissional = new Profissional { Id = ProfissionalId, Nome = ProfissionalNome }, 
            Cliente = new Cliente { Id = ClienteId, Nome = ClienteNome, Email = ClienteEmail } 
        };
    }
}
