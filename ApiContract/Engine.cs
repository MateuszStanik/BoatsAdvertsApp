using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiContract
{
    public class Engine
    {
        public enum FuelType { Diesel, Gasoline }
        public enum EngineType { Outboard, Stationary }
        public string Brand { get; set; }
        public double Power { get; set; }
        public EngineType TypeOfEngine { get; set; }
        public FuelType TypeOfFuel { get; set; }
        public string BuiltYear { get; set; }

    }
}
