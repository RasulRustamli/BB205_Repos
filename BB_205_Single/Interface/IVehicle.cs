using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    internal interface IVehicle
    {
        public double Wheel { get; set; }
       

        public void Drive();
    }
}
