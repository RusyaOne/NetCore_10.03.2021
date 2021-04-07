using Fiction.Configuration;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Fiction.Services
{
    public class EmailMessageSender : IMessageSender
    {
        private readonly IConfiguration _configration;
        private readonly FictionConfiguration _fictionConfiguration;

        public EmailMessageSender(IConfiguration configration,
            IOptions<FictionConfiguration> options)
        {
            _configration = configration;
            _fictionConfiguration = options.Value;
        }

        public void SendMessage()
        {
            //Add email message
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("Admin", _fictionConfiguration.EmailAddress);
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress("User", "myconnect4@gmail.com");
            message.To.Add(to);

            message.Subject = "This is email subject";

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
                client.Authenticate(_fictionConfiguration.EmailAddress, _fictionConfiguration.EmailPassword);

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}