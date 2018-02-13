﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Recursion
{

    public class Recursion
    {

        public void PrintRiverse(string Value , int StartIndex = 0)
        {
            if (StartIndex >= Value.Length)
                return;
            else
            {
                Char tmp = Value[StartIndex];
                PrintRiverse(Value, ++StartIndex);
                Console.Write(tmp);
            }
        }

        public int CountNumberOfCharacterInString(string Value , int CountSeed = 0)
        {
            if (Value == null || Value == String.Empty)
                return CountSeed;
            else
            {
                Value = Value.Remove(Value.Length - 1, 1);
                return CountNumberOfCharacterInString(Value, ++CountSeed);
            }
        }

        public int SumOfDigitInNumber(int Number , int Sum = 0)
        {
            if (Number <= 0)
                return Sum;
            else
            {
                return SumOfDigitInNumber(Number / 10, Sum + (Number % 10));
            }
        }

        public int RiverseOfNumber(int Number , int Result = 0)
        {
            if (Number <= 0)
                return Result;
            else
            {
                return RiverseOfNumber(Number / 10,( Result * 10 + (Number % 10)));
            }
        }

        public int FactorialOfNumber(int Number)
        {
            if (Number == 0)
                return 1;
            return Number * FactorialOfNumber(Number - 1);
        }

        public void FibonacciSeriesPrint(int first, int second , int Count)
        {
            if (Count == 0)
                return;
            else
            {
                var number = first + second;
                Console.WriteLine(number);
                FibonacciSeriesPrint(second, number, --Count);
            }
        }

        public string RiverseString(String str)
        {
            if (str.Length <= 1)
            {
                return str;
            }
            else
            {
                char tmp = str[0];
                return RiverseString(str.Substring(1)) + tmp;
            }
        }



    }
}