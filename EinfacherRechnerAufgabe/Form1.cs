using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EinfacherRechnerAufgabe
{
    public partial class Form1 : Form
    {
        string input = "";
        double num1, num2;
        double result;
        string mathOperator = "";
        bool pending = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void bt_0_Click(object sender, EventArgs e)
        {
            button_Click(sender, e);
        }

        private void bt_dot_Click(object sender, EventArgs e)
        {
            button_Click(sender, e);
        }

        private void bt_3_Click(object sender, EventArgs e)
        {
            button_Click(sender, e);
        }

        private void bt_2_Click(object sender, EventArgs e)
        {
            button_Click(sender, e);
        }

        private void bt_1_Click(object sender, EventArgs e)
        {
            button_Click(sender, e);
        }

        private void bt_4_Click(object sender, EventArgs e)
        {
            button_Click(sender, e);
        }

        private void bt_5_Click(object sender, EventArgs e)
        {
            button_Click(sender, e);
        }

        private void bt_6_Click(object sender, EventArgs e)
        {
            button_Click(sender, e);
        }

        private void bt_9_Click(object sender, EventArgs e)
        {
            button_Click(sender, e);
        }

        private void bt_8_Click(object sender, EventArgs e)
        {
            button_Click(sender, e);
        }

        private void bt_7_Click(object sender, EventArgs e)
        {
            button_Click(sender, e);
        }

        private void bt_clear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            input += btn.Text;
            tb_input.Text = input;
        }
        private void ClearAll()
        {
            input = "";
            num1 = 0;
            num2 = 0;
            result = 0;
            mathOperator = "";
            tb_input.Text = "";
        }
        private void Result()
        {
            switch (mathOperator)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "x":
                    result = num1 * num2;
                    break;
                case "/":
                    if (num2 != 0)
                        result = num1 / num2;
                    else
                        MessageBox.Show("Division durch Null ist nicht erlaubt! Willst du die Welt brennen sehen?");
                    break;
            }
            tb_history.Text = num1.ToString() + " " + mathOperator + " " + num2.ToString();
            tb_input.Text = result.ToString();
        }

        private void bt_multiply_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            DoMathOperation(btn.Text);
        }

        private void bt_divide_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            DoMathOperation(btn.Text);
        }

        private void bt_plus_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            DoMathOperation(btn.Text);
        }

        private void bt_minus_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            DoMathOperation(btn.Text);
        }

        private void bt_equals_Click(object sender, EventArgs e)
        {
            Result();
        }

        private void DoMathOperation(string op)
        {
            if (!pending)
            {
                num1 = double.Parse(input);
                mathOperator = op;
                tb_history.Text = num1.ToString() + " " + mathOperator;
                input = "";
                pending = true;
            }
            else
            {
                num2 = double.Parse(input);
                Result();
                mathOperator = op;
                input = "";
            }
        }
    }
}
