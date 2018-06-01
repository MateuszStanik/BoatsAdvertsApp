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

            List<Boat> boat = _db.boats.Where(x=>x.SailBoat.EnginePower> 500).ToList();
            foreach(Boat singleBoat in boat)
            {
                singleBoat.Price = 10101;
            }
            _db.SaveChanges();
            
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
            cmd.CommandText = "Update Subjects Set Price = 51234 from Subjects INNER JOIN SailBoat on Subjects.SubjectId = SailBoat.SubjectId where SailBoat.EnginePower > 500";
            cmd.CommandType = CommandType.Text;
            reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
           
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