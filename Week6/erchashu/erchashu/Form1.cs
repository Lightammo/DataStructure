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

        private void button3_Click(object sender, EventArgs e)
        {
            string shuchu = "";
            if (radioButton1.Checked)
                bt.Traversal(0, out shuchu);
            if (radioButton2.Checked)
                bt.Traversal(1, out shuchu);
            else if (radioButton3.Checked)
                bt.Traversal(2, out shuchu);
            else if (radioButton4.Checked)
                bt.Traversal(3, out shuchu);
           
            int length = shuchu.Length;
            Graphics g = pictureBox1.CreateGraphics();
            Brush bkbrush = new SolidBrush(Color.White);//背景色
            g.FillRectangle(bkbrush, 10, 10, 10 * length, 15);
            Font f = new Font("Arial", 10);
            Brush bb = new SolidBrush(Color.Red);
            g.DrawString(shuchu, f, bb, 10, 10);
        }
    }
}
