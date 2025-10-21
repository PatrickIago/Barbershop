using Barbershop.Application.Query.ViewModels;
namespace Barbershop.Application.Interfaces;
public interface IServicoService
{
    Task<List<ServicoViewModel>> Get();
    Task<ServicoViewModel> Get(int id);
    Task<ServicoViewModel> Create(Servico servico);
    Task<bool> Update(Servico servico);
    Task<bool> Delete(int id);
}
