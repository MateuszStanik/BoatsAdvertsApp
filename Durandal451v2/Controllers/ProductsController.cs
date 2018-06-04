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
using AutoMapper;
using UnitOfWork.Abstract;
using System.Diagnostics;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Durandal451v2.Controllers
{
    [RoutePrefix("api/Products")]
    public class ProductsController : ApiController
    {
        IMapper _mapper;
        IEFDbContext _db;
        private readonly EFDbContext db = new EFDbContext();

        public ProductsController(IMapper mapper, IEFDbContext db)
        {
            _mapper = mapper;
            _db = db;
        }

        [HttpGet]
        [Route("TestORM")]
        public IHttpActionResult TestORM()
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            //   List<Boat> boat = _db.boats.Where(x=>x.SailBoat.EnginePower> 500).ToList();
            //foreach (Boat singleBoat in boat)
            //{
            //    singleBoat.Price = 10101;
            //}
            //Boat boat = _db.boats.Where(x=>x.Advert.Name == "Abby" && x.Advert.SureName == "Halama" && x.Advert.Email == "testUpdate@gmail.com").FirstOrDefault();
            //boat.SailBoat.EnginePower = 11;
            //_db.SaveChanges();
            //_db.adverts.Add(new Advert { AdditionalInformation = "brak", AdditionDate = DateTime.Now, City = "Katowice", Email = "test@gmail.col", FinishDate = DateTime.Now.AddDays(5), Name = "Mateusz", SureName = "Stanik", PhoneNumber = "234234323" });
            //Boat boat = new Boat {
            //    Advert = new Advert{
            //        AdditionalInformation = "brak",
            //        AdditionDate = DateTime.Now,
            //        City = "Katowice",
            //        Email = "test@gmail.col",
            //        FinishDate = DateTime.Now.AddDays(5),
            //        Name = "Mateusz",
            //        SureName = "Stanik",
            //        PhoneNumber = "234234323"
            //    },
            //    AdvertDescription = "Brak informacji na temat przedmiotu",
            //    SailBoat = new SailBoat {
            //        EnginePower = 324,
            //        EngineType = 1,
            //        HullType = "MONOHULL",
            //        IsEngine = true,
            //        RudderType = "Zaburtowy",
            //        SailsArea = 23,
            //        YachtType = "Brak",
            //    },
            //    AdvertName = "sorzedam żaglówke",
            //    BuiltYear = "1999",
            //    Price = 8090,
            //    Weight = 23,
            //    Beam = 32,
            //    CategoryId = 1,
            //    ProducentName = "test"
            //};
            for (int i = 0; i < 20; i++)
            {
                var boat = new Boat {
                    Advert = new Advert{
                        AdditionalInformation = "brak",
                        AdditionDate = DateTime.Now,
                        City = "Katowice",
                        Email = "test@gmail.col",
                        FinishDate = DateTime.Now.AddDays(5),
                        Name = "Mateusz",
                        SureName = "Stanik",
                        PhoneNumber = "234234323"
                    },
                    AdvertDescription = "Brak informacji na temat przedmiotu",
                    SailBoat = new SailBoat {
                        EnginePower = 324,
                        EngineType = 1,
                        HullType = "MONOHULL",
                        IsEngine = true,
                        RudderType = "Zaburtowy",
                        SailsArea = 23,
                        YachtType = "Brak",
                    },
                    AdvertName = "sorzedam żaglówke",
                    BuiltYear = "1999",
                    Price = 8090,
                    Weight = 23,
                    Beam = 32,
                    CategoryId = 1,
                    ProducentName = "test"
                };
            
                _db.boats.Add(boat);
                _db.SaveChanges();
            }
            stopWatch.Stop();
            System.Diagnostics.Debug.WriteLine("Czas wykonania1: " + stopWatch.ElapsedMilliseconds);
            return Ok();   
        }

        [HttpGet]
        [Route("TestSQL")]
        public IHttpActionResult TestSQL()
        {
            SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["BoatsAdverts"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            cmd.Connection = sqlConnection1;
            sqlConnection1.Open();

            Stopwatch stopWatch = Stopwatch.StartNew();
            //cmd.CommandText = "Update Subjects Set Price = 51234 from Subjects INNER JOIN SailBoat on Subjects.SubjectId = SailBoat.SubjectId where SailBoat.EnginePower > 500";
            //cmd.CommandText = "Update SailBoat Set EnginePower = 22 from SailBoat INNER JOIN Subjects on SailBoat.SubjectId = Subjects.SubjectId Inner JOIN Adverts on Subjects.AdvertId = Adverts.AdvertId where Adverts.Name = 'Abby' and Adverts.SureName = 'Halama' and Email = 'testUpdate@gmail.com'";

            //"insert into Adverts  values('2018-06-03 16:54:27', '2018-06-08 16:54:27', 'Mateusz', 'Stanik', '234234323', 'test@gmail.col', 'Katowice', 'brak'); insert into Subjects values (26435, 1, 'sorzedam żaglówke', 'Brak informacji na temat przedmiotu', 33); insert into Boats values (14118, 'test', '0', 32, 23, 44, '1999', 0, 0); insert into SailBoat values (14118, 23, 'True', 3, 1, 'MONOHULL', 'Brak', 'Zaburtowy'); " +
            //"insert into Adverts  values('2018-06-03 16:54:27', '2018-06-08 16:54:27', 'Mateusz', 'Stanik', '234234323', 'test@gmail.col', 'Katowice', 'brak'); insert into Subjects values (26436, 1, 'sorzedam żaglówke', 'Brak informacji na temat przedmiotu', 33); insert into Boats values (14119, 'test', '0', 32, 23, 44, '1999', 0, 0); insert into SailBoat values (14119, 23, 'True', 3, 1, 'MONOHULL', 'Brak', 'Zaburtowy'); " +
            //"insert into Adverts values ('2018-06-03 16:54:27', '2018-06-08 16:54:27', 'Mateusz', 'Stanik', '234234323', 'test@gmail.col', 'Katowice', 'brak'); insert into Subjects values (26437, 1, 'sorzedam żaglówke', 'Brak informacji na temat przedmiotu', 33); insert into Boats values (14120, 'test', '0', 32, 23, 44, '1999', 0, 0); insert into SailBoat values (14120, 23, 'True', 3, 1, 'MONOHULL', 'Brak', 'Zaburtowy'); " +
            //"insert into Adverts values ('2018-06-03 16:54:27', '2018-06-08 16:54:27', 'Mateusz', 'Stanik', '234234323', 'test@gmail.col', 'Katowice', 'brak'); insert into Subjects values (26438, 1, 'sorzedam żaglówke', 'Brak informacji na temat przedmiotu', 33); insert into Boats values (14121, 'test', '0', 32, 23, 44, '1999', 0, 0); insert into SailBoat values (14121, 23, 'True', 3, 1, 'MONOHULL', 'Brak', 'Zaburtowy'); " +
            //"insert into Adverts values ('2018-06-03 16:54:27', '2018-06-08 16:54:27', 'Mateusz', 'Stanik', '234234323', 'test@gmail.col', 'Katowice', 'brak'); insert into Subjects values (26439, 1, 'sorzedam żaglówke', 'Brak informacji na temat przedmiotu', 33); insert into Boats values (14122, 'test', '0', 32, 23, 44, '1999', 0, 0); insert into SailBoat values (14122, 23, 'True', 3, 1, 'MONOHULL', 'Brak', 'Zaburtowy'); " +
            //"insert into Adverts values ('2018-06-03 16:54:27', '2018-06-08 16:54:27', 'Mateusz', 'Stanik', '234234323', 'test@gmail.col', 'Katowice', 'brak'); insert into Subjects values (26440, 1, 'sorzedam żaglówke', 'Brak informacji na temat przedmiotu', 33); insert into Boats values (14123, 'test', '0', 32, 23, 44, '1999', 0, 0); insert into SailBoat values (14123, 23, 'True', 3, 1, 'MONOHULL', 'Brak', 'Zaburtowy'); " +
            //"insert into Adverts values ('2018-06-03 16:54:27', '2018-06-08 16:54:27', 'Mateusz', 'Stanik', '234234323', 'test@gmail.col', 'Katowice', 'brak'); insert into Subjects values (26441, 1, 'sorzedam żaglówke', 'Brak informacji na temat przedmiotu', 33); insert into Boats values (14124, 'test', '0', 32, 23, 44, '1999', 0, 0); insert into SailBoat values (14124, 23, 'True', 3, 1, 'MONOHULL', 'Brak', 'Zaburtowy'); " +
            //"insert into Adverts values ('2018-06-03 16:54:27', '2018-06-08 16:54:27', 'Mateusz', 'Stanik', '234234323', 'test@gmail.col', 'Katowice', 'brak'); insert into Subjects values (26442, 1, 'sorzedam żaglówke', 'Brak informacji na temat przedmiotu', 33); insert into Boats values (14125, 'test', '0', 32, 23, 44, '1999', 0, 0); insert into SailBoat values (14125, 23, 'True', 3, 1, 'MONOHULL', 'Brak', 'Zaburtowy'); " +
            //"insert into Adverts values ('2018-06-03 16:54:27', '2018-06-08 16:54:27', 'Mateusz', 'Stanik', '234234323', 'test@gmail.col', 'Katowice', 'brak'); insert into Subjects values (26443, 1, 'sorzedam żaglówke', 'Brak informacji na temat przedmiotu', 33); insert into Boats values (14126, 'test', '0', 32, 23, 44, '1999', 0, 0); insert into SailBoat values (14126, 23, 'True', 3, 1, 'MONOHULL', 'Brak', 'Zaburtowy'); " +
            //"insert into Adverts values ('2018-06-03 16:54:27', '2018-06-08 16:54:27', 'Mateusz', 'Stanik', '234234323', 'test@gmail.col', 'Katowice', 'brak'); insert into Subjects values (26444, 1, 'sorzedam żaglówke', 'Brak informacji na temat przedmiotu', 33); insert into Boats values (14127, 'test', '0', 32, 23, 44, '1999', 0, 0); insert into SailBoat values (14127, 23, 'True', 3, 1, 'MONOHULL', 'Brak', 'Zaburtowy'); " +
            //"insert into Adverts values ('2018-06-03 16:54:27', '2018-06-08 16:54:27', 'Mateusz', 'Stanik', '234234323', 'test@gmail.col', 'Katowice', 'brak'); insert into Subjects values (26445, 1, 'sorzedam żaglówke', 'Brak informacji na temat przedmiotu', 33); insert into Boats values (14128, 'test', '0', 32, 23, 44, '1999', 0, 0); insert into SailBoat values (14128, 23, 'True', 3, 1, 'MONOHULL', 'Brak', 'Zaburtowy'); " +
            //"insert into Adverts values ('2018-06-03 16:54:27', '2018-06-08 16:54:27', 'Mateusz', 'Stanik', '234234323', 'test@gmail.col', 'Katowice', 'brak'); insert into Subjects values (26446, 1, 'sorzedam żaglówke', 'Brak informacji na temat przedmiotu', 33); insert into Boats values (14129, 'test', '0', 32, 23, 44, '1999', 0, 0); insert into SailBoat values (14129, 23, 'True', 3, 1, 'MONOHULL', 'Brak', 'Zaburtowy'); " +
            //"insert into Adverts values ('2018-06-03 16:54:27', '2018-06-08 16:54:27', 'Mateusz', 'Stanik', '234234323', 'test@gmail.col', 'Katowice', 'brak'); insert into Subjects values (26447, 1, 'sorzedam żaglówke', 'Brak informacji na temat przedmiotu', 33); insert into Boats values (14130, 'test', '0', 32, 23, 44, '1999', 0, 0); insert into SailBoat values (14130, 23, 'True', 3, 1, 'MONOHULL', 'Brak', 'Zaburtowy'); " +
            //"insert into Adverts values ('2018-06-03 16:54:27', '2018-06-08 16:54:27', 'Mateusz', 'Stanik', '234234323', 'test@gmail.col', 'Katowice', 'brak'); insert into Subjects values (26448, 1, 'sorzedam żaglówke', 'Brak informacji na temat przedmiotu', 33); insert into Boats values (14131, 'test', '0', 32, 23, 44, '1999', 0, 0); insert into SailBoat values (14131, 23, 'True', 3, 1, 'MONOHULL', 'Brak', 'Zaburtowy'); " +
            //"insert into Adverts values ('2018-06-03 16:54:27', '2018-06-08 16:54:27', 'Mateusz', 'Stanik', '234234323', 'test@gmail.col', 'Katowice', 'brak'); insert into Subjects values (26449, 1, 'sorzedam żaglówke', 'Brak informacji na temat przedmiotu', 33); insert into Boats values (14132, 'test', '0', 32, 23, 44, '1999', 0, 0); insert into SailBoat values (14132, 23, 'True', 3, 1, 'MONOHULL', 'Brak', 'Zaburtowy'); " +
            //"insert into Adverts values ('2018-06-03 16:54:27', '2018-06-08 16:54:27', 'Mateusz', 'Stanik', '234234323', 'test@gmail.col', 'Katowice', 'brak'); insert into Subjects values (26450, 1, 'sorzedam żaglówke', 'Brak informacji na temat przedmiotu', 33); insert into Boats values (14133, 'test', '0', 32, 23, 44, '1999', 0, 0); insert into SailBoat values (14133, 23, 'True', 3, 1, 'MONOHULL', 'Brak', 'Zaburtowy'); " +
            //"insert into Adverts values ('2018-06-03 16:54:27', '2018-06-08 16:54:27', 'Mateusz', 'Stanik', '234234323', 'test@gmail.col', 'Katowice', 'brak'); insert into Subjects values (26451, 1, 'sorzedam żaglówke', 'Brak informacji na temat przedmiotu', 33); insert into Boats values (14134, 'test', '0', 32, 23, 44, '1999', 0, 0); insert into SailBoat values (14134, 23, 'True', 3, 1, 'MONOHULL', 'Brak', 'Zaburtowy'); " +
            //"insert into Adverts values ('2018-06-03 16:54:27', '2018-06-08 16:54:27', 'Mateusz', 'Stanik', '234234323', 'test@gmail.col', 'Katowice', 'brak'); insert into Subjects values (26452, 1, 'sorzedam żaglówke', 'Brak informacji na temat przedmiotu', 33); insert into Boats values (14135, 'test', '0', 32, 23, 44, '1999', 0, 0); insert into SailBoat values (14135, 23, 'True', 3, 1, 'MONOHULL', 'Brak', 'Zaburtowy'); " +
            //"insert into Adverts values ('2018-06-03 16:54:27', '2018-06-08 16:54:27', 'Mateusz', 'Stanik', '234234323', 'test@gmail.col', 'Katowice', 'brak'); insert into Subjects values (26453, 1, 'sorzedam żaglówke', 'Brak informacji na temat przedmiotu', 33); insert into Boats values (14136, 'test', '0', 32, 23, 44, '1999', 0, 0); insert into SailBoat values (14136, 23, 'True', 3, 1, 'MONOHULL', 'Brak', 'Zaburtowy'); "; 
            int j = 14217;
            int k = 26534;
            for (int i= 0; i < 20; i++)
            {
                
                cmd.CommandText = "insert into Adverts  values ('2018-06-03 16:54:27','2018-06-08 16:54:27' ,'Mateusz','Stanik','234234323','test@gmail.col','Katowice','brak'); insert into Subjects values (" + k + ", 1, 'sorzedam żaglówke', 'Brak informacji na temat przedmiotu', 33);insert into Boats values (" + j + ", 'test', '0', 32, 23, 44, '1999', 0, 0); insert into SailBoat values (" + j+", 23, 'True', 3, 1, 'MONOHULL', 'Brak', 'Zaburtowy'); ";
                cmd.CommandType = CommandType.Text;
                reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                j++;
                k++;
            }
            
           
            sqlConnection1.Close();

      
            stopWatch.Stop();
            System.Diagnostics.Debug.WriteLine("Czas wykonania: " + stopWatch.ElapsedMilliseconds);
            return Ok();
        }
        private static void ReadSingleRow(IDataRecord record)
        {
            Console.WriteLine(String.Format("{0}, {1}", record[0], record[1]));
        }
        [HttpGet]
        [Route("GetAllProducts")]
        public IHttpActionResult GetAllProducts(int? id)
        {
            List<Subject> productsList = null;

            if (id != null){
                productsList = _db.subjects.Where(x=>x.CategoryId == id).ToList();
            }
            else
            {
                productsList = _db.subjects.ToList();
            }
            
            var products = productsList
                .Select(
                x => new ProductInfo()
                {
                    AdvertDescription = x.AdvertDescription,
                    AdvertId = x.AdvertId,
                    SubjectId = x.SubjectId,
                    AdvertName = x.AdvertName,
                    Price = x.Price,
                    Image = "../../AdvertImages/" + _db.images.Where(y => y.Subject.SubjectId == x.SubjectId).FirstOrDefault().Name
                })
                .ToArray();
            int[] marks = new int[5] { 99, 98, 92, 97, 95 };
            return Json(products);
        }
        [HttpGet]
        [Route("GatImages")]
        public IHttpActionResult GetImages(long id)
        {
            string name = "";
            var image = _db.images.Where(x => x.Subject.SubjectId == id).ToList();

            name = image[0].Name;
            return Ok(name);
        }
    }
}