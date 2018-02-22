using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.StackAlgo
{
    
    public class StackAlgo
    {

        //Validate Expression using Stack
        //Algo to validate Expression
        //[{(1+2) + 5}] - Valid One
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

        //String Riverse using Stack
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

        //This is code to evaluate simple postfix expression 12+5* = 15
        //If number then push to Stack
        //If operand then pop top 2 from stack, perform operation and push to stack
        public int EvaluationOfPostfixExpression(string Expression)
        {
            Stack<int> Stk = new Stack<int>();
            foreach (var item in Expression)
            {
                if(Char.IsDigit(item))
                {
                    Stk.Push((int) char.GetNumericValue(item));
                }
                else
                {
                    var item1 = Stk.Pop();
                    var item2 = Stk.Pop();

                    switch (item)
                    {
                        case '+': Stk.Push(item1 + item2); break;
                        case '-': Stk.Push(item1 - item2); break;
                        case '*': Stk.Push(item1 * item2); break;
                        case '/': Stk.Push(item / item2); break;

                        default:
                            break;
                    }
                }
            }

            return Stk.Pop();
        }
        
        //Algo to evaluate prefix expression : +2 4 = 6
        //Push operator in one stack
        //Push Operand in other stack
        //Perform operation by poping operator stack until it fisish
        public int EvaluationOfPrefixExpression(string Empression)
        {
            Stack<int> Operand = new Stack<int>();
            Stack<Char> Operator = new Stack<char>();

            foreach (var item in Empression)
            {
                if (Char.IsDigit(item))
                    Operand.Push((int)Char.GetNumericValue(item));
                else
                    Operator.Push(item);
            }

            while (Operator.Count >0)
            {

                int item1 = Operand.Pop();
                int item2 = Operand.Pop();

                switch (Operator.Pop())
                {
                    case '+': Operand.Push(item1 + item2); break;
                    case '-': Operand.Push(item1 - item2);break;
                    case '*': Operand.Push(item1 * item2); break;
                    case '/': Operand.Push(item1 / item2); break;
                    default:
                        break;
                }
            }

            return Operand.Pop();
        }


        //Insert item at bottom of stack using recursion
        public Stack<int> InsertItemAtBottomOfStack(Stack<int> Stk, int Item)
        {
            if (Stk.Count == 0)
            {
                Stk.Push(Item);
                return Stk;
            }
            else
            {
                var item = Stk.Pop();
                InsertItemAtBottomOfStack(Stk, Item);
                Stk.Push(item);

                return Stk;
            }
        }

        //Riverse a Stack
        public Stack<int> RiverseStack(Stack<int> Stk)
        {
            if (Stk.Count() == 0)
                return Stk;
            else
            {
                var item = Stk.Pop();
                RiverseStack(Stk);
                Stk = InsertItemAtBottomOfStack(Stk, item);

                return Stk;
            }
        }

        //input : ab aa aa bcd ab
        //output : 3
        //as aa, aa destroys each other so, ab bcd ab is the new sequence
        public string DeleteConsucutiveSameWord(string Value)
        {
            string[] Words = Value.Split(' ');
            Stack<string> Stk = new Stack<string>();

            foreach (var item in Words)
            {

                if(Stk.Count>0)
                {
                    var topWord = Stk.Peek();
                    if (topWord == item)
                        Stk.Pop();
                    else
                        Stk.Push(item);
                }

                if (Stk.Count == 0)
                    Stk.Push(item);
            }
            string result = string.Empty;

            while (Stk.Count>0)
            {
                var word = Stk.Pop();
                result = word + result + " ";
            }

            return result;
        }

        //0! 1!!! 0!! 1! 0!! 1!!! 0! => 0 1 0 1 0 1 0
        public string RemoveSpecialCharacterFromString(string Value)
        {
            Stack<Char> Stk = new Stack<char>();
            foreach (var item in Value)
            {
                if (item != '!')
                    Stk.Push(item);
            }

            string result = string.Empty;
            while (Stk.Count >0)
            {
                result = Stk.Pop() + result; 
            }
            return result;
        }
    }

    //Implement Two Stack In Array
    public class StackUsingTwoArray
    {
        int top1 = 0;
        int top2 = 25;
        int[] Array = new int[50];

        public enum StackNumber
        {
            One, Two
        }

        public StackUsingTwoArray()
        {
            this.top1 = 0;
            this.top2 = 25;
        }

        public void Push(StackNumber Number , int Value)
        {
            int nextIndex = -1;

            switch (Number)
            {
                case StackNumber.One: if (top1 < 25)
                                    {
                                        ++top1;
                                        nextIndex = top1;
                                    }
                break;
                case StackNumber.Two:
                                    if (top1 < 50)
                                    {
                                        ++top2;
                                        nextIndex = top2;
                                    }
                break;
                default:
                    break;
            }
            if (nextIndex != -1)
                Array[nextIndex] = Value;
            else
                throw new Exception("Stack Overflow");

            

        }

        public int Pop(StackNumber Number)
        {
            int result = -1;

            switch (Number)
            {
                case StackNumber.One: 
                    if(top1 > 0)
                    {
                        result = Array[top1];
                        --top1;
                    }
                    break;
                case StackNumber.Two:
                    if(top2 < 50)
                    {
                        result = Array[top2];
                        --top2;
                    }
                    break;
                default:
                    break;
            }
            if (result != -1)
                return result;
            else
                throw new Exception("Invalid Operation");
        }

    }

    //Implementation of stack where Max and Min element will return in constant time
    public class StackWithConstantComplexcity
    {
        Stack<int> Stack = new Stack<int>();
        Stack<int> MinStk = new Stack<int>();
        Stack<int> MaxStk = new Stack<int>();
        public void Push(int Value)
        {
            Stack.Push(Value);

            if (Value > MaxStk.Peek())
                MaxStk.Push(Value);
            else
                MaxStk.Push(MaxStk.Peek());

            if (Value < MinStk.Peek())
                MinStk.Push(Value);
            else
                MinStk.Push(MinStk.Peek());
        }
        public int Pop()
        {
            if(Stack.Count > 0)
            {
                MaxStk.Pop();
                MinStk.Pop();
                return Stack.Pop();
            }
            throw new Exception("Stack Underflow");
        }
    }
    
}
