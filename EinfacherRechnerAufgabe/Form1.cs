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
        double num1, num2, num3;
        double result;
        string mathOperator = "";
        string mathOperator2 = "";
        bool pending1 = false;
        bool pending2 = false;
        public Form1()
        {
            InitializeComponent();
            tb_input.TextAlign = HorizontalAlignment.Right;
            tb_history.TextAlign = HorizontalAlignment.Right;
            tb_history2.TextAlign = HorizontalAlignment.Right;
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
            if (string.IsNullOrEmpty(input))
            {
                return;
            }

            if (pending2)
            {
                double num3 = double.Parse(input);
                tb_history2.Text = num1.ToString() + " " + mathOperator + " " + num2.ToString() + " " + mathOperator2 + " " + num3.ToString();
                double temp = 0;
                switch (mathOperator2)
                {
                    case "x":
                        temp = num2 * num3;
                        break;
                    case "/":
                        if (num3 != 0)
                            temp = num2 / num3;
                        else
                        {
                            MessageBox.Show("Division durch Null ist nicht erlaubt! Willst du die Welt brennen sehen?");
                            return;
                        }
                        break;
                }

                num2 = temp;
                pending2 = false;
                mathOperator2 = "";
            }
            else
            {
                num2 = double.Parse(input);
                tb_history2.Text = num1.ToString() + " " + mathOperator + " " + num2.ToString();
            }

            Result();
            input = result.ToString();
            num1 = result;
            pending1 = false;
            mathOperator = "";
            UpdateBaseDisplays();
        }

        private void DoMathOperation(string op)
        {
            if (string.IsNullOrEmpty(input))
            {
                return;
            }

            if (!pending1)
            {
                num1 = double.Parse(input);
                mathOperator = op;
                tb_history.Text = num1.ToString() + " " + mathOperator;
                tb_history2.Text = "";
                input = "";
                UpdateBaseDisplays(num1);
                pending1 = true;
                return;
            }

            if (!pending2)
            {
                num2 = double.Parse(input);

                if ((mathOperator == "+" || mathOperator == "-") && (op == "x" || op == "/"))
                {
                    mathOperator2 = op;
                    pending2 = true;
                    tb_history.Text = num1.ToString() + " " + mathOperator + " " + num2.ToString() + " " + mathOperator2;
                    tb_history2.Text = num1.ToString() + " " + mathOperator + " " + num2.ToString() + " " + mathOperator2;
                    input = "";
                    UpdateBaseDisplays(num2);
                    return;
                }

                tb_history2.Text = num1.ToString() + " " + mathOperator + " " + num2.ToString();
                Result();
                num1 = result;
                mathOperator = op;
                tb_history.Text = num1.ToString() + " " + mathOperator;
                input = "";
                UpdateBaseDisplays(num1);
                pending1 = true;
            }
            else
            {
                num3 = double.Parse(input);
                tb_history2.Text = num1.ToString() + " " + mathOperator + " " + num2.ToString() + " " + mathOperator2 + " " + num3.ToString();
                double temp = 0;
                switch (mathOperator2)
                {
                    case "x":
                        temp = num2 * num3;
                        break;
                    case "/":
                        if (num3 != 0)
                            temp = num2 / num3;
                        else
                        {
                            MessageBox.Show("Division durch Null ist nicht erlaubt! Willst du die Welt brennen sehen?");
                            return;
                        }
                        break;
                }

                num2 = temp;
                pending2 = false;
                mathOperator2 = "";

                Result();
                num1 = result;
                mathOperator = op;
                tb_history.Text = num1.ToString() + " " + mathOperator;
                input = "";
                UpdateBaseDisplays(num1);
                pending1 = true;
            }
        }
        private void button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            input += btn.Text;
            tb_input.Text = input;
            UpdateBaseDisplays();
        }

        private void bt_neg_Click(object sender, EventArgs e)
        {
            double.TryParse(tb_input.Text, out double temp);
            if (temp >= 0)
                {
                input = "-" + input;
                tb_input.Text = input;
                UpdateBaseDisplays();
            }
            else
            {
                input = input.TrimStart('-');
                tb_input.Text = input;
                UpdateBaseDisplays();
            }
        }

        private void bt_del_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(input))
            {
                return;
            }

            input = input.Substring(0, input.Length - 1);
            tb_input.Text = input;
            UpdateBaseDisplays();
        }

        private void UpdateBaseDisplays()
        {
            if (!double.TryParse(tb_input.Text, out double val))
            {
                tb_bin.Text = "";
                tb_hex.Text = "";
                return;
            }

            if (double.IsNaN(val) || double.IsInfinity(val))
            {
                tb_bin.Text = "";
                tb_hex.Text = "";
                return;
            }

            long l;
            try
            {
                l = (long)val;
            }
            catch
            {
                tb_bin.Text = "";
                tb_hex.Text = "";
                return;
            }

            if (l == long.MinValue)
            {
                tb_bin.Text = "";
                tb_hex.Text = "";
                return;
            }

            bool negative = l < 0;
            long abs = negative ? -l : l;
            string bin = Convert.ToString(abs, 2);
            string hex = abs.ToString("X");
            tb_bin.Text = (negative ? "-" : "") + bin;
            tb_hex.Text = (negative ? "-" : "") + hex;
        }

        private void UpdateBaseDisplays(double val)
        {
            if (double.IsNaN(val) || double.IsInfinity(val))
            {
                tb_bin.Text = "";
                tb_hex.Text = "";
                return;
            }

            long l;
            try
            {
                l = (long)val;
            }
            catch
            {
                tb_bin.Text = "";
                tb_hex.Text = "";
                return;
            }

            if (l == long.MinValue)
            {
                tb_bin.Text = "";
                tb_hex.Text = "";
                return;
            }

            bool negative = l < 0;
            long abs = negative ? -l : l;
            string bin = Convert.ToString(abs, 2);
            string hex = abs.ToString("X");
            tb_bin.Text = (negative ? "-" : "") + bin;
            tb_hex.Text = (negative ? "-" : "") + hex;
        }

        private void bt_quad_Click(object sender, EventArgs e)
        {
            double value;
            if (string.IsNullOrEmpty(input))
            {
                if (!double.TryParse(tb_input.Text, out value))
                    return;
            }
            else
            {
                value = double.Parse(input);
            }

            double sq = value * value;
            input = sq.ToString();
            tb_input.Text = input;
            tb_history.Text = value.ToString() + "^2 = " + sq.ToString();
            tb_history2.Text = "sqr(" + value.ToString() + ")";
            result = sq;
            num1 = result;
            pending1 = false;
            pending2 = false;
            mathOperator = "";
            mathOperator2 = "";
            UpdateBaseDisplays();
        }

        private void bt_sqrt_Click(object sender, EventArgs e)
        {
            double value;
            if (string.IsNullOrEmpty(input))
            {
                if (!double.TryParse(tb_input.Text, out value))
                    return;
            }
            else
            {
                value = double.Parse(input);
            }

            if (value < 0)
            {
                MessageBox.Show("Quadratwurzel einer negativen Zahl ist nicht erlaubt.");
                return;
            }

            double r = Math.Sqrt(value);
            input = r.ToString();
            tb_input.Text = input;
            tb_history.Text = "√(" + value.ToString() + ") = " + r.ToString();
            tb_history2.Text = "sqrt(" + value.ToString() + ")";
            result = r;
            num1 = result;
            pending1 = false;
            pending2 = false;
            mathOperator = "";
            mathOperator2 = "";
            UpdateBaseDisplays();
        }

        private void ClearAll()
        {
            input = "";
            num1 = 0;
            num2 = 0;
            num3 = 0;
            result = 0;
            mathOperator = "";
            mathOperator2 = "";
            tb_input.Text = "";
            tb_history.Text = "";
            tb_history2.Text = "";
            tb_bin.Text = "";
            tb_hex.Text = "";
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
    }
}
