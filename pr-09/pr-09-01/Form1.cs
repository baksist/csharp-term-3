using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pr_09_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random rnd = new Random();
        Point tmpLocation;
        int w = SystemInformation.PrimaryMonitorSize.Width;
        int h = SystemInformation.PrimaryMonitorSize.Height;

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            textBox1.Text = e.X.ToString();
            textBox2.Text = e.Y.ToString();

            var x1 = button1.Location.X;
            var x2 = x1 + button1.Width;
            var y1 = button1.Location.Y;
            var y2 = y1 + button1.Height;

            if (e.X > (x1 - 10) && e.X < (x2 + 10) && e.Y > (y1 - 10) && e.Y < (y2 + 10))
            {
                tmpLocation = this.Location;
                tmpLocation.X += rnd.Next(-100, 100);
                tmpLocation.Y += rnd.Next(-100, 100);

                if (tmpLocation.X < 0 || tmpLocation.X > (w - this.Width / 2) || tmpLocation.Y < 0 || tmpLocation.Y > (h - this.Height / 2))
                {
                    tmpLocation.X = w / 2;
                    tmpLocation.Y = h / 2;
                }
                this.Location = tmpLocation;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вы усердны!");
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Мы не сомневались в вашем безразличии", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
