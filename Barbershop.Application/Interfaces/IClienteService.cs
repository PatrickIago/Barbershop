using Barbershop.Application.Query.ViewModels;
using Barbershop.Domain.Entities;

namespace Barbershop.Application.Interfaces;
public interface IClienteService
{
    Task<List<ClienteViewModel>> Get();
    Task<ClienteViewModel> Get(int id);
    Task<ClienteViewModel> Create(Cliente cliente);
    Task<bool> Update(Cliente cliente);
    Task<bool> Delete(int id);
}
