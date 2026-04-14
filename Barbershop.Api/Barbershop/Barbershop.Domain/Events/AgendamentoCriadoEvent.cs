using MediatR;
namespace Barbershop.Domain.Events
{
    public record AgendamentoCriadoEvent(int AgendamentoId, int ClienteId, DateTime DataHora) : INotification;
}
