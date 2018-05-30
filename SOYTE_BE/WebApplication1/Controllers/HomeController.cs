using System.Web.Mvc;
using Module.Framework.UltimateClient;
using System;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        protected NganhYServiceClient NganhYService;
        public ActionResult Index()
        {
            using (NganhYService = new NganhYServiceClient())
            {
                var response = NganhYService.GetChungChiHanhNgheYbyHoSoId("1");
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    return View();
                //return Json(new { result = "" }, JsonRequestBehavior.AllowGet);
                var result = response.Content;
                return View();
                //return Json(new { result = result }, JsonRequestBehavior.AllowGet);
            }
            //return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}