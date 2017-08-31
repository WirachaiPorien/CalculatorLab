﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class CalculatorEngine
    {
        public string Calculate(string operate, string operate2 , string firstOperand, string secondOperand, int maxOutputSize = 9 )
        {
            //double ans = 0;
            
            switch (operate)
            {
               
                case "+":
                    return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                case "-":
                    return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
                case "X":
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)).ToString();
                case "÷":
                    // Not allow devide be zero
                    if (secondOperand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
                        // split between integer part and fractional part
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =
                        return result.ToString("N" + remainLength);
                    }
                    break;
                case "%":
                    if (operate2 == "+")
                    {
                        return (Convert.ToDouble(firstOperand) + ((Convert.ToDouble(firstOperand) / 100) * Convert.ToDouble(secondOperand))).ToString();
                    }
                    if (operate2 == "-")
                    {
                        return (Convert.ToDouble(firstOperand) - ((Convert.ToDouble(firstOperand) / 100) * Convert.ToDouble(secondOperand))).ToString();
                    }
                    if (operate2 == "x")
                    {
                        return (Convert.ToDouble(firstOperand) * ((Convert.ToDouble(firstOperand) / 100) * Convert.ToDouble(secondOperand))).ToString();
                    }
                    if (operate2 == "/")
                    {
                        return (Convert.ToDouble(firstOperand) / ((Convert.ToDouble(firstOperand) / 100) * Convert.ToDouble(secondOperand))).ToString();
                    }
                    break;
                case "√":
                    
                    if (operate2 == "+")
                    {
                        return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                    }
                    if (operate2 == "-")
                    {
                        return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
                    }
                    if (operate2 == "x")
                    {
                        return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)).ToString();
                    }
                    if (operate2 == "/")
                    {
                        return (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand)).ToString();
                    }

                    break;

            }
            //firstOperand = Convert.ToString(ans);
            //operate = "0";
            return "E";
            
        }
    }
}
