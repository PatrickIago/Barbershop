namespace Barbershop.Application.Interfaces;
public interface IEmailService
{
    Task EnviarEmailAsync(string para, string assunto, string mensagem);
}
