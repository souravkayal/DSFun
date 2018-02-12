using DS.LinkedListWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS.Model;
using ImplementationFun;

namespace DSFun
{
    class Program
    {
        static void Main(string[] args)
        {

            DakeOfCard Obj = new DakeOfCard();

            Obj.Suffle();
            Obj.DistributeAllHands();
            Obj.PrintAllHands();


            Console.ReadLine();
        }
    }
}
