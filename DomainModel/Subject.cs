using DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Subject
    {
        [Key]
        public Int64 SubjectId { get;set;}
        public Int64 AdvertId { get; set; }
        public string AdvertName { get; set; }
        public string AdvertDescription { get; set; }
        public double Price { get; set; }
        public virtual Advert Advert { get; set; }
        public virtual Image Images { get; set; }
    }
}
