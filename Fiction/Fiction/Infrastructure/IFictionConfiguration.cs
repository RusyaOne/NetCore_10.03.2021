namespace Fiction.Infrastructure
{
    public interface IFictionConfiguration
    {
        string SenderEmailAddress { get; set; }
        string SenderEmailPassword { get; set; }
        string TwilioAccountSid { get; set; }
        string TwilioAccountAuthToken { get; set; }
        string TwilioAccountPhoneNumber { get; set; }
        string RecipientPhoneNumber { get; set; }
    }
}