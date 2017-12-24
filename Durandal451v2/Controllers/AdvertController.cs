using Durandal451v2.Models.Dictionaries;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using UnitOfWork;

namespace Durandal451v2.Controllers
{
    [RoutePrefix("api/Advert")]
    public class AdvertController : ApiController
    {
        private readonly EFDbContext db = new EFDbContext();

        //[HttpGet]
        //[Route("GetDicCategories")]
        //public async Task<IHttpActionResult> GetDicCategories()
        //{
        //    try
        //    {
        //        var dbCategories = db.dicCategories.ToList();

        //        var categories = dbCategories
        //            .Select(
        //            x => new DicCategories()
        //            {
        //                id = x.CategoryId,
        //                text = x.Name
        //            })
        //            .ToList();

        //        return Ok(categories);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }


        //}
        [HttpGet]
        [Route("GetDicCategories")]
        public IHttpActionResult GetDicCategories()
        {
            try
            {
                var dbCategories = db.dicCategories.ToList();

                var categories = dbCategories
                    .Select(
                    x => new DicCategories()
                    {
                        id = x.CategoryId,
                        text = x.Name
                    })
                    .ToList();

                return Json(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}
