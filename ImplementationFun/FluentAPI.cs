using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun
{
    //Order management lyfecycle in fluent API

    public class OrderManager
    {
        //Private Property
        private Boolean IsOrderPlaced { get; set; }
        private Boolean IsOrderAccepted { get; set; }
        private Boolean IsOrderDispatched { get; set; }
        private Boolean IsOrderDelivered { get; set; }
        private Boolean IsOrderProcessed { get; set; }

        //Exposed property for query

        public bool Delivered { get; set; }

        public  List<OrderManager> Managers = new List<OrderManager>();
        public OrderManager Manager;
        private int OrderCount;

        public OrderManager()
        {
            this.Manager = new OrderManager();
            this.Managers.Add(this.Manager);
        }

        public OrderManager setOrderPlace(int OrderCount =1)
        {
            this.Manager.IsOrderPlaced = true;
            this.Manager.OrderCount = OrderCount;
            return this.Manager;
        }
        public OrderManager setOrderAccepted()
        {
            this.Manager.IsOrderAccepted = true;
            return this.Manager;
        }

        public OrderManager setOrderDispatched()
        {
            this.Manager.IsOrderDispatched = true;
            return this.Manager;
        }

        public OrderManager SetOrderDelivered()
        {
            this.Manager.IsOrderDelivered = true;
            this.Delivered = true;
            return this.Manager;
        }

        public OrderManager setOrderProcessed()
        {
            this.Manager.IsOrderProcessed = true;
            return this.Manager;
        }

        public List<OrderManager> GetAll(Func<OrderManager, bool> where)
        {
            return this.Managers.Where(where).ToList();
        }

    }
}
