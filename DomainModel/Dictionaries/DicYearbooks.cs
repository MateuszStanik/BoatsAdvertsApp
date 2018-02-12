using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Dictionaries
{
    [Table("DicYearbooks")]
    public class DicYearbooks
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int Year { get; set; }
    }
}
