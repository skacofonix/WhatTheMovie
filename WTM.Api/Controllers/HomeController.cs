using System.Web.Mvc;

namespace WTM.Api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "WTM";

            return View();
        }
    }
}
