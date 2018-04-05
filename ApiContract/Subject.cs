using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiContract
{
    public class Subject
    {
        public Int64 SubjectId { get; set; }
        public Int64 AdvertId { get; set; }
        public Int64 CategoryId { get; set; }
        public string AdvertName { get; set; }
        public string AdvertDescription { get; set; }
        public double Price { get; set; }
        public virtual Advert Advert { get; set; }
    }
}
