namespace Barbershop.Application.DTO;
public class ServicoDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public TimeSpan Duracao { get; set; }

    public Servico MapToResult()
    {
        return new Servico(Id, Nome, Preco, Duracao);
    }
}
