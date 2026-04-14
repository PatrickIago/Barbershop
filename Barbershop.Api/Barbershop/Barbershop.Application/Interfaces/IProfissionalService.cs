using Barbershop.Application.Query.ViewModels;
using Barbershop.Domain.Entities;

namespace Barbershop.Application.Interfaces;
public interface IProfissionalService
{
    Task<List<ProfissionalViewModel>> Get();
    Task<ProfissionalViewModel> Get(int id);
    Task<ProfissionalViewModel> Create(Profissional profissional);
    Task<bool> Update(Profissional profissional);
    Task<bool> Delete(int id);
}
