using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoatsAdvertsApp.Models
{
    public class ProductInfo
    {
        public long SubjectId { get;set;}
        public long AdvertId { get;set;}
        public double Price { get; set; }
        public string AdvertDescription { get; set; }
        public string AdvertName {get;set;}
        public string Image { get; set; }

    }
}