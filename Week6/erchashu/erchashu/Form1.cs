using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace erchashu
{
    public partial class Form1 : Form
    {

        
        public Form1()
        {
            InitializeComponent();
        }
        CBinaryTree bt = new CBinaryTree();
        private void button1_Click(object sender, EventArgs e)
        {
            string btstr = bintreestr.Text;
            bt.CreateBinTreestr(btstr);
            bt.DrawBTree(pictureBox1);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
