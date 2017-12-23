using System.Web.Mvc;

namespace Durandal451v2.Controllers {
    
     
    public class DurandalController : Controller {
        [RequireHttps]
        public ActionResult Index() {
            return View();
        }
  }
}