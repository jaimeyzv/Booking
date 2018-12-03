using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;

namespace NotificacionProject
{
    public class NotificacionService : INotificacionService
    {
        public void EnviaCorreo(string correo, string nombre)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Eduardo Rojas", "u201625648@upc.edu.pe"));
                message.To.Add(new MailboxAddress(nombre, correo));
                message.Subject = "¡Bienvenido a Booking DSD!";

                message.Body = new TextPart("html")
                {
                    Text = "<h3>Te damos la bienvenida a Booking DSD!</h3>" +
                                        "<p>Hola, " + nombre + ",</p>" +
                                        "<p>Ahora formas parte de una comunidad que conecta a viajeros de todos los rincones del planeta con anfitriones locales en cualquier parte del mundo. Encuentra un alojamiento, descubre nuevas experiencias o comparte tu espacio.</p>" +
                                        "<p>Encuentra un alojamiento</p>" +
                                        "<p>Booking DSD - 2018</p>"
                };

                using (var client = new SmtpClient())
                {
                    // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    client.Connect("smtp.office365.com", 587, SecureSocketOptions.StartTls);

                    // Note: only needed if the SMTP server requires authentication
                    client.Authenticate("u201625648@upc.edu.pe", "#AB12ab#");

                    client.Send(message);
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
