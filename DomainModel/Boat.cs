﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    [Table("Boats")]
    public class Boat : Subject
    {
        public string BrandName { get; set; }
        public decimal Lenght { get; set; }
        public DateTime BuiltYear { get; set; }
        public decimal Draft { get; set; }
        public decimal Displacement { get; set; }
        public virtual SailBoat SailBoat { get; set; }
        public virtual MotorBoat MotorBoat {get;set;} 
    }
}
