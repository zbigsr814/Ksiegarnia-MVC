using ExampleMvcProject.MVC.Models;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using SecondWebApp.Interfaces;
using System.Net;
using System.Net.Mail;

namespace ExampleMvcProject.MVC.Service
{
    public class EmailSender : IEmailSender
    {
        private readonly SmtpSettings smtpSettings;
        public EmailSender(IOptions<SmtpSettings> smtpSettings)
        {
            this.smtpSettings = smtpSettings.Value;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            var mail = smtpSettings.Username;
            var pw = smtpSettings.Password;

            var client = new SmtpClient()
            {
                Host = smtpSettings.Host,
                Port = smtpSettings.Port,
                EnableSsl = smtpSettings.EnableSsl,
                Credentials = new NetworkCredential(mail, pw)
            };

            return client.SendMailAsync(
                new MailMessage(from: mail, to: email, subject, message));
        }
    }
}
