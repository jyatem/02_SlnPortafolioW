using _02_Portafolio.Models;
using System.Net;
using System.Net.Mail;

namespace _02_Portafolio.Servicios
{
    public class ServicioEmailGmail : IServicioEmail
    {
        private readonly IConfiguration configuration;

        public ServicioEmailGmail(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task Enviar(ContactoViewModel contactoViewModel)
        {
            var emailEmisor = configuration.GetValue<string>("Configuraciones_Correo:Correo");
            var clave = configuration.GetValue<string>("Configuraciones_Correo:Clave");
            var host = configuration.GetValue<string>("Configuraciones_Correo:Host");
            var puerto = configuration.GetValue<int>("Configuraciones_Correo:Puerto");

            var smtpCliente = new SmtpClient(host, puerto);
            smtpCliente.EnableSsl = true;
            smtpCliente.UseDefaultCredentials = false;

            smtpCliente.Credentials = new NetworkCredential(emailEmisor, clave);

            var mensaje = new MailMessage(emailEmisor, emailEmisor, $"El cliente {contactoViewModel.Nombre} ({contactoViewModel.Email}) quiere contactarte", contactoViewModel.Mensaje);

            await smtpCliente.SendMailAsync(mensaje);
        }
    }
}
