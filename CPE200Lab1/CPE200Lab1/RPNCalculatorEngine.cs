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
        //split str to parts
        //loop each parts
        //if part is number
        //push to stack
        //if part is operator
        //pop two time =-> second,first operand
        public string Process(string str)
        {

            string[] parts = str.Split(' ');

            Stack rpnStack = new Stack();
            //string result;
            for(int i=0 ; i< parts.Length-1;i++)
            {
                if (parts[i] == "+" || parts[i] == "-" || parts[i] == "X" || parts[i] == "÷")
                {
                    string firstOperand = Convert.ToString(rpnStack.Pop());
                    string secondOperand = Convert.ToString(rpnStack.Pop());
                    rpnStack.Push(calculate(parts[i], firstOperand, secondOperand));


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
