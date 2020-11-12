using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pr_10_02
{
    public partial class Form1 : Form
    {
        int balance = 100;
        int counterMoney = 0;
        int counterTry = 0;
        int winMoney = 0;
        bool isActive = true;
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
        }

        private void dvg1_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            int dvg = random.Next(8);
            label1.Text = dvg.ToString();
        }

        private void dvg2_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            int dvg = random.Next(8);
            label2.Text = dvg.ToString();
        }

        private void dvg3_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            int dvg = random.Next(8);
            label3.Text = dvg.ToString();
        }

        private void stop1_Tick(object sender, EventArgs e)
        {
            dvg1.Enabled = false;
            stop1.Enabled = false;
        }

        private void stop2_Tick(object sender, EventArgs e)
        {
            dvg2.Enabled = false;
            stop2.Enabled = false;
        }

        private void stop3_Tick(object sender, EventArgs e)
        {
            counterTry--;
            dvg3.Enabled = false;
            stop3.Enabled = false;
            WinMoney();
            if (isActive)
            {
                if (counterTry != 0)
                {
                    label6.Text = "Tries left: " + counterTry;
                    button1.Enabled = true;
                }
                else
                {
                    label6.Text = "Tries left: " + counterTry;
                    MessageBox.Show("Place a new bet!", "No tries left...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button2.Enabled = true;
                }
            }
        }

        private void WinMoney()
        {
            if (label1.Text == label2.Text && label2.Text == label3.Text)
            {
                if (label1.Text == "0")
                    updWinMoney(17);
                else if (label1.Text == "7")
                    updWinMoney(20);
                else
                    updWinMoney(10 + Int32.Parse(label1.Text) - 1);
            }
            else if (label1.Text == label2.Text || label2.Text == label3.Text)
            {
                if (label2.Text == "0")
                    updWinMoney(7);
                else if (label2.Text == "7")
                    updWinMoney(10);
                else
                    updWinMoney(Int32.Parse(label2.Text));
            }
        }

        private void updWinMoney(int number)
        {
            winMoney = counterMoney * number;
            DialogResult result = MessageBox.Show("You won: $" + winMoney, "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            balance = balance + winMoney;
            label4.Text = "Credit: $" + balance;
            button1.Enabled = false;
            button2.Enabled = true;
            isActive = false;
            if (result == DialogResult.OK)
            {
                MessageBox.Show("Place new bet!", "New game", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                label6.Text = "Tries left: 0";
            }
        }

        private void initCounter(decimal counter)
        {
            counterMoney = Convert.ToInt32(counter);
            balance = balance - counterMoney;
            label4.Text = "Credit: $" + balance;
            counterTry = 5;
            label6.Text = "Tries left: " + counterTry;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            initCounter(numericUpDown1.Value);
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dvg1.Enabled = true;
            dvg2.Enabled = true;
            dvg3.Enabled = true;
            stop1.Enabled = true;
            stop2.Enabled = true;
            stop3.Enabled = true;
            isActive = true;
            button1.Enabled = false;
        }
    }
}
