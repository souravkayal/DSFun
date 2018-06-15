using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun.DesignPattern
{

    public class ActualClass
    {
        /// <summary>
        /// This is secret method and hidden behind proxy
        /// </summary>
        void SecretMethod()
        {
        }
        public void CallProxy()
        {
            SecretMethod();
        }
    }

    public class ProxyClass 
    {
        ActualClass Obj = new ActualClass();

        //This method acts as proxy method to secret method one
        public void ProxySecret()
        {
            Obj.CallProxy();
        }
    }
}
