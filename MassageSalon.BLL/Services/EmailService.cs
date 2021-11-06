using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MassageSalon.BLL.EmailSender
{
    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(string recipientEmail, string subject, string name, string date)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(EmailConstants.SenderName, EmailConstants.SenderEmail));
            mimeMessage.To.Add(new MailboxAddress("", recipientEmail));

            mimeMessage.Subject = subject;
            mimeMessage.Body = new TextPart(TextFormat.Html)
            {
                Text = $"<b>Dear {name}  </b>"
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(EmailConstants.SmtpHost, EmailConstants.SmtpPort, false);
                await client.AuthenticateAsync(EmailConstants.SenderEmail, EmailConstants.EmailPassword);
                await client.SendAsync(mimeMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
