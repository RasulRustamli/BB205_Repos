using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bb205_Exception.Exceptions
{
    internal class AgeLimitException:Exception
    {
       
        public AgeLimitException(string message):base(message)
        {

        }

    }
}
