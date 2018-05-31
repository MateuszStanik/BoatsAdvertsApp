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

    [RoutePrefix("api/Advert")]
    public class AdvertController : ApiController
    {
        IMapper _mapper;
        IEFDbContext _db;
        //private readonly EFDbContext _db = new EFDbContext();

        public AdvertController(IMapper mapper, IEFDbContext db)
        {
            _mapper = mapper;
            _db = db;
        }

        [HttpPost]
        [Route("MockData")]
        public async Task<IHttpActionResult> mockData(int counter)
        {

            string[] Names = { "Maggie", "Penny", "Magdalena", "Joanna", "Zuzanna", "Tomasz", "Marcin", "Jacek", "Mateusz", "Aleksander", "Jurek", "Abby", "Laila", "Sadie", "Olivia", "Ola", "Starlight", "Talla", "Zbigniew", "Jola" };
            string[] Surenames = { "Poloczek", "Nowak", "Cudzoziemiec", "Kwiatek", "K³y¿", "Ziêba", "Miodek", "Halama", "Nehru", "Boczek", "O³ówek", "Niestolik" };
            string[] City = { "Sarnów", "Gorzów Wielkopolski", "Warszawa", "Kraków", "Katowice", "Gdañsk", "S³upsk", "Przemyœl", "Bielsko Bia³a", "¯ywiec", "Szczecin", "Poznañ" };
            string[] Email = { "zagle@wp.pl", "k.jolka@gmail.com", "matstanik@gmail.com", "kowal@onet.pl", "jachting@gmail.com" };
            string[] Phones = { "129483958", "837495837", "098273475", "283950392", "898127847", "988372982", "783917284" };
            try
            {
                for (int i = 0; i < counter; i++)
                {
                    int rand = new Random().Next(1, 6);
                    DomainModel.Advert advert = new DomainModel.Advert();
                    advert.AdditionDate = DateTime.Now;
                    advert.AdditionalInformation = "Brak informacji dodatkowych na temat og³oszenia";
                    advert.City = City[new Random().Next(0, 11)];
                    advert.Email = Email[new Random().Next(0, 4)];
                    advert.FinishDate = DateTime.Now.AddDays(7);
                    advert.Name = Names[new Random().Next(0, 20)];
                    advert.PhoneNumber = Phones[new Random().Next(0, 6)];
                    advert.SureName = Surenames[new Random().Next(1, 12)];
                    switch (rand) 
                    {
                        case 1:                           
                            DomainModel.Engine subject = new DomainModel.Engine();
                            subject.Advert = advert;
                            subject.AdvertDescription = "Sprzedam silnki u¿ywany, dwusuwowy.";
                            subject.AdvertName = "Silnik mercury";
                            subject.Brand = "Mercury";
                            subject.BuiltYear = new Random().Next(1970, 2018).ToString();
                            subject.CategoryId = 3;
                            subject.Power = new Random().Next(1, 1000);
                            subject.Price = new Random().Next(2000, 400000);
                            subject.TypeOfEngine = DomainModel.Engine.EngineType.Outboard;
                            subject.TypeOfFuel = DomainModel.Engine.FuelType.Gasoline;
                            DomainModel.Image uploadedImg = new DomainModel.Image();
                            int length = new Random().Next(1000, 99999);
                            uploadedImg.ImageData = new byte[length];
                            uploadedImg.Name = "silnikMercury";
                            uploadedImg.Identifier = Guid.NewGuid();
                            uploadedImg.Subject = subject;
                            _db.images.Add(uploadedImg);
                            _db.SaveChanges();
                            break;
                        case 2:                           
                            DomainModel.Trailor subjectTrailor = new DomainModel.Trailor();
                            subjectTrailor.Advert = advert;
                            subjectTrailor.AdvertDescription = "Sprzedam przyczepe u¿ywan¹ typu laweta.";
                            subjectTrailor.AdvertName = "Przyczepa laweta";
                            subjectTrailor.Brand = "Branderup";
                            subjectTrailor.BuiltYear = new Random().Next(1970, 2018).ToString();
                            subjectTrailor.CategoryId = 4;
                            subjectTrailor.Capcity = new Random().Next(100, 40000);
                            subjectTrailor.Price = new Random().Next(1500, 20000);
                            subjectTrailor.Length = new Random().Next(4, 10);
                            subjectTrailor.Weight = new Random().Next(100, 1000);
                            subjectTrailor.Width = new Random().Next(1, 3);
                            DomainModel.Image uploadedImgTrailor = new DomainModel.Image();
                            int lengthTrailorImage = new Random().Next(1000, 99999);
                            uploadedImgTrailor.ImageData = new byte[lengthTrailorImage];
                            uploadedImgTrailor.Name = "Przyczepa";
                            uploadedImgTrailor.Identifier = Guid.NewGuid();
                            uploadedImgTrailor.Subject = subjectTrailor;
                            _db.images.Add(uploadedImgTrailor);
                            _db.SaveChanges();
                            break;
                        case 3:                           
                            Boat subjectBoat = new Boat();
                            SailBoat sailboat = new SailBoat();
                            subjectBoat.AdvertDescription = "Sprzedam ¿aglówke, pierwszy w³aœciciel, jednomasztowa";
                            subjectBoat.AdvertName = "Venuska";
                            subjectBoat.Price = new Random().Next(1000, 99999);
                            subjectBoat.Advert = advert;
                            sailboat.EnginePower = new Random().Next(10, 888);
                            sailboat.EngineType = 1;
                            sailboat.HullType = "Kilowa";
                            sailboat.IsEngine = true;
                            sailboat.RudderType = "Rumpel";
                            sailboat.SailsArea = new Random().Next(5, 40);
                            sailboat.YachtType = "kilowy";
                            sailboat.Boat = subjectBoat;
                            subjectBoat.CategoryId = 1;
                            subjectBoat.SailBoat = sailboat;
                            DomainModel.Image uploadedImgSailboat = new DomainModel.Image();
                            int lengthSailboatImage = new Random().Next(1000, 99999);
                            uploadedImgSailboat.ImageData = new byte[lengthSailboatImage];
                            uploadedImgSailboat.Name = "£ódŸ ¿aglowa";
                            uploadedImgSailboat.Identifier = Guid.NewGuid();
                            uploadedImgSailboat.Subject = subjectBoat;
                            _db.images.Add(uploadedImgSailboat);
                            _db.SaveChanges();
                            break;
                        case 4:                           
                            Boat subjectMotorBoat = new Boat();
                            MotorBoat motorboat = new MotorBoat();
                            subjectMotorBoat.AdvertDescription = "Sprzedam ¿aglówke, pierwszy w³aœciciel, jednomasztowa";
                            subjectMotorBoat.AdvertName = "Venuska";
                            subjectMotorBoat.Price = new Random().Next(1000, 99999);
                            subjectMotorBoat.Advert = advert;
                            motorboat.EnginePower = new Random().Next(10, 888);
                            motorboat.MotorboatType = 1;                            
                            motorboat.Boat = subjectMotorBoat;
                            subjectMotorBoat.CategoryId = 2;
                            subjectMotorBoat.MotorBoat = motorboat;
                            DomainModel.Image uploadedImgMotorboat = new DomainModel.Image();
                            int lengthMotorboatImage = new Random().Next(1000, 99999);
                            uploadedImgMotorboat.ImageData = new byte[lengthMotorboatImage];
                            uploadedImgMotorboat.Name = "£ódŸ motorowdna";
                            uploadedImgMotorboat.Identifier = Guid.NewGuid();
                            uploadedImgMotorboat.Subject = subjectMotorBoat;
                            _db.images.Add(uploadedImgMotorboat);
                            _db.SaveChanges();
                            break;
                        case 5:
                            Sail sails = new Sail();
                            sails.Advert = advert;
                            sails.AdvertDescription = "";
                            sails.AdvertName = "Sprzedam ¿agiel - u¿ywany";
                            sails.Brand = "NorthSails";
                            sails.CategoryId = 5;
                            sails.FootLenght = new Random().Next(1, 3); 
                            sails.LeechLenght = new Random().Next(1, 6);
                            sails.LuffLenght = new Random().Next(1, 6); 
                            sails.Price = new Random().Next(100, 1200); 
                            sails.SailArea = new Random().Next(2, 20);
                            DomainModel.Image uploadedImgSails = new DomainModel.Image();
                            int lengthSailsImage = new Random().Next(1000, 99999);
                            uploadedImgSails.ImageData = new byte[lengthSailsImage];
                            uploadedImgSails.Name = "¯agiel";
                            uploadedImgSails.Identifier = Guid.NewGuid();
                            uploadedImgSails.Subject = sails;
                            _db.images.Add(uploadedImgSails);
                            _db.SaveChanges();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
           
            

           
            return Ok();
        }
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
                DomainModel.Advert advert = new DomainModel.Advert();
                advert = JsonConvert.DeserializeObject<DomainModel.Advert>(jsonAdvert);
                advert.AdditionDate = DateTime.Now;
        
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
                            subject = new DomainModel.Engine();
                            ApiContract.Subject enginePar = JsonConvert.DeserializeObject<ApiContract.Subject>(jsonSubject);
                            ApiContract.Engine subjectApiContract = JsonConvert.DeserializeObject<ApiContract.Engine>(jsonProduct);
                            _mapper.Map<ApiContract.Subject, DomainModel.Engine>(enginePar, subject);
                            _mapper.Map<ApiContract.Engine, DomainModel.Engine>(subjectApiContract, subject);
                           
                            //subject.Price = subjectJsonPar.Price;
                            //subject.BuiltYear = subjectJsonPar.BuiltYear;
                            //subject.Brand = subjectJsonPar.Brand;
                            //subject.Power = subjectJsonPar.Power;
                            //subject.TypeOfEngine = subjectJsonPar.TypeOfEngine;
                            //subject.TypeOfFuel = subjectJsonPar.TypeOfFuel;
                            //subject = enginePar;
                            //subject.Brand = enginePar.Brand;
                            subject.CategoryId = category.CategoryId;
                            subject.Advert = advert;                           

                            break;
                        case 4:
                            subject = new Trailor();
                            var trailorParams = JsonConvert.DeserializeObject<Trailor>(jsonSubject);
                            subject = JsonConvert.DeserializeObject<Trailor>(jsonProduct);
                            subject.CategoryId = category.CategoryId;
                            subject.Advert = advert;
                            break;
                        case 5:
                            subject = new Sail();
                            var sailParams = JsonConvert.DeserializeObject<Sail>(jsonSubject);
                            subject = JsonConvert.DeserializeObject<Sail>(jsonProduct);
                            subject.CategoryId = category.CategoryId;
                            subject.Advert = advert;
                            break;
                        case 6:
                            subject = new Accesory();
                            var accessoryParams = JsonConvert.DeserializeObject<Accesory>(jsonSubject);
                            subject = JsonConvert.DeserializeObject<Accesory>(jsonProduct);
                            subject.CategoryId = category.CategoryId;
                            subject.Advert = advert;
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