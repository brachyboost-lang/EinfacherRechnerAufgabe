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
        string operation;
        public Form1()
        {
            InitializeComponent();
        }

        private void bt_0_Click(object sender, EventArgs e)
        {
            button_Click(sender, e);
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            input += btn.Text;
            tb_input.Text = input;
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

        private void ClearAll()
        {
            input = "";
            num1 = 0;
            num2 = 0;
            result = 0;
            operation = "";
            tb_input.Text = "";
        }
    }
}
