using BB205_Static_class.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB205_Static_class.Helper
{
    internal static  class Extensions
    {

        public static string ReverseString(this string word,char a,string name)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = word.Length - 1; i >= 0; i--)
            {
                sb.Append(word[i]);
            }
            return sb.ToString().ToLower();
        }
        public static void GetFullName(this Person person)
        {
            Console.WriteLine(person.Name);
        }
    }
}
