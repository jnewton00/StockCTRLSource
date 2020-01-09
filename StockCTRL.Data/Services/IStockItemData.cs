using StockCTRL.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockCTRL.Data.Services
{
    public interface IStockItemData
    {
        IEnumerable<StockItem> GetAll();
        StockItem Get(int id);
        void Add(StockItem stockitem);
        void Update(StockItem stockitem);
        void Delete(int id);

    }
}
