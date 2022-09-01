namespace Discovery.Services.Abstractions
{
    public interface IEmailSender
    {
        Task SendMail(string to,string subjecti,string body);
    }
}
