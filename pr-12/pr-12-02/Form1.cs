﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pr_12_02
{
    public partial class Form1 : Form
    {
        Transposition t;
        public Form1()
        {
            InitializeComponent();

            t = new Transposition();
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            t.SetKey(keyTextBox.Text);

            if (encryptRadioButton.Checked)
                resultTextBox.Text = t.Encrypt(messageTextBox.Text);
            else
                resultTextBox.Text = t.Decrypt(messageTextBox.Text);
        }
    }
}
