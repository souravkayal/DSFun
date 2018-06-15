using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationFun.DesignPattern
{
    //Singleton class will allow only one instance to be create

    //Thread Unsafe Singleton
    public class Singleton
    {
        private Singleton() { }

        static Singleton _single = new Singleton();
        public static Singleton GetInstance()
        {
            if (_single == null)
            {
                _single = new Singleton();
            }
            return _single;
        }
    }

    //Thread Safe Singleton
    public class ThreadSafeSingleton
    {
        private ThreadSafeSingleton() { }

        public static ThreadSafeSingleton _threadSafe = new ThreadSafeSingleton();

        public static ThreadSafeSingleton GetInstance()
        {
            lock (_threadSafe)
            {
                if (_threadSafe == null)
                {
                    _threadSafe = new ThreadSafeSingleton();
                }
            }
            return _threadSafe;
        }
    }

    //Thread Safe High performance Singleton - Double Locking 
    public class ThreadSafeWithDoubleLock
    {
        public static ThreadSafeWithDoubleLock _instance = new ThreadSafeWithDoubleLock();
        private static Object _lockObj = new object();

        private ThreadSafeWithDoubleLock()
        {
        }
        public static ThreadSafeWithDoubleLock GetInstance()
        {
            if (_instance == null)
            {
                //Multiple thread may come here
                lock (_lockObj)
                {
                    if (_instance == null)
                    {
                        _instance = new ThreadSafeWithDoubleLock();
                    }
                }
            }
            return _instance;
        }
    }
}
