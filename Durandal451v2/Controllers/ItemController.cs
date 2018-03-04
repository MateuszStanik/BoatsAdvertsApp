using ApiContract;
using DomainModel;
using DomainModel.Dictionaries;
using Durandal451v2.Models.Dictionaries;
using Microsoft.Owin;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using UnitOfWork;

namespace BoatsAdvertsApp.Controllers
{
    [RoutePrefix("api/Item")]
    public class ItemController : ApiController
    {
        private readonly EFDbContext db = new EFDbContext();

        [HttpGet]
        [Route("GetItemDetails")]
        public IHttpActionResult GetItemDetails(long subjectId)
        {
            try
            {
             
                var dbCategories = db.subjects.Where(x=>x.SubjectId == subjectId).FirstOrDefault();


                return Json(dbCategories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpGet]
        [Route("GetItemImages")]
        public IHttpActionResult GetItemImages(long subjectId)
        {
            try
            {

                var dbImages = db.images.Where(x => x.Subject.SubjectId == subjectId).ToList();

                var response = dbImages.
                    Select(x => new { image = "../../AdvertImages/" + x.Name }

                    ).ToList();

                

                return Json(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}