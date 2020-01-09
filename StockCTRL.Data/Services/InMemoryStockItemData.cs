using StockCTRL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StockCTRL.Data.Services
{
    public class InMemoryStockItemData : IStockItemData
    {
        List<StockItem> stockitems;
        public InMemoryStockItemData()
        {
            stockitems = new List<StockItem>()
            {
                new StockItem
                { Id = 1
                , Sku = "SKU00000001"
                , ItemName = "EZVIZ Full HD Indoor Smart Security Camera"
                , ItemType = ItemType.Home_Security
                , Description = "Push notifications sent to your phone when motion is detected"
                , IsAvailable = true
                , Quantity = 29
                , BuyPrice = 16.96
                , SellPrice = 39.99
                , ItemLocation = ItemLocation.Greater_London
                , CreatedDateTime = DateTime.Now
                },

                new StockItem
                { Id = 2
                , Sku = "SKU00000002/B"
                , ItemName = "Razer Ornata Chroma Mecha-Membrane Gaming Keyboard"
                , ItemType = ItemType.Computing_And_Gaming
                , Description = "Powered by Razer Chroma"
                , IsAvailable = true
                , Quantity = 7
                , BuyPrice = 27.36
                , SellPrice = 79.99
                , ItemLocation = ItemLocation.North_West
                , CreatedDateTime = DateTime.Now
                },

                new StockItem
                { Id = 3
                , Sku = "SKU00000003/Z"
                , ItemName = "ProperAV HDMI 2.0 Premium Tangle-Free Braided Cable (3m)"
                , ItemType = ItemType.Batteries_And_Cables
                , Description = "1080p Full HD Compatible"
                , IsAvailable = true
                , Quantity = 3
                , BuyPrice = 2.76
                , SellPrice = 13.49
                , ItemLocation = ItemLocation.Wales
                , CreatedDateTime = DateTime.Now
                }
            };
        }

        public void Add(StockItem stockitem)
        {
            stockitems.Add(stockitem);
            stockitem.Id = stockitems.Max(si => si.Id) + 1;
        }

        public void Update(StockItem stockitem)
        {
            var existing = Get(stockitem.Id);
            if (existing != null)
            {
                existing.Sku = stockitem.Sku;
                existing.ItemName = stockitem.ItemName;
                existing.ItemType = stockitem.ItemType;
                existing.Description = stockitem.Description;
                existing.IsAvailable = stockitem.IsAvailable;
                existing.Quantity = stockitem.Quantity;
                existing.BuyPrice = stockitem.BuyPrice;
                existing.SellPrice = stockitem.SellPrice;
                existing.ItemLocation = stockitem.ItemLocation;
                existing.CreatedDateTime = stockitem.CreatedDateTime;
            }
        }

        public StockItem Get(int id)
        {
            return stockitems.FirstOrDefault(si => si.Id == id);
        }

        public IEnumerable<StockItem> GetAll()
        {
            return stockitems.OrderBy(si => si.Id);
        }

        public void Delete(int id)
        {
            var stockitem = Get(id);
            if (stockitem != null)
            {
                stockitems.Remove(stockitem);
            }
        }
    }
}
