
using HandJWebApp.Models;
using HandJWebApp.Models.DataContext;
using HandJWebApp.Models.Model;
using System.Linq;
using System.Web.Mvc;

namespace HandJWebApp.Controllers
{
    public class AdminController : Controller
    {

        BusinessWebDBContext db = new BusinessWebDBContext();
        // GET: Admin
        public ActionResult Index()
        {
            var sorgu = db.Category.ToList();
            return View(sorgu);

        }
        public ActionResult Login()//sayfa yükleme aşaması
        {
           
            return View();

        }

        [HttpPost]
        public ActionResult Login(Admin admin)//işlem yap veri ekle gönder
        {
            var login = db.Admin.Where(x => x.Eposta == admin.Eposta).SingleOrDefault();
            if (login.Eposta==admin.Eposta && login.Password==admin.Password)
            {
                Session["adminid"] = login.Adminid;
                Session["eposta"] = login.Eposta;
                return RedirectToAction("Index", "Admin");
            }
            ViewBag.Uyari = "Kullacı adı veya şifre yanlış";
            return View(admin);
        }
        public ActionResult Logout() 
        {
            Session["adminid"] = null;
            Session["eposta"] = null;
            Session.Abandon();
            return RedirectToAction("Login", "Admin");

        
        }


    }
}
