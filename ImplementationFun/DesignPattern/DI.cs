using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun.DependencyInjection
{
    /// <summary>
    /// DI stands for Dependency Injection - Another form is Inverse Of Control
    /// </summary>
    public interface IService
    {
    }
    public class Service1 : IService
    {
    }
    public class Service2 : IService
    {
    }

    public class ServiceConsumer
    {

        IService _instance;
        //Constructor injection
        public ServiceConsumer(IService Obj)
        {
            this._instance = Obj;
        }

        //Property Injection
        public IService MyProperty
        {
            set
            {
                _instance = value;
            }
        }
        //Method injection

        public void SetInstance(IService Obj)
        {
            this._instance = Obj;
        }

    }
}
