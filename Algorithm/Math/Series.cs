using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.MathFun
{
    public class Series
    {
        //Formula to sum upto N natural number
        public int SumOfNaturalNumberInAP(int N)
        {
            return (N * (N + 1)) / 2;
        }

        public int FindNthTermInAP(int FirstTerm, int N, int CommonInterval)
        {
            return (FirstTerm + (N - 1) * CommonInterval);
        }

        //firstTerm * Interval ^ (n-1)
        public double FindNthValueInGP(int FirstTerm, int Interval, int N)
        {
            return (FirstTerm * Math.Pow(Interval, (N - 1)));
        }

        
        public double FindSumOfNaturalNumberInGP(int FirstTerm, int CommonInterval, int N)
        {
            return (FirstTerm * (Math.Pow(CommonInterval, N) - 1)) / CommonInterval - 1;
        }

        

    }
}
