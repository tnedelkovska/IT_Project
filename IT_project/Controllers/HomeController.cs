using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IT_project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Make reservation for good vacation in Ohrid.";

            return View();
        }

        public ActionResult Accommodations()
        {
            ViewBag.Message = "Accomodations/Reservations";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ApartmentsView()
        {
            ViewBag.ApiUri = "/api/apartments/" + Request.QueryString["apartmentid"]; 
            return View();
        }

        //[Authorize(Roles = "Administrator")]
        public ActionResult Admin()
        {
            string apiUri = Url.RouteUrl("DefaultApi", new { controller = "admin", });
            ViewBag.ApiUrl = "/api/admin";

            return View();
        }
    }
}
