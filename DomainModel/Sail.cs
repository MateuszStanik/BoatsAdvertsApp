using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    [Table("Sails")]
    public class Sail : Subject
    {
        public double LeechLenght { get; set; }
        public double FootLenght { get; set; }
        public double LuffLenght { get; set; }
        public string Brand { get; set; }
        public double SailArea { get; set; }
    }
}
