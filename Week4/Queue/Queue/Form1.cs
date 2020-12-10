using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Queue
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private CMaze m_maze = new CMaze("");

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bt_openfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            string str = "..\\..\\data\\";
            dlg.InitialDirectory = str;
            dlg.Filter = "数据文件（maze*.dat）|maze*.dat|文本文件（maze*.txt）|maze*.txt";
            dlg.Title = "打开迷宫数据文件";
            if (dlg.ShowDialog() == DialogResult.OK)  //DialogResult.OK，如果返回结果为：点击确定
            {
                tb_fname.Text = dlg.FileName;
                StreamReader sr = new StreamReader(tb_fname.Text);
                tb_maze_matrix.Text = sr.ReadToEnd();
                sr.Close();
            }

        }

        private void bt_createmaze_Click(object sender, EventArgs e)
        {
            m_maze = new CMaze(tb_maze_matrix.Text);  //调用CMaze类，输入为文本形式
            DrawMaze(m_maze, false);
            m_maze.ShortPath(1);
            DrawMaze(m_maze, true);
            tb_MazeQueue.Text = m_maze.PrintMazeQueue();
        }
        void DrawMaze(CMaze m_maze, bool IsPath)  //画迷宫图案
        {
            Graphics myg;
            int xmin = 0;
            int ymin = 0;
            int xmax, ymax;

            int m = m_maze.Rows;
            int n = m_maze.Cols;
            if (m == 0 || n == 0)
                return;
            if (IsPath == false)
            {
                myg = pb_maze.CreateGraphics();
                xmax = pb_maze.Width;
                ymax = pb_maze.Height;
            }
            else
            {
                myg = pb_mazepath.CreateGraphics();
                xmax = pb_mazepath.Width;
                ymax = pb_mazepath.Height;
            }
            //设置显示颜色
            Color bkColor0, bkColor1, bkColor2;
            Brush bkBrushnow, bkBrush0, bkBrush1, bkBrush2;
            Brush bkbrush = new SolidBrush(Color.White);//背景色
            bkColor0 = Color.FromArgb(255, 255, 255, 0);//能通行的节点颜色
            bkBrush0 = new SolidBrush(bkColor0);
            bkColor1 = Color.FromArgb(255, 125, 125, 125);//不能通行的节点颜色
            bkBrush1 = new SolidBrush(bkColor1);
            bkColor2 = Color.FromArgb(255, 0, 255, 0);//最短路径的节点颜色
            bkBrush2 = new SolidBrush(bkColor2);
            //画背景
            myg.FillRectangle(bkbrush, xmin, ymin, xmax - xmin, ymax - ymin);
            int cw, ch;
            int px, py, i, j;
            string str;
            cw = (xmax - 30) / n;
            ch = (ymax - 30) / m;
            Font font = new Font("Arial", 10);
            SolidBrush b1 = new SolidBrush(Color.Blue);
            StringFormat sf1 = new StringFormat();
            for (i = 0; i < m; i++)
            {
                py = 25 + ch * i;
                str = "" + (i + 1);
                myg.DrawString(str, font, b1, 0, py, sf1);
            }
            for (j = 0; j < n; j++)
            {
                px = 25 + cw * j;
                str = "" + (j + 1);
                myg.DrawString(str, font, b1, px, 0, sf1);
            }

            for (i = 0; i < m; i++)
            {
                py = 20 + ch * i;
                for (j = 0; j < n; j++)
                {
                    px = 20 + cw * j;
                    bkBrushnow = bkBrush0;
                    if (m_maze.Getelems(i + 1, j + 1) == 0)
                        bkBrushnow = bkBrush0;
                    else if (m_maze.Getelems(i + 1, j + 1) == 1)
                        bkBrushnow = bkBrush1;
                    if (IsPath == true)
                    {
                        if (m_maze.Getelems(i + 1, j + 1) == -1)
                            bkBrushnow = bkBrush2;
                    }
                    Rectangle rc = new Rectangle(px, py, cw, ch);
                    myg.FillRectangle(bkBrushnow, rc);
                    Pen pen1 = new Pen(Color.Red, 1);
                    myg.DrawRectangle(pen1, rc);
                }
            }
        }

        private void tb_maze_matrix_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
