using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pr_09_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rsl = MessageBox.Show("Do you really want to quit?", "Attention!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rsl == DialogResult.Yes)
            {
                Application.Exit();
            }    
        }

        Image MemForImage;
        private void LoadImage(bool jpg)
        {
            openFileDialog1.InitialDirectory = "c:";
            if(jpg)
            {
                openFileDialog1.Filter = "image (JPEG) files (*.jpg)|*.jpg|All files(*.*)|*.*";
            }
            else
            {
                openFileDialog1.Filter = "image (PNG) files (*.png)|*.png|All files(*.*)|*.*";
            }
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    MemForImage = Image.FromFile(openFileDialog1.FileName);
                    pictureBox1.Image = MemForImage;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Couldn't load file: " + ex.Message);
                }
            }
        }
        private void jPGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadImage(true);
        }

        private void pNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadImage(false);
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form preview = new Preview(MemForImage);
            preview.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LoadImage(true);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            LoadImage(false);
        }


    }
}
