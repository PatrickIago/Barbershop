using Barbershop.Application.Interfaces;
using Barbershop.Domain.Events;
using MediatR;

public class AgendamentoCriadoEventHandler : INotificationHandler<AgendamentoCriadoEvent>
{
    private readonly IEmailService _emailService;
    private readonly IAgendamentoService _repo;

    public AgendamentoCriadoEventHandler(IEmailService emailService, IAgendamentoService repo)
    {
        _emailService = emailService;
        _repo = repo;
    }

    public async Task Handle(AgendamentoCriadoEvent notification, CancellationToken cancellationToken)
    {
        var agendamento = await _repo.Get(notification.AgendamentoId);

        var clienteEmail = agendamento.ClienteEmail;

        string assunto = "Seu agendamento foi criado!";
        string mensagem = $"Olá! {agendamento.ClienteNome} Seu agendamento para {agendamento.ServicoNome} está confirmado para esta data {agendamento.DataHora} agradecemos a preferência.";

        await _emailService.EnviarEmailAsync(clienteEmail, assunto, mensagem);
    }
}
