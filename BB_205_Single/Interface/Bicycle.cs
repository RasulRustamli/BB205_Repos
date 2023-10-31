using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    internal class Bicycle : IVehicle
    {
        public double Motor { get ; set ; }
        public double HorsePower { get ; set ; }
        public double FuelCapacity { get ; set; }
        public double Wheel { get; set; }

        public void Drive()
        {
            throw new NotImplementedException();
        }
    }
}
