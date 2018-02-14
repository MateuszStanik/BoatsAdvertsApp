using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using UnitOfWork;

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

    }
}