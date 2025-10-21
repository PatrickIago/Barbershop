namespace Barbershop.Domain.Entities;
public class Profissional
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Celular { get; set; }
    public string CPF { get; set; }
    public bool Ativo { get; set; }

    // Dados de navegação
    public virtual ICollection<Agendamento> Agendamentos { get; set; }
    public Profissional()
    {
        Agendamentos = new List<Agendamento>();
    }

    public Profissional(string cpf, string nome, string celular, bool ativo)
    {
        CPF = cpf;
        Nome = nome;
        Celular = celular;
        Ativo = ativo;
    }

    public Profissional(int id, string cpf, string nome, string celular, bool ativo)
    {
        Id = id;
        CPF = cpf;
        Nome = nome;
        Celular = celular;
        Ativo = ativo;
    }

    public void SetProfissionalId(int profissionalId)
    {
        if (Id == default)
        {
            Id = profissionalId;
        }
        else
        {
            throw new InvalidOperationException("O ID só pode ser definido uma vez.");
        }
    }
}
