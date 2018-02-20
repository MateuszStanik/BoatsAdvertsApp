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

namespace Durandal451v2.Controllers
{
    //public class Image
    //{

    //    public int ImageID { get; set; }
    //    public string Name { get; set; }
    //    public byte[] ImageData { get; set; }
    //}

    [RoutePrefix("api/Advert")]
    public class AdvertController : ApiController
    {
        private readonly EFDbContext db = new EFDbContext();
        
        [HttpPost]
        [Route("UploadImage")]
        public IHttpActionResult UploadImage()
        {
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                string subjectId = HttpContext.Current.Request.Form[0];
                string jsonSubject = HttpContext.Current.Request.Form[1];
                string jsonAdvert = HttpContext.Current.Request.Form[2];
                string jsonProduct = HttpContext.Current.Request.Form[3];

                string Id = JsonConvert.DeserializeObject<string>(subjectId);
                var category = db.dicCategories.Where(x => x.Id == Id).FirstOrDefault();

                Advert advert = new Advert();
                advert = JsonConvert.DeserializeObject<Advert>(jsonAdvert);
                advert.AdditionDate = DateTime.Now;
                Boat sBoat = new Boat();

                try
                {
                    switch (category.CategoryId)
                    {
                        case 1:
                            
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
                            
                            break;
                        case 2:
                            Boat mBoat = new Boat();
                            MotorBoat motorBoat = new MotorBoat();
                            break;
                        case 3:
                            Engine engine = new Engine();
                            break;

                    }

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
 
                foreach (string fileName in HttpContext.Current.Request.Files)
                {                   
                    var httpPostedFile = HttpContext.Current.Request.Files[fileName];

                    if (httpPostedFile != null)
                    {
                        DomainModel.Image uploadedImg = new DomainModel.Image();
                        int length = httpPostedFile.ContentLength;
                        uploadedImg.ImageData = new byte[length];
                        httpPostedFile.InputStream.Read(uploadedImg.ImageData, 0, length);
                        uploadedImg.Name = Path.GetFileName(httpPostedFile.FileName);                   
                        uploadedImg.Identifier = Guid.NewGuid();
                        uploadedImg.Subject = sBoat;                        
                        db.images.Add(uploadedImg);                      
                        var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/AdvertImages"), httpPostedFile.FileName);
                        httpPostedFile.SaveAs(fileSavePath);                        
                    }
                }
                db.SaveChanges();
                return Ok();
            }
            return Ok();
        }

        [HttpGet]
        [Route("GetDicCategories")]
        public IHttpActionResult GetDicCategories()
        {
            try
            {
            //    int i = 1900;
            //    for (i = 1910; i <= 2018; i++)
            //    {
            //        Thread.Sleep(500);
            //        DicYearbooks tmp = new DicYearbooks();
            //        tmp.CategoryId = i;
            //        tmp.Year = i;

            //        db.dicYearbooks.Add(tmp);

            //    }
            //    db.SaveChanges();
                var dbCategories = db.dicCategories.ToList();

                var categories = dbCategories
                    .Select(
                    x => new Models.Dictionaries.Select2()
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

        [HttpGet]
        [Route("GetDicYearbooks")]
        public IHttpActionResult GetDicYearbooks()
        {
            try
            {
               
                var dbYearbooks = db.dicYearbooks.ToList();

                var categories = dbYearbooks
                    .Select(
                    x => new Models.Dictionaries.Select2_Int()
                    {
                        id = x.CategoryId,
                        text = x.Year
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

            return Ok(subject);
        }
    }
}
