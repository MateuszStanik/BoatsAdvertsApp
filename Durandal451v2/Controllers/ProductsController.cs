using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using UnitOfWork;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using DomainModel;
using BoatsAdvertsApp.Models;

namespace Durandal451v2.Controllers
{
    [RoutePrefix("api/Products")]
    public class ProductsController : ApiController
    {
        private readonly EFDbContext db = new EFDbContext();

        [HttpGet]
        [Route("test")]
        public IHttpActionResult test()
        {
            
            return Ok();
        }


        [HttpGet]
        [Route("GetAllProducts")]
        public IHttpActionResult GetAllProducts()
        {
            List<Subject> productsList = db.subjects.ToList();
            
            var products = productsList
                .Select(
                x => new ProductInfo()
                {
                    AdvertDescription = x.AdvertDescription,
                    AdvertId = x.AdvertId,
                    SubjectId = x.SubjectId,
                    AdvertName = x.AdvertName,
                    Price = x.Price,
                    Image = "../../AdvertImages/" + db.images.Where(y=>y.Subject.SubjectId == x.SubjectId).FirstOrDefault().Name 
                })
                .ToList();

            return Ok(products);
        }
        [HttpGet]
        [Route("GatImages")]
        public IHttpActionResult GetImages(long id)
        {
            string name = "";
            var image = db.images.Where(x => x.Subject.SubjectId == id).ToList();

            name = image[0].Name;
            return Ok(name);
        }
    }
}