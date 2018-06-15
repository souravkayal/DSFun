using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun.DesignPattern
{
    /// <summary>
    /// The fact of observer pattern is to notify some subscriber once some even occur
    /// </summary>
    
    public interface INotifier
    {
        void Notify();
    }

    //Subscriber-1 
    public class UserSet1 : INotifier
    {
        public void Notify()
        {
            Console.WriteLine("User Notified");
        }
    }

    //Subscriber-2 
    public class UserSet2 : INotifier
    {
        public void Notify()
        {
            Console.WriteLine("User Notified");
        }
    }

    public class ObserverPattern
    {
        List<INotifier> lists = new List<INotifier>();

        public void SendNotification()
        {
            foreach (var item in lists)
            {
               item.Notify();
            }
        }

    }
}
