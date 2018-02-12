using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    [Table("SailBoat")]
    public class SailBoat
    {
        [Key, ForeignKey("Boat")]
        public long SubjectId { get; set; }
        public decimal SailsArea { get; set; }
        public bool IsEngine { get; set; }
        public decimal EnginePower { get; set; }
        public byte EngineType { get; set; }
        public string HullType { get; set; }
        public string YachtType { get; set; }
        public string RudderType { get; set; }
        public virtual Boat Boat { get; set; }

    }
}
