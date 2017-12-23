using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    [Table("MotorBoat")]
    public class MotorBoat
    {
        [Key, ForeignKey("Boat")]
        public long SubjectId { get; set; }
        public decimal EnginePower { get; set; }
        public byte MotorboatType { get; set; }
        public virtual Boat Boat { get; set; }
    }
}
