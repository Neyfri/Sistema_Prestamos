using Login_Test.Models;
using Login_Test.Models.ViewModel;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login_Test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult ReportePrestamo()
        {
            List<prestamo> lst = new List<prestamo>();
            lst.Where(x => x.id == 1);

            return View(lst);
        }
        public ActionResult Print()
        {
            return new ActionAsPdf("ReportePrestamo")
            { FileName = "Testy.pdf" };
        }
    }
}