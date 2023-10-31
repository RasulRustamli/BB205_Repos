using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BB_205_Single
{
    internal class UserCheck
    {
        public bool UserNameCheck(string username)
        {
            Regex regex = new Regex(@"[A-Za-z]{8,}");

            if (regex.IsMatch(username))
            {
                return true;
            }
            return false;
        }
    }
}
