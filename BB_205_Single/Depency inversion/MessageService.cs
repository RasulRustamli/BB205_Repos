using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depency_inversion
{
    internal class MessageService
    {
        //Email _email;
        //Sms _sms;
        //WhatsApp _whatsApp;

        List<IMessageSender> _messageSenders;

        public MessageService(List<IMessageSender> messageSenders)
        {
            _messageSenders = messageSenders;
        }

        public void Send()
        {
           foreach (var item in _messageSenders)
            {
                item.Send();
            }
        }
    }
}
