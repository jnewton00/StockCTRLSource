using StockCTRL.Data.Services;
using StockCTRL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockCTRL.Web.Controllers
{
    public class HomeController : Controller
    {
        IStockItemData db;
        public HomeController(IStockItemData db)
        {
            this.db = db;
        }
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
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
        public ActionResult Reporting()
        {
            ViewBag.Message = "Reporting.";

            return View();
        }
    }
}