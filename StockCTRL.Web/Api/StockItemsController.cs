using StockCTRL.Data.Models;
using StockCTRL.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StockCTRL.Web.Api
{
    public class StockItemsController : ApiController
    {
        private readonly IStockItemData db;

        public StockItemsController(IStockItemData db)
        {
            this.db = db;
        }
        public IEnumerable<StockItem> Get()
        {
            var model = db.GetAll();
            return model;
        }
    }
}
