using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Logging;

namespace ApiRest.Services.EmailServices
{
    public class SmtpEmailSender : IEmailSender
    {
        private readonly IConfiguration _config;
        private readonly ILogger<SmtpEmailSender> _logger;

        public SmtpEmailSender(IConfiguration config, ILogger<SmtpEmailSender> logger)
        {
            _config = config;
            _logger = logger;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            try
            {
                var host = _config["Email:SmtpHost"];
                var port = int.Parse(_config["Email:SmtpPort"]);
                var user = _config["Email:SmtpUser"];
                var pass = _config["Email:SmtpPass"];

                using var client = new SmtpClient(host, port)
                {
                    Credentials = new NetworkCredential(user, pass),
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false
                };

                var mail = new MailMessage
                {
                    From = new MailAddress(
                        _config["Email:FromEmail"],
                        _config["Email:FromName"]
                    ),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                mail.To.Add(to);

                _logger.LogInformation("Enviando email a {Email}", to);

                await client.SendMailAsync(mail);

                _logger.LogInformation("Email enviado correctamente a {Email}", to);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error enviando email a {Email}", to);
                throw;
            }
        }
    }
}
