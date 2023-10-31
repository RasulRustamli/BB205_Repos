using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liskov
{
    internal class Developer : Person,IPersonExperince
    {
        public void GetExperince()
        {
            Console.WriteLine("Developerin tecrubesi");
        }

        public override void GetName()
        {
            Console.WriteLine("developerin adi");
        }

        public override void GetSurname()
        {
            Console.WriteLine("developerin soyadi");
        }
    }
}
