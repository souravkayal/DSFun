using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.QueueAlgo
{
    public class QueueAlgo
    {
        public int RiverseOfNumber(int Number)
        {
            Queue<int> Stk = new Queue<int>();
            int Sum = 0;
            while (Number > 0)
            {
                int r = Number % 10;
                Stk.Enqueue(r);
                Number = Number / 10;
            }
            while (Stk.Count > 0)
            {
                Sum = (Sum * 10) + Stk.Dequeue();
            }
            return Sum;
        }

    }
}
