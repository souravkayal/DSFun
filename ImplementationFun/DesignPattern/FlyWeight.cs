using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun.DesignPattern
{
    /// <summary>
    /// Flyweight pattern cache complex object , so that it need not to create again and again
    /// </summary>
    public class ComplexObject
    {
        public string Name { get; set; }
    }

    public class FlyWeight
    {
        List<ComplexObject> Store = new List<ComplexObject>();

        public ComplexObject GetObject()
        {
            //logic to mantain Object in store/cache
            if(Store.Count < 5)
            {
                ComplexObject st = new ComplexObject();
                Store.Add(st);
            }
            int randInd = new Random().Next(0, 4);
            return Store[randInd];
        }
    }
}
