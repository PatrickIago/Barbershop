namespace Barbershop.Application.Query.ViewModels;
public class ProfissionalViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Celular { get; set; }
    public string CPF { get; set; }
    public bool Ativo { get; set; }

    public ProfissionalViewModel()
    {

    }

    public ProfissionalViewModel(int id, string nome, bool ativo)
    {
        Id = id;
        Nome = nome;
        Ativo = ativo;
    }
}
