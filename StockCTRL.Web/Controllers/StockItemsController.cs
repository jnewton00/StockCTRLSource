using StockCTRL.Data.Models;
using StockCTRL.Data.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockCTRL.Web.Controllers
{
    public class StockItemsController : Controller
    {
        private readonly IStockItemData db;
        public StockItemsController(IStockItemData db)
        {
            this.db = db;
        }
        // GET: StockItems
        public ActionResult Index(String SortOrder)
        {
            ViewBag.Sku = String.IsNullOrEmpty(SortOrder) ? "Sku_desc" : "";
            ViewBag.ItemName = SortOrder == "ItemName" ? "ItemName_desc" : "ItemName";
            ViewBag.IsAvailable = SortOrder == "IsAvailable" ? "IsAvailable_desc" : "IsAvailable";
            ViewBag.Quantity = SortOrder == "Quantity" ? "Quantity_desc" : "Quantity";
            ViewBag.BuyPrice = SortOrder == "BuyPrice" ? "BuyPrice_desc" : "BuyPrice";
            ViewBag.BuyPrice = SortOrder == "SellPrice" ? "SellPrice_desc" : "SellPrice";

            var si = from _si in db.GetAll()
                     select _si;

            switch (SortOrder)
            {
                case "Sku_desc" :
                    si = si.OrderByDescending( _si => _si.Sku);
                    break;
                case "ItemName" :
                    si = si.OrderByDescending(_si => _si.ItemName);
                    break;
                case "ItemName_desc" :
                    si = si.OrderByDescending(_si => _si.ItemName);
                    break;
                case "IsAvailable" :
                    si = si.OrderByDescending(_si => _si.IsAvailable);
                    break;
                case "IsAvailable_desc" :
                    si = si.OrderByDescending(_si => _si.IsAvailable);
                    break;
                case "Quantity" :
                    si = si.OrderByDescending(_si => _si.Quantity);
                    break;
                case "Quantity_desc" :
                    si = si.OrderByDescending(_si => _si.Quantity);
                    break;
                case "BuyPrice":
                    si = si.OrderByDescending(_si => _si.BuyPrice);
                    break;
                case "BuyPrice_desc":
                    si = si.OrderByDescending(_si => _si.BuyPrice);
                    break;
                case "SellPrice":
                    si = si.OrderByDescending(_si => _si.SellPrice);
                    break;
                case "SellPrice_desc":
                    si = si.OrderByDescending(_si => _si.SellPrice);
                    break;

                default :
                    si = si.OrderBy(_si => _si.Sku);
                    break;
            }
            //var model = db.GetAll();
            //return View(model);

            // terminated 10:52 minutes
            return View(si.ToList());
        }

        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StockItem stockitem)
        {
            if (ModelState.IsValid)
            {

                db.Add(stockitem);
                return RedirectToAction("Details", new { id = stockitem.Id});
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StockItem stockitem)
        {
            if (ModelState.IsValid)
            {
                db.Update(stockitem);
                TempData["Message"] = "Stock Item has been Saved";
                return RedirectToAction("Details", new { id = stockitem.Id });
            }
            return View(stockitem);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection Form)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }
        
    }
}

