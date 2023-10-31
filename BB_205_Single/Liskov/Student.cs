using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liskov
{
    internal class Student : Person
    {
       

        public override void GetName()
        {
            Console.WriteLine("Telebenin adi");
        }

        public override void GetSurname()
        {
            Console.WriteLine("Telebenin soyadi");
        }
    }
}
