using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun
{
    /// <summary>
    /// Program to implement , 2 operations on stock stream
    /// 1. Get Stock price for certain timestamp - O(1)
    /// 2. get and delete minimum stock status
    /// </summary>

    public class StockWrap
    {
        public string Company { get; set; }
        public decimal Timestamp { get; set; }
        public decimal Price { get; set; }
    }

    public class StockStream
    {
        Dictionary<decimal, StockWrap> StockBoard = new Dictionary<decimal, StockWrap>();
        SortedList<decimal, StockWrap> SortedList = new SortedList<decimal, StockWrap>();

        public void AddStock(decimal Timestamp , decimal StockPrice)
        {
            var item = new StockWrap { Timestamp = Timestamp, Price = StockPrice };
            StockBoard.Add(Timestamp, item);
            //MinSet.Add(item);
            SortedList.Add(item.Price, item);
        }

        //Will assume it's a valid key
        public StockWrap GetStockByTime(decimal TimeStamp)
        {
            return StockBoard[TimeStamp];
        }

        public decimal GetMinStock()
        {
            var item = SortedList.Min(f=>f.Key);
            SortedList.Remove(item);
            StockBoard.Remove(item);
            return item;
        }


    }
}
