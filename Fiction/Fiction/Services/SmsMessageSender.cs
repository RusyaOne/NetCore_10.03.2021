using Fiction.Infrastructure;
using Microsoft.Extensions.Options;
using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Fiction.Services
{
    public class SmsMessageSender : IMessageSender
    {
        private readonly FictionConfiguration _configuration;

        public SmsMessageSender(IOptions<FictionConfiguration> options)
        {
            _configuration = options.Value;
        }

        public void SendMessage()
        {
            TwilioClient.Init(_configuration.TwilioAccountSid, _configuration.TwilioAccountAuthToken);

            var result = MessageResource.Create(
                body: "This is very important message from Twilio",
                from: new Twilio.Types.PhoneNumber(_configuration.TwilioAccountPhoneNumber),
                to: new Twilio.Types.PhoneNumber(_configuration.RecipientPhoneNumber)
            );

            Console.WriteLine(result.Sid);
        }
    }
}