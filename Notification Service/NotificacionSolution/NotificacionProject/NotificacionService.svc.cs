using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit;
using MailKit.Security;

namespace NotificacionProject
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "NotificacionService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select NotificacionService.svc or NotificacionService.svc.cs at the Solution Explorer and start debugging.
    public class NotificacionService : INotificacionService
    {
        public void EnviaCorreo(string correo)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Eduardo Rojas", "@upc.edu.pe"));
                message.To.Add(new MailboxAddress("Nombre", correo));
                message.Subject = "¡Bienvenido a Booking DSD!";

                message.Body = new TextPart("html")
                {
                    Text = @"<h3>Te damos la bienvenida a Booking DSD!</h3>
                                        <p>Hola, Usuario,</p>
                                        <p>Ahora formas parte de una comunidad que conecta a viajeros de todos los rincones del planeta con anfitriones locales en cualquier parte del mundo. Encuentra un alojamiento, descubre nuevas experiencias o comparte tu espacio.</p>
                                        <p>Encuentra un alojamiento</p>
                                        
                                        <p>Booking DSD - 2018</p>"
                };

                using (var client = new SmtpClient())
                {
                    // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    client.Connect("smtp.office365.com", 587, SecureSocketOptions.StartTls);

                    // Note: only needed if the SMTP server requires authentication
                    client.Authenticate("@upc.edu.pe", "");

                    client.Send(message);
                    client.Disconnect(true);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
