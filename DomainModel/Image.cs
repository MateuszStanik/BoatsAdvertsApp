using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    [Table("SubjectImages")]
    public class Image
    {
        [Key]
        public int ImageID { get; set; }
        public Int64 SubjectId { get; set; }
        public string Name { get; set; }
        public Guid Identifier { get; set; }
        public byte[] ImageData { get; set; }


    }
}
