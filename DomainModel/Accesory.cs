using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    [Table("Accessories")]
    public class Accesory : Subject
    {
        public string Brand { get; set; }
        
    }
}
