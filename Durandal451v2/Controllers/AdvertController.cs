using ApiContract;
using DomainModel;
using Durandal451v2.Models.Dictionaries;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
                    x => new Models.Dictionaries.DicCategories()
                    {
                        id = x.Id,
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

        [HttpPost]
        [Route("SaveAdvert")]
        public IHttpActionResult SaveAdvert(JObject content)
        {
            string subjectId = content["subjectType"].ToString();
            string jsonSubject = content["subject"].ToString();
            string jsonAdvert = content["contact"].ToString();
            string jsonProduct = content["product"].ToString();

            string Id = JsonConvert.DeserializeObject<string>(subjectId);
            var category = db.dicCategories.Where(x => x.Id == Id).FirstOrDefault();
         
            Advert advert = new Advert();
            advert = JsonConvert.DeserializeObject<Advert>(jsonAdvert);
            advert.AdditionDate = DateTime.Now;

            Subject subject = new Subject();
            subject = JsonConvert.DeserializeObject<Subject>(jsonSubject);
            subject.Advert = advert;
            
            try
            {
                switch (category.CategoryId)
                {               
                    case 1:
                        Boat sBoat = new Boat();
                        SailBoat sailboat = new SailBoat();
                        var boat = JsonConvert.DeserializeObject<Boat>(jsonSubject);
                        sBoat = JsonConvert.DeserializeObject<Boat>(jsonProduct);
                        sBoat.AdvertDescription = boat.AdvertDescription;
                        sBoat.AdvertName = boat.AdvertName;
                        sBoat.Price = boat.Price;
                        sBoat.Advert = advert;
                        sailboat = JsonConvert.DeserializeObject<SailBoat>(jsonProduct);
                        sBoat.SailBoat = sailboat;
                        db.boats.Add(sBoat);
                        db.SaveChanges();
                        break;
                    case 2:
                        Boat mBoat = new Boat();
                        MotorBoat motorBoat = new MotorBoat();
                        break;
                    case 3:
                        Engine engine = new Engine();
                        break;
               
                }
                //db.adverts.Add(advert);
                

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            return Ok(advert);
        }
    }
}
