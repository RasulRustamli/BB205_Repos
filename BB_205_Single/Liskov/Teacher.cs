using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liskov
{
    internal class Teacher : Person,IPersonExperince
    {
        public  void GetExperince()
        {
            Console.WriteLine("Teacherin experincesi");
        }

        public override void GetName()
        {
            Console.WriteLine("Mellimin adi");
        }

        public override void GetSurname()
        {
            Console.WriteLine("Mellimin soyadi");
        }
    }
}
