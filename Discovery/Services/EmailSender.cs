using Discovery.Services.Abstractions;

namespace Discovery.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendMail(string to, string subjecti, string body)
        {
            throw new NotImplementedException();
        }
    }
}
