using MailKit.Net.Smtp;
using Meetup.Services.Interfaces;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Threading.Tasks;

namespace Meetup.Services
{
    public class EmailSender : IEmailSender
    {
        EmailOptions options;
        public EmailSender(IOptions<EmailOptions> options)
        {
            this.options = options.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var mimeMessage = MimeMessage(email, subject);

            mimeMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            { Text = htmlMessage };

            await Send(mimeMessage);
        }

        private MimeMessage MimeMessage(string email, string subject)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(MailboxAddress.Parse(options.Sender));
            mimeMessage.To.Add(MailboxAddress.Parse(email));
            mimeMessage.Subject = subject;


            return mimeMessage;
        }

        private async Task Send(MimeMessage mimeMessage)
        {
            using SmtpClient smtpClient = new SmtpClient();

            smtpClient.ServerCertificateValidationCallback += (s, c, h, e) => true;
            await smtpClient.ConnectAsync(options.SmtpServer, options.Port, true);
            await smtpClient.AuthenticateAsync(options.UserName, options.Password);
            await smtpClient.SendAsync(mimeMessage);
            await smtpClient.DisconnectAsync(true);
        }
    }


}
