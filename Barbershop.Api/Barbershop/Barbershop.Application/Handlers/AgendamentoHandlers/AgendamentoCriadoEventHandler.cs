using Barbershop.Application.Interfaces;
using Barbershop.Domain.Events;
using MediatR;
using System.Globalization;

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

        if (agendamento == null) return;

        var dataFormatada = agendamento.DataHora.ToString("dddd, dd 'de' MMMM 'às' HH:mm", new CultureInfo("pt-BR"));

        string assunto = $"✅ Confirmado: {agendamento.ServicoNome} na BarberShop";

        string corpoHtml = $@"
            <div style='font-family: sans-serif; max-width: 600px; border: 1px solid #ddd; padding: 20px;'>
                <h2 style='color: #0061ff;'>Olá, {agendamento.ClienteNome}!</h2>
                <p>Seu agendamento foi realizado com sucesso em nossa unidade.</p>
                <hr style='border: 0; border-top: 1px solid #eee;' />
                <p><strong>Serviço:</strong> {agendamento.ServicoNome}</p>
                <p><strong>Profissional:</strong> {agendamento.ProfissionalNome}</p>
                <p><strong>Data/Hora:</strong> {dataFormatada}</p>
                <hr style='border: 0; border-top: 1px solid #eee;' />
                <p style='font-size: 0.9em; color: #666;'>Agradecemos a preferência! Se precisar desmarcar, entre em contato com 24h de antecedência.</p>
                <footer style='margin-top: 20px; font-size: 0.8em; color: #999;'>
                    BarberShop Premium - Canoas, RS
                </footer>
            </div>";

        await _emailService.EnviarEmailAsync(agendamento.ClienteEmail, assunto, corpoHtml);
    }
}