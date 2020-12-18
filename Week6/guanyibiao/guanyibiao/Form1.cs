using System;
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
        public Form1()
        {
            InitializeComponent();
        }

        public void CreateGL(string strin,out string strout)
        {
            if (head.tnext != null)
                MakeEmpty(out strout);
            string tstr;
            strout = "输入字符串=";
            tstr = strin;
            strout += tstr + "\r\n";
            strout = "广义表的创建\r\n";
            ClinkStack<CGenListnode> stp = new CLinkStack<CGenListnode>();

        }
    }
}
