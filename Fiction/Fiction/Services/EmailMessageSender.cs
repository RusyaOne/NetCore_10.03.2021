using Fiction.Infrastructure;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Fiction.Services
{
    public class EmailMessageSender : IMessageSender
    {
        private readonly FictionConfiguration _configuration;

        public EmailMessageSender(IOptions<FictionConfiguration> options)
        {
            _configuration = options.Value;
        }

        public void SendMessage()
        {
            //Declare email message
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("Admin", _configuration.SenderEmailAddress);
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress("User", "myconnect4@gmail.com");
            message.To.Add(to);

            message.Subject = "This is very important email";

            //Add email body
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = "<h1>Hello World!</h1>";
            bodyBuilder.TextBody = "Hello World!";

            message.Body = bodyBuilder.ToMessageBody();

            //Send message
            using (SmtpClient client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (sender, certificate, certChainType, errors) => true;

                // smtp-mail.outlook.com   587   MailKit.Security.SecureSocketOptions.StartTls
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate(_configuration.SenderEmailAddress, _configuration.SenderEmailPassword);

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}