using DS.LinkedListWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS.Model;
using ImplementationFun;
using Algorithm.Recursion;
using Algorithm.StackAlgo;
using DS.Hashing;
using System.Globalization;

namespace DSFun
{
    class Program
    {
        static void Main(string[] args)
        {
            DecessionChoice Obj = new DecessionChoice();
            List<DecessionChoice.People> list = new List<DecessionChoice.People>();
            list.Add(new DecessionChoice.People { Name = "John", Status = true, DateReplyed = DateTime.ParseExact("2016/01/01", "yyyy/MM/dd", CultureInfo.InvariantCulture) });
            list.Add(new DecessionChoice.People { Name = "John", Status = false, DateReplyed = DateTime.ParseExact("2016/01/02", "yyyy/MM/dd", CultureInfo.InvariantCulture) });

            list.Add(new DecessionChoice.People { Name = "Linda", Status = true, DateReplyed = DateTime.ParseExact("2016/01/01", "yyyy/MM/dd", CultureInfo.InvariantCulture) });
            list.Add(new DecessionChoice.People { Name = "Mark", Status = false, DateReplyed = DateTime.ParseExact("2016/01/05", "yyyy/MM/dd", CultureInfo.InvariantCulture) });
            list.Add(new DecessionChoice.People { Name = "Mark", Status = true, DateReplyed = DateTime.ParseExact("2016/01/06", "yyyy/MM/dd", CultureInfo.InvariantCulture) });

            Obj.ProcessResponse(list);

            Console.ReadLine();
        }
    }
}
