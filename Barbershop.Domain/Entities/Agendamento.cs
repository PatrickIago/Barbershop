namespace Barbershop.Domain.Entities;
public class Agendamento
{
    public int Id { get; set; }
    public DateTime DataHora { get; set; }
    public int ServicoId { get; set; }
    public int ProfissionalId { get; set; }
    public int ClienteId { get; set; }

    // Dados de navegação
    public virtual Cliente Cliente { get; set; }
    public virtual Profissional Profissional { get; set; }
    public virtual Servico Servico { get; set; }

    public Agendamento() { }

    public Agendamento(int id, DateTime dataHora, int servicoId, int profissionalId, int clienteId)
    {
        Id = id;
        ServicoId = servicoId;
        ProfissionalId = profissionalId;
        ClienteId = clienteId;
        DataHora = dataHora;
    }

    public Agendamento(DateTime dataHora, int servicoId, int profissionalId, int clienteId)
    {
        ServicoId = servicoId;
        ProfissionalId = profissionalId;
        ClienteId = clienteId;
        DataHora = dataHora;
    }

    public void SetAgendamentoId(int agendamentoId)
    {
        if (Id == default)
        {
            Id = agendamentoId;
        }
        else
        {
            throw new InvalidOperationException("O ID só pode ser definido uma vez.");
        }
    }
}
