using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Open_Closed
{
    internal class AreaCalculate
    {


        public double Area { get; set; }

        //public double AreaCalculator(object figure)
        //{
        //    //if(figure is Circle)
        //    //{
        //    //    Circle circle = (Circle)figure;

        //    //    Area = Math.Pow(circle.Radius, 2) * Math.PI;//area=radius^2*pi
        //    //}
        //    //else if(figure is Square)
        //    //{
        //    //    Square square = (Square)figure;
        //    //    Area = Math.Pow(square.Kenar, 2);
        //    //}

        //    return Area;
        //}

        public double AreaCalculator(Figure figure)
        {
            return figure.AreaCall();
        }
    }
}
