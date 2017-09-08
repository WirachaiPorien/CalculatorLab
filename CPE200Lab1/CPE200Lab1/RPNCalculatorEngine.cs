using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class RPNCalculatorEngine : CalculatorEngine
    {
        public string Process(string str)
        {
            //split str to parts
            string[] parts = str.Split(' ');

            Stack rpnStack = new Stack();
            //string result;
            for(int i=0 ; i< parts.Length-1;i++)//loop each parts
            {
                if (parts[i] == "+" || parts[i] == "-" || parts[i] == "X" || parts[i] == "÷")//if part is operator
                {
                    string firstOperand = Convert.ToString(rpnStack.Pop());
                    string secondOperand = Convert.ToString(rpnStack.Pop());
                    rpnStack.Push(calculate(parts[i], firstOperand, secondOperand));
                    //pop two time =-> second,first operand
                }
                else
                {
                    rpnStack.Push(parts[i]);
                }
            }
            return Convert.ToString(rpnStack.Pop());
        }
    }
}
