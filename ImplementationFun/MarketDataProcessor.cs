using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun.MarketDataImplementation
{

    /// <summary>
    /// Program to implementation of get market data from various data source.
    /// user can able to switch over among different client.
    /// </summary>
    public class Data
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
    public interface IMarket
    {
        List<Data> GetData();
    }
    public class BSEMarket : IMarket
    {
        public List<Data> GetData()
        {
            return null;
        }
    }
    public class NSEMarket : IMarket
    {
        public List<Data> GetData()
        {
            return null;
        }
    }
    public class MarketDataProcessor
    {
        IMarket Obj;
        public MarketDataProcessor(IMarket Obj)
        {
            this.Obj = Obj;
        }
        public List<Data> GetMarketData()
        {
            return this.Obj.GetData();
        }
    }
}
