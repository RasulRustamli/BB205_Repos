using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open_Closed
{
    internal class Square:Figure
    {
        public double Kenar { get; set; }

        public override double AreaCall()
        {
            return Math.Pow(Kenar, 2);
        }

    }
}
