using Ardalis.Result;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Barbershop.Application.Command.Request.ServicoRequestCommand;
public class UpdateServicoCommand : IRequest<Result>
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Nome { get; set; }

    [Required]
    [Range(0.01, 9999.99, ErrorMessage = "O preço deve ser maior que zero.")]
    public decimal Preco { get; set; }

    [Required]
    [Range(typeof(TimeSpan), "00:05:00", "04:00:00", ErrorMessage = "A duração deve estar entre 5 minutos e 4 horas.")]
    public TimeSpan Duracao { get; set; }
}
