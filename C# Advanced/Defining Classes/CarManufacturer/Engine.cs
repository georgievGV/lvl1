using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Engine
    {
        public Engine(int horsePower, double cubicCapasity)
        {
            HorsePower = horsePower;
            CubicCapacity = cubicCapasity;
        }

        public int HorsePower { get; set; }
        public double CubicCapacity { get; set; }
    }
}
