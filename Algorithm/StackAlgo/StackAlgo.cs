using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.StackAlgo
{
    //Algo to validate Expression
    //[{(1+2) + 5}] - Valid One

    public class StackAlgo
    {
        public bool IsValidExpression(string Expression)
        {
            Stack<Char> Stk = new Stack<char>();
            foreach (var item in Expression)
            {
                char topStk = ' ';
                if(item == '(' || item == '{' || item == '[')
                {
                    Stk.Push(item);
                }

                if (item == ')' || item == '}' || item == ']')
                {
                    topStk = Stk.Pop();
                }

                if((topStk != ' ') && (item == ')' && topStk != '(' || item == '}' && topStk != '{' || item == ']' && topStk != '['))
                {
                    return false;
                }
            }
            return true;
        }

        public string StringRiverse(string Value)
        {
            Stack<Char> Stk = new Stack<char>();
            string returnValue = String.Empty;

            foreach (var item in Value)
            {
                Stk.Push(item);
            }
            
            while (Stk.Count>0)
            {
                returnValue += Stk.Pop();
            }
            return returnValue;
        }

        //This is code to evaluate simple postfix expression
        public int EvaluationOfPostfixExpression(string Expression)
        {

            return 0;
        }
        

        //Implementation of simple expression evaluation
        //public int EvaluateExpression(string Expression)
        //{
        //    string[] ExpressionToken = Expression.Split(new char[] { '+', '-', '*', '/' });

        //    foreach (var item in ExpressionToken)
        //    {
        //        if()
        //    }
        //}
    }
}
