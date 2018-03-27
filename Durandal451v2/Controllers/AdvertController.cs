using ApiContract;
using AutoMapper;
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
using UnitOfWork.Abstract;

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
        IMapper _mapper;
       // IEFDbContext _db;
        private readonly EFDbContext _db = new EFDbContext();
        
        //public AdvertController(IMapper mapper)
        //{
        //    _mapper = mapper;
        //    //_db = db;
        //}

        [HttpPost]
        [Route("UploadImage")]
        public async Task<IHttpActionResult> UploadImage()
        {
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                string subjectId = HttpContext.Current.Request.Form[0];
                string jsonSubject = HttpContext.Current.Request.Form[1];
                string jsonAdvert = HttpContext.Current.Request.Form[2];
                string jsonProduct = HttpContext.Current.Request.Form[3];
                string Id = JsonConvert.DeserializeObject<string>(subjectId);
                var category = _db.dicCategories.Where(x => x.Id == Id).FirstOrDefault();
                Advert advert = new Advert();
                advert = JsonConvert.DeserializeObject<Advert>(jsonAdvert);
                advert.AdditionDate = DateTime.Now;
                
                //var subject =new Boat();
                dynamic subject = null;
                try
                {
                    switch (category.CategoryId)
                    {
                        case 1:
                            subject = new Boat();
                            SailBoat sailboat = new SailBoat();
                            var boat = JsonConvert.DeserializeObject<Boat>(jsonSubject);
                            subject = JsonConvert.DeserializeObject<Boat>(jsonProduct);
                            subject.AdvertDescription = boat.AdvertDescription;
                            subject.AdvertName = boat.AdvertName;
                            subject.Price = boat.Price;
                            subject.Advert = advert;
                            sailboat = JsonConvert.DeserializeObject<SailBoat>(jsonProduct);
                            subject.SailBoat = sailboat;
                            subject.CategoryId = category.CategoryId;
                            _db.boats.Add(subject);                            
                            break;
                        case 2:
                            subject = new Boat();
                            MotorBoat motorBoat = new MotorBoat();
                            var mBoat = JsonConvert.DeserializeObject<Boat>(jsonSubject);
                            subject = JsonConvert.DeserializeObject<Boat>(jsonProduct);
                            subject.AdvertDescription = mBoat.AdvertDescription;                           
                            subject.AdvertName = mBoat.AdvertName;
                            subject.Price = mBoat.Price;
                            subject.Advert = advert;
                            motorBoat = JsonConvert.DeserializeObject<MotorBoat>(jsonProduct);
                            subject.MotorBoat = motorBoat;
                            subject.CategoryId = category.CategoryId;
                            

                            break;
                        case 3:
                            subject = new Engine();
                            var enginePar = JsonConvert.DeserializeObject<Engine>(jsonSubject);
                            subject = JsonConvert.DeserializeObject<Engine>(jsonProduct);
                            subject.Advert = advert;
                            subject = enginePar;
                            subject.Brand = enginePar.Brand;
                            
                            
                            break;

                    }

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
                try
                {
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
                            uploadedImg.Subject = subject;
                            
                            _db.images.Add(uploadedImg);
                            var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/AdvertImages"), httpPostedFile.FileName);
                            httpPostedFile.SaveAs(fileSavePath);
                        }
                    }
                    _db.SaveChanges();
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
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
                var dbCategories = _db.dicCategories.ToList();

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
               
                var dbYearbooks = _db.dicYearbooks.ToList();

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

        //[HttpPost]
        //[Route("SaveAdvert")]
        //public IHttpActionResult SaveAdvert(JObject content)
        //{
        //    string subjectId = content["subjectType"].ToString();
        //    string jsonSubject = content["subject"].ToString();
        //    string jsonAdvert = content["contact"].ToString();
        //    string jsonProduct = content["product"].ToString();

        //    string Id = JsonConvert.DeserializeObject<string>(subjectId);
        //    var category = _db.dicCategories.Where(x => x.Id == Id).FirstOrDefault();

        //    Advert advert = new Advert();
        //    advert = JsonConvert.DeserializeObject<Advert>(jsonAdvert);
        //    advert.AdditionDate = DateTime.Now;

        //    Subject subject = new Subject();
        //    subject = JsonConvert.DeserializeObject<Subject>(jsonSubject);
        //    subject.Advert = advert;

        //    try
        //    {
        //        switch (category.CategoryId)
        //        {
        //            case 1:
        //                Boat sBoat = new Boat();
        //                SailBoat sailboat = new SailBoat();
        //                var boat = JsonConvert.DeserializeObject<Boat>(jsonSubject);
        //                sBoat = JsonConvert.DeserializeObject<Boat>(jsonProduct);
        //                sBoat.AdvertDescription = boat.AdvertDescription;
        //                sBoat.AdvertName = boat.AdvertName;
        //                sBoat.Price = boat.Price;
        //                sBoat.Advert = advert;
        //                sailboat = JsonConvert.DeserializeObject<SailBoat>(jsonProduct);
        //                sBoat.SailBoat = sailboat;
        //                db.boats.Add(sBoat);
        //                db.SaveChanges();
        //                break;
        //            case 2:
        //                Boat mBoat = new Boat();
        //                MotorBoat motorBoat = new MotorBoat();
        //                break;
        //            case 3:
        //                Engine engine = new Engine();
        //                break;

        //        }
        //        //db.adverts.Add(advert);


        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //    return Ok(subject);
        //}
    }
}
