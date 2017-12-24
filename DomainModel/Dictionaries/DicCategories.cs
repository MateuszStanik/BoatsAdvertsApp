using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    [Table("DicCatogories")]
    public class DicCategories
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
