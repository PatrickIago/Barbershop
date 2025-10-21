using Ardalis.Result;
using Barbershop.Application.Command.Request.ClienteRequestCommand;
using Barbershop.Application.Command.Request.ProfissionalRequestCommand;
using Barbershop.Application.Command.Request.ServicoRequestCommand;
using Barbershop.Application.Command.Response;
using Barbershop.Application.Command.Validators.ClienteValidator;
using Barbershop.Application.Command.Validators.ProfissionalValidator;
using Barbershop.Application.Command.Validators.ServicoValidator;
using Barbershop.Application.Handlers.ClienteHandlers;
using Barbershop.Application.Handlers.ProfissionalHandlers;
using Barbershop.Application.Handlers.ServicoHandlers;
using Barbershop.Application.Query.Request.GetClienteRequestQuery;
using Barbershop.Application.Query.Request.GetServicoRequestQuery;
using Barbershop.Application.Query.Request.ProfissionalRequest;
using Barbershop.Application.Query.Validators;
using Barbershop.Application.Query.ViewModels;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Barbershop.Application;
public class HandlersInitializer
{
    public static void Initialize(IServiceCollection services)
    {
        // Profissional
        services.AddTransient<IRequestHandler<CreateProfissionalCommand, Result<CreateProfissionalResponse>>, CreateProfissionalCommandHandler>();
        services.AddTransient<CreateProfissionalCommandValidator>();

        services.AddTransient<IRequestHandler<UpdateProfissionalCommand, Result>, UpdateProfissionalCommandHandler>();
        services.AddTransient<UpdateProfissionalCommandValidator>();

        services.AddTransient<IRequestHandler<DeleteProfissionalCommand, Result>, DeleteProfissionalCommandHandler>();
        services.AddTransient<DeleteProfissionalCommandValidator>();

        services.AddTransient<IRequestHandler<GetProfissionalQuery, Result<List<ProfissionalViewModel>>>, GetProfissionalQueryHandler>();
        services.AddTransient<IRequestHandler<GetProfissionalByIdQuery, Result<ProfissionalViewModel>>, GetProfissionalByIdQueryHandler>();
        services.AddTransient<GetProfissionalByIdQueryValidator>();

        // Cliente
        services.AddTransient<IRequestHandler<CreateClienteCommand, Result<CreateClienteResponse>>, CreateClienteCommandHandler>();
        services.AddTransient<CreateClienteCommandValidator>();

        services.AddTransient<IRequestHandler<UpdateClienteCommand, Result>, UpdateClienteCommandHandler>();
        services.AddTransient<UpdateClienteCommandValidator>();

        services.AddTransient<IRequestHandler<DeleteClienteCommand, Result>, DeleteClienteCommandHandler>();
        services.AddTransient<DeleteClienteCommandValidator>();

        services.AddTransient<IRequestHandler<GetClienteQuery, Result<List<ClienteViewModel>>>, GetClienteQueryHandler>();
        services.AddTransient<IRequestHandler<GetClienteByIdQuery, Result<ClienteViewModel>>, GetClienteByIdQueryHandler>();
        services.AddTransient<GetClienteByIdQueryValidator>();

        // Servico
        services.AddTransient<IRequestHandler<CreateServicoCommand, Result<CreateServicoResponse>>, CreateServicoCommandHandler>();
        services.AddTransient<CreateServicoCommandValidator>();

        services.AddTransient<IRequestHandler<UpdateServicoCommand, Result>, UpdateServicoCommandHandler>();
        services.AddTransient<UpdateServicoCommandValidator>();

        services.AddTransient<IRequestHandler<UpdateServicoCommand, Result>, UpdateServicoCommandHandler>();
        services.AddTransient<DeleteServicoCommandValidator>();

        services.AddTransient<IRequestHandler<GetServicoQuery, Result<List<ServicoViewModel>>>, GetServicoQueryHandler>();
        services.AddTransient<IRequestHandler<GetServicoByIdQuery, Result<ServicoViewModel>>, GetServicoByIdQueryHandler>();
        services.AddTransient<GetServicoByIdQueryValidator>();

    }
}
