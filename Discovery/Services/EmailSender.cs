using Discovery.Opts;
using Discovery.Services.Abstractions;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Discovery.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IOptions<MailOption> options;

        public EmailSender(IOptions<MailOption> options)
        {
            this.options = options;
        }

        public async Task SendMail(string to, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse(options.Value.Email));
            message.To.Add(MailboxAddress.Parse(to));
            message.Subject = "Test Mailkit";
            
            var bodybuilder = new BodyBuilder();
            bodybuilder.TextBody = body;
            message.Body = bodybuilder.ToMessageBody();

            using var client = new SmtpClient();
            await client.ConnectAsync(options.Value.Serveur, options.Value.Port, options.Value.UseSSL);
            await client.AuthenticateAsync(options.Value.Login, options.Value.Password);
            await client.SendAsync(message);
            client.Disconnect(true);
        }
    }
}
