using ConstructionDiary.BR.EmailService.Interfaces;
using System;
using System.Net;
using System.Net.Mail;

namespace ConstructionDiary.BR.EmailService.Implementation
{
    public class EmailService : IEmailService
    {
        public bool SendEmail(string subject, string message, string receiver)
        {
            try
            {

                SmtpClient client = new SmtpClient("mysmtpserver");
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("username", "password");

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("whoever@me.com");
                mailMessage.To.Add("receiver@me.com");
                mailMessage.Body = "body";
                mailMessage.Subject = "subject";
                client.Send(mailMessage);
            }catch(Exception e)
            {
                return true;
            }
            return true;
            //var msg = new MimeMessage();
            //msg.From.Add(new MailboxAddress("Registracija Bot","seminarskirs1@gmail.com"));
            //msg.To.Add(new MailboxAddress("Korisnik",receiver));
            //msg.Subject = "Registracija uspješna";
            //msg.Body = new TextPart("plain")
            //{
            //    Text = message
            //};

            //using (var client = new SmtpClient())
            //{
            //    client.Connect("smtp.gmail.com", 587, false);
            //    //password PetarKenanRS1
            //    client.Authenticate("seminarskirs1@gmail.com", "PetarKenanRS1");
            //    client.Send(msg);
            //    client.Disconnect(true);
            //}
            //return true;
        }
    }
}
