using StockCTRL.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockCTRL.Data.Services
{
    public class SqlStockItemData : IStockItemData
    {
        private readonly StockCTRLDbContext db;

        public SqlStockItemData(StockCTRLDbContext db)
        {
            this.db = db;
        }
        public void Add(StockItem stockitem)
        {
            db.StockItems.Add(stockitem);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var stockitem = db.StockItems.Find(id);
            db.StockItems.Remove(stockitem);
            db.SaveChanges();
        }

        public StockItem Get(int id)
        {
            return db.StockItems.FirstOrDefault(si => si.Id == id);
        }

        public IEnumerable<StockItem> GetAll()
        {
            return from si in db.StockItems
                   orderby si.ItemName
                   select si;
        }

        public void Update(StockItem stockitem)
        {

            var entry = db.Entry(stockitem);
            entry.State = EntityState.Modified;
            db.SaveChanges();

            //var si = Get(stockitem.Id);
            //si.ItemName = "";
            //db.SaveChanges();
        }
    }
}
