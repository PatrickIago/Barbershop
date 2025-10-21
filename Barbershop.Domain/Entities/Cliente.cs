namespace Barbershop.Domain.Entities;
public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Celular { get; set; }
    public string CPF { get; set; }
    public DateTime DataCadastro { get; set; }

    public virtual ICollection<Agendamento> Agendamentos { get; set; }

    public Cliente()
    {
        Agendamentos = new List<Agendamento>();
    }

    public Cliente(string nome, string email, string celular, string cpf)
    {
        Nome = nome;
        Email = email;
        Celular = celular;
        CPF = cpf;
        DataCadastro = DateTime.Now;
    }

    public Cliente(int id, string nome, string email, string celular, string cpf)
    {
        Id = id;
        Nome = nome;
        Email = email;
        Celular = celular;
        CPF = cpf;
        DataCadastro = DateTime.Now;
    }

    public void SetClienteId(int clienteId)
    {
        if (Id == default)
        {
            Id = clienteId;
        }
        else
        {
            throw new InvalidOperationException("O ID só pode ser definido uma vez.");
        }
    }
}
