namespace Barbershop.Application.Query.ViewModels;
public class AgendamentoViewModel
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
}
