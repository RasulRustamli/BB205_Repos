using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB205_Static_class.Models
{
    internal  class Person
    {
        public string Id;
        public static int count=100;
        public  string  Name { get; set; }
       
      
        public Person()
        {
            Console.WriteLine("Obyekt yaradildi");
            
        }
        public static void GetFullName(Person person)
        {

            Console.WriteLine($"name :");
        }
            


    }
}
