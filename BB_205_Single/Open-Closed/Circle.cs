using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open_Closed
{
    internal class Circle:Figure
    {
        public double Radius { get; set; }

        public override double AreaCall()
        {
            return Math.Pow(Radius, 2)*Math.PI;
        }
    }
}
