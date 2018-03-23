using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    [Table("Engines")]
    public class Engine : Subject
    {
        public enum FuelType { Diesel, Gasoline}
        public enum EngineType { Outboard, Stationary }
        public string Brand { get; set; }
        public double Power { get; set; }
        public EngineType TypeOfEngine { get; set; }
        public FuelType TypeOfFuel { get; set; }
        public string BuiltYear { get; set; }
    }
}
