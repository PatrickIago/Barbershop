using AutoMapper;
using Barbershop.Application.Query.ViewModels;
using Barbershop.Domain.Entities;

namespace Barbershop.Application.MappingProfile;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Profissional
        CreateMap<Profissional, ProfissionalViewModel>();
        CreateMap<ProfissionalViewModel, Profissional>();

        // Cliente
        CreateMap<Cliente, ClienteViewModel>();
        CreateMap<ClienteViewModel, Cliente>();

        // Servico
        CreateMap<Servico, ServicoViewModel>();
        CreateMap<ServicoViewModel, Servico>();

        // Agendamento
        CreateMap<Agendamento, AgendamentoViewModel>()
            .ForMember(dest => dest.ServicoNome, opt => opt.MapFrom(src => src.Servico.Nome))
            .ForMember(dest => dest.ProfissionalNome, opt => opt.MapFrom(src => src.Profissional.Nome))
            .ForMember(dest => dest.ClienteNome, opt => opt.MapFrom(src => src.Cliente.Nome))
            .ForMember(dest => dest.ClienteEmail, opt => opt.MapFrom(src => src.Cliente.Email));

        CreateMap<AgendamentoViewModel, Agendamento>();
    }
}
