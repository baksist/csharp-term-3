using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pr_11_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Image files(*.bmp, *.jpg, *.gif, *.png)|*.bmp;*.jpg;*.gif;*.png|All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = new Bitmap(ofd.FileName);
                }
                catch
                {
                    MessageBox.Show("Can't open file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                var sfd = new SaveFileDialog();
                sfd.Title = "Save image as...";

                sfd.OverwritePrompt = true;
                sfd.CheckPathExists = true;

                sfd.Filter = "Image files(*.bmp)|*.bmp|Image files(*.jpg)|*.jpg|Image files(*.gif)|*.gif|Image files(*.png)|*.png)|All files (*.*)|*.*";
                sfd.ShowHelp = true;
                
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pictureBox2.Image.Save(sfd.FileName);
                    }
                    catch
                    {
                        MessageBox.Show("Can't save file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void grayButton_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                var input = new Bitmap(pictureBox1.Image);
                var output = new Bitmap(input.Width, input.Height);

                for (int j = 0; j < input.Height; j++)
                {
                    for (int i = 0; i < input.Width; i++)
                    {
                        var pixel = (UInt32)(input.GetPixel(i, j).ToArgb());
                        var r = (float)((pixel & 0x00FF0000) >> 16);
                        var g = (float)((pixel & 0x0000FF00) >> 8);
                        var b = (float)(pixel & 0x000000FF);
                        r = g = b = (r + g + b) / 3.0f;

                        UInt32 newPixel = 0xFF000000 | ((UInt32)r << 16) | ((UInt32)g << 8) | (UInt32)b;
                        output.SetPixel(i, j, Color.FromArgb((int)newPixel));
                    }
                }
                pictureBox2.Image = output;
            }
        }
    }
}
