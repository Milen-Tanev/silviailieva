namespace SilviaIlieva.Services.External
{
    using System.Threading.Tasks;
    using Contracts;
    using Configuration;
    using Models;
    using System;
    using MailKit.Net.Smtp;
    using MimeKit;

    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration emailConfiguration;

        public EmailSender(EmailConfiguration emailConfiguration)
        {
            this.emailConfiguration = emailConfiguration ?? throw new ArgumentNullException("The email configuration cannot be null.");
        }

        public async Task SendMessage(EmailMessage message)
        {
            var mimeMessage = this.CreateMessage(message);
            await this.SendInternal(mimeMessage).ConfigureAwait(false);
        }

        private async Task SendInternal(MimeMessage message)
        {
            using var client = new SmtpClient();
            try
            {
                await client.ConnectAsync(this.emailConfiguration.SmtpServer, this.emailConfiguration.Port, true).ConfigureAwait(false);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.AuthenticateAsync(emailConfiguration.UserName, emailConfiguration.Password).ConfigureAwait(false);

                await client.SendAsync(message).ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                await client.DisconnectAsync(true).ConfigureAwait(false);
                client.Dispose();
            }
        }

        private MimeMessage CreateMessage(EmailMessage message)
        {
            var emailMessage = new MimeMessage
            {
                Subject = message.Subject,
                Body = new TextPart(MimeKit.Text.TextFormat.Text)
                {
                    Text = message.Content
                }
            };
            emailMessage.From.Add(new MailboxAddress(this.emailConfiguration.From));
            emailMessage.To.AddRange(message.To);

            return emailMessage;
        }
    }
}
