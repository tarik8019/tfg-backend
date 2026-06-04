namespace ApiRest.Services.EmailServices
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string to, string subject, string body);
    }

}
