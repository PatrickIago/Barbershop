using Barbershop.Domain.Entities;
public class Servico
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public TimeSpan Duracao { get; set; }

    public virtual ICollection<Agendamento> Agendamentos { get; set; }

    public Servico(int id, string nome, decimal preco, TimeSpan duracao)
    {
        Id = id;
        Nome = nome;
        Preco = preco;
        Duracao = duracao;
    }

    public Servico(string nome, decimal preco, TimeSpan duracao)
    {
        Nome = nome;
        Preco = preco;
        Duracao = duracao;
    }

    public void SetServicoId(int servicoId)
    {
        if (Id == default)
        {
            Id = servicoId;
        }
        else
        {
            throw new InvalidOperationException("O ID só pode ser definido uma vez.");
        }
    }
}
