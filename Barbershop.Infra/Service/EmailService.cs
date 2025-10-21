using Barbershop.Application.Interfaces;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
public class EmailService : IEmailService
{
    private readonly IConfiguration _config;

    public EmailService(IConfiguration config)
    {
        _config = config;
    }

    public async Task EnviarEmailAsync(string para, string assunto, string mensagem)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_config["Email:Usuario"]));
        email.To.Add(MailboxAddress.Parse(para));
        email.Subject = assunto;
        email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = mensagem };

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(_config["Email:SmtpServer"], int.Parse(_config["Email:SmtpPort"]), MailKit.Security.SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(_config["Email:Usuario"], _config["Email:Senha"]);
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }
}
