using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun.DesignPattern
{
    //Service locator pattern
    //Sometime it's recommend not to use service locator and generally granted as anti pattern

    #region ServiceLocator
    public interface IService
    {
        void Execute();
    }
    public class ServiceA : IService
    {
        public void Execute()
        {
            Console.Write("A");
        }
    }
    public class ServiceB : IService
    {
        public void Execute()
        {
            Console.Write("B");
        }
    }
    public enum ServiceType
    {
        A, B
    }
    public class ServiceLocator
    {
        public IService GetInstance(ServiceType Type)
        {
            IService _service;
            if (Type == ServiceType.A)
                _service = new ServiceA();
            else if (Type == ServiceType.B)
                _service = new ServiceB();
            else
                throw new Exception("Invalid Argument");

            return _service;
        }
    }
    #endregion

    #region FactoryPattern

    public interface IDb
    {
        void GetData();
    }

    public class OracleDb : IDb
    {
        public void GetData()
        {
            Console.Write("Oracle");
        }
    }

    public class SqlDb : IDb
    {
        public void GetData()
        {
            Console.Write("Sql");
        }
    }

    public class DbFactory
    {
        public IDb _db;
        //Centralize instanciation using DI
        public IDb GetInstance(IDb Obj)
        {
            this._db = Obj;
            return this._db;
        }
    }



    #endregion

    #region AbstractFactory

    public interface IDbAbs
    {
        void Execute();
    }

    public class OracleProvider : IDbAbs
    {
        public void Execute()
        {
            Console.Write("Oracle");
        }
    }

    public class SqlServerProvider : IDbAbs
    {
        public void Execute()
        {
            Console.Write("SqlServer");
        }
    }

    public abstract class AbsDatabaseFactory
    {
       public abstract IDbAbs GetInstance(IDbAbs Obj);
    }

    public class DatabaseFactory : AbsDatabaseFactory
    {
        IDbAbs _instance;
        //Logic of instanciation goes here
        public override IDbAbs GetInstance(IDbAbs Obj)
        {
            this._instance = Obj;
            return this._instance;
        }
    }

    #endregion


}
