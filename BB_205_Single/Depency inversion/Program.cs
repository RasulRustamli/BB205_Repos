namespace Depency_inversion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Email email = new Email();
            Sms sms = new Sms();
            WhatsApp whatsApp = new WhatsApp();

            List<IMessageSender> senders = new List<IMessageSender>();
            senders.Add(email);
            senders.Add(whatsApp);
            senders.Add(sms);
            MessageService messageService = new MessageService(senders);
            messageService.Send();
        }
    }
}