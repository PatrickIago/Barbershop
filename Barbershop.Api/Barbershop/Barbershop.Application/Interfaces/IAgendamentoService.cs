using Barbershop.Application.Query.ViewModels;
using Barbershop.Domain.Entities;
namespace Barbershop.Application.Interfaces;

public interface IAgendamentoService
{
    Task<List<AgendamentoViewModel>> Get();
    Task<AgendamentoViewModel> Get(int id);
    Task<List<AgendamentoViewModel>> GetByDia(DateTime dia);
    Task Create(Agendamento agendamento);
    Task<bool> Update(Agendamento agendamento);
    Task<bool> Delete(int id);
}
