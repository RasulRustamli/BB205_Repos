using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Depency_inversion
{
    internal class Email:IMessageSender
    {

        public void Send()
        {
            Console.WriteLine("Send email service");
        }
    }
}
