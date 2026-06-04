using ApiRest.Models.Entity;
using Microsoft.AspNetCore.Identity;

namespace ApiRest.Services.EmailServices
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _config;
        private readonly IEmailSender _emailSender;
        private readonly ILogger<AccountService> _logger;

        public AccountService(
            UserManager<AppUser> userManager,
            IConfiguration config,
            IEmailSender emailSender,
            ILogger<AccountService> logger)
        {
            _userManager = userManager;
            _config = config;
            _emailSender = emailSender;
            _logger = logger;
        }

        /// <summary>
        /// Envía email para que el usuario active su cuenta y cree contraseña.
        /// </summary>
        public async Task SendActivationEmailAsync(AppUser user, string token, string role)
        {
            _logger.LogInformation("Generando email de activación para el usuario {Email}", user.Email);

            // Codificar token para URL
            //var encodedToken = WebUtility.UrlEncode(token);
            var encodedToken = Uri.EscapeDataString(token);
            var encodedEmail = Uri.EscapeDataString(user.Email!);

     
            // URL del frontend (Flutter)
            string frontendBaseUrl = _config["FrontendActivationUrl"];
            if (string.IsNullOrEmpty(frontendBaseUrl))
            {
                _logger.LogError("No se encontró FrontendActivationUrl en appsettings.json");
                throw new Exception("FrontendActivationUrl no está configurado.");
            }

            // URL final
            var activationUrl = $"{frontendBaseUrl}?email={encodedEmail}&token={encodedToken}";

            var subject = "Activa tu cuenta";
            var body = $@"
                <h2>Hola {user.Nombre}, {user.Apellidos} </h2>
                <p>Tu cuenta ha sido creada por el administrador.</p>
                <p>Para activar tu cuenta y crear tu contraseña, haz clic en el siguiente botón:</p>
                <p>
                    <a style='padding:12px 24px;
                              background:#4CAF50;
                              color:white;
                              text-decoration:none;
                              border-radius:8px;
                              font-size:16px;'
                       href='{activationUrl}'>
                        Activar mi cuenta
                    </a>
                </p>
                <p>Este enlace es válido por 24 horas.</p>
                <p>Si no solicitaste esta cuenta, ignora este mensaje.</p>
            ";

            await _emailSender.SendEmailAsync(user.Email!, subject, body);
            _logger.LogInformation("Email de activación enviado correctamente a {Email}", user.Email);
        }
    }
}
