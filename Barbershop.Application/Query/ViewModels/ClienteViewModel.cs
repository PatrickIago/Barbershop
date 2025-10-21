namespace Barbershop.Application.Query.ViewModels;
public class ClienteViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Celular { get; set; }
    public string CPF { get; set; }
    public DateTime DataCadastro { get; set; }


    public ClienteViewModel()
    {
    }

    public ClienteViewModel(string nome, string email, string celular, DateTime dataCadastro)
    {
        Nome = nome;
        Email = email;
        Celular = celular;
        DataCadastro = dataCadastro;
    }
}
