namespace Barbershop.Application.Query.ViewModels;
public class ServicoViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public TimeSpan Duracao { get; set; }

    public ServicoViewModel()
    {

    }

    public ServicoViewModel(int id, string nome, decimal preco, TimeSpan duracao)
    {
        Id = id;
        Nome = nome;
        Preco = preco;
        Duracao = duracao;
    }
}
