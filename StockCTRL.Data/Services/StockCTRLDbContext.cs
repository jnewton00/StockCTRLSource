using StockCTRL.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockCTRL.Data.Services
{
    public class StockCTRLDbContext : DbContext
    {
        public DbSet<StockItem> StockItems { get; set; }
    }
}
