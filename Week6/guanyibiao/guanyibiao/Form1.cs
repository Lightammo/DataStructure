﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace guanyibiao
{
    public partial class Form1 : Form
    {
        CLinkStack<CGenListnode> stp = new CLinkStack<CGenListnode>();
        public Form1()
        {
            InitializeComponent();
        }
        private CGenList cg = new CGenList();

        private void button1_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            cg.CreateGL(s, out s);
            richTextBox1.Text = s;
            radioButton1.Checked = true;
            radioButton2.Checked = false;
        }
    }
}
