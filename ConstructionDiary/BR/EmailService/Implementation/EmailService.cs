using ConstructionDiary.BR.EmailService.Interfaces;
using Microsoft.AspNetCore.Hosting;
using MimeKit;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ConstructionDiary.BR.EmailService.Implementation
{
    public class EmailService : IEmailService
    {
        IHostingEnvironment env;

        public EmailService(IHostingEnvironment env)
        {
            this.env = env;
        }

        public async Task SendEmail(string subject, string username, string password, string receiver)
        {
            try
            {
                var pathToFile = env.WebRootPath
                           + Path.DirectorySeparatorChar.ToString()
                           + "Templates"
                           + Path.DirectorySeparatorChar.ToString()
                           + "emailtemplate.html";
                var builder = new BodyBuilder();

                using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
                {

                    string body = SourceReader.ReadToEnd();
                    body = body.Replace("{username}", username);
                    body = body.Replace("{password}", password);
                    using (MailMessage mm = new MailMessage("seminarskirs1@gmail.com", receiver))
                    {
                        mm.Subject = subject;
                        mm.Body = body;
                        mm.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential("seminarskirs1@gmail.com", "PetarKenanRS1");
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = 587;
                        smtp.Send(mm);
                    }
                }

            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
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

        }



    }
}
