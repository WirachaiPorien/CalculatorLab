﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPE200Lab1
{
    public partial class MainForm : Form
    {
        private bool hasDot;
        private bool isAllowBack;
        private bool isAfterOperater;
        private bool isAfterEqual;
        private string firstOperand;
        private string operate;
        private string operate2;
        private string operate3;
        private string operate4;
        private string secondOperand;
        private string mFunction;
        private string memoryOfm;
        private void resetAll()
        {
            lblDisplay.Text = "0";
            isAllowBack = true;
            hasDot = false;
            isAfterOperater = false;
            isAfterEqual = false;
            firstOperand = null;
            secondOperand = null;
            operate = null;
            operate2 = null;
            operate3 = null;
            operate4 = null;
            mFunction = null;

        }
        private CalculatorEngine engine;



        public MainForm()
        {
            InitializeComponent();
            engine = new CalculatorEngine();
            resetAll();
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            if (isAfterOperater)
            {
                lblDisplay.Text = "0";
            }
            if (lblDisplay.Text.Length is 8)
            {
                return;
            }
            isAllowBack = true;
            string digit = ((Button)sender).Text;
            if (lblDisplay.Text is "0")
            {
                lblDisplay.Text = "";
            }
            lblDisplay.Text += digit;
            isAfterOperater = false;
        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterOperater)
            {
                return;
            }

            operate = ((Button)sender).Text;
            switch (operate)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                    if (firstOperand != null)
                    {
                        string secondOperand = lblDisplay.Text;
                        string result = engine.Calculate(operate, operate2, firstOperand, secondOperand);
                        //result = System.Math.Ceiling((Convert.ToDouble(result)*100)/100).ToString();
                        if (result.Length > 8)
                        {
                            result = result.Substring(0, 8);
                        }
                        if (result is "E" )
                        {
                            lblDisplay.Text = "Error";
                        }
                        else
                        {
                            lblDisplay.Text = result;
                        }
                    }
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    operate3 = operate;
                    break;
                case "%":
                    operate2 = operate3;
                    if (firstOperand != null)
                    {
                        string secondOperand = lblDisplay.Text;
                        string result = engine.Calculate(operate, operate2, firstOperand, secondOperand);
                        result = result.Substring(0, 8);
                        if (result is "E" || result.Length > 8)
                        {
                            lblDisplay.Text = "Error";
                        }
                        else
                        {
                            lblDisplay.Text = result;
                        }
                    }
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    break;
            }

            isAllowBack = false;

        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            string secondOperand = lblDisplay.Text;
            string result = engine.Calculate(operate, operate2, firstOperand, secondOperand);
            if (result.Length > 8)
            {
                result = result.Substring(0, 8);
            }
            if (result is "E" )
            {
                lblDisplay.Text = "Error";
            }
            else
            {
                lblDisplay.Text = result;
            }
            isAfterEqual = true;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            if (lblDisplay.Text.Length is 8)
            {
                return;
            }
            if (!hasDot)
            {
                lblDisplay.Text += ".";
                hasDot = true;
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            // already contain negative sign
            if (lblDisplay.Text.Length is 8)
            {
                return;
            }
            if (lblDisplay.Text[0] is '-')
            {
                lblDisplay.Text = lblDisplay.Text.Substring(1, lblDisplay.Text.Length - 1);
            }
            else
            {
                lblDisplay.Text = "-" + lblDisplay.Text;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            resetAll();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                return;
            }
            if (!isAllowBack)
            {
                return;
            }
            if (lblDisplay.Text != "0")
            {
                string current = lblDisplay.Text;
                char rightMost = current[current.Length - 1];
                if (rightMost is '.')
                {
                    hasDot = false;
                }
                lblDisplay.Text = current.Substring(0, current.Length - 1);
                if (lblDisplay.Text is "" || lblDisplay.Text is "-")
                {
                    lblDisplay.Text = "0";
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Root_Click(object sender, EventArgs e)//root
        {
            operate4 = ((Button)sender).Text;
            switch (operate4)
            {
                case "√":
                    double Root = (Double)Math.Sqrt(Convert.ToDouble(lblDisplay.Text));
                    lblDisplay.Text = Root.ToString();
                    if (lblDisplay.Text.Length > 8)
                    {
                        string rootLength = lblDisplay.Text;
                        lblDisplay.Text = rootLength.Substring(0, 8);
                    }
                    string secondOperand = lblDisplay.Text;
                    //string result = engine.Calculate(operate, operate2, firstOperand, secondOperand);
                    if (firstOperand != null)
                    {
                        string result = engine.Calculate(operate, operate2, firstOperand, secondOperand);
                        lblDisplay.Text = result;

                    }
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    
                    break;

            }
        }

        private void Oneoverx_Click(object sender, EventArgs e)//oneoverx
        {
            operate4 = ((Button)sender).Text;
            switch (operate4)
            {
                case "1/x":
                    double oneOverx = (Convert.ToDouble(lblDisplay.Text));
                    lblDisplay.Text = (1 / oneOverx).ToString();
                    if (lblDisplay.Text.Length > 8)
                    {
                        string oneoverxLength = lblDisplay.Text;
                        lblDisplay.Text = oneoverxLength.Substring(0, 8);
                    }
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    break;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mFunction = ((Button)sender).Text;
            switch(mFunction)
            {
                case "MC":
                    memoryOfm = "0";
                    lblDisplay.Text = "0";
                    break;
                case "MR":
                    lblDisplay.Text = memoryOfm;
                    break;
                case "MS":
                    memoryOfm = lblDisplay.Text;
                    lblDisplay.Text = "0";
                    break;
                case "M+":
                    lblDisplay.Text = (Convert.ToDouble(memoryOfm) + Convert.ToDouble(lblDisplay.Text)).ToString(); 
                    break;
                case "M-":
                    lblDisplay.Text = (Convert.ToDouble(memoryOfm) - Convert.ToDouble(lblDisplay.Text)).ToString();
                    break;
            }

        }
    }
}
