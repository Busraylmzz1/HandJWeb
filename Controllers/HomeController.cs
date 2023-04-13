using HandJWebApp.Models.DataContext;
using System.Linq;
using System.Web.Mvc;

namespace HandJWebApp.Controllers
{
    public class HomeController : Controller
    {
        private BusinessWebDBContext db = new BusinessWebDBContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SliderPartial () 
        {
            return View(db.Slider.ToList().OrderByDescending(x=>x.SliderId));
        }
        public ActionResult HizmetPartial()
        {
            return View(db.Service.ToList().OrderByDescending(x=>x.ServiceId));
        }
    }
}