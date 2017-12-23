using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    [Table("Adverts")]
    public class Advert
    {
        [Key]
        public long AdvertId { get; set; }
        public DateTime? AdditionDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public Advert() { }
    }
}
