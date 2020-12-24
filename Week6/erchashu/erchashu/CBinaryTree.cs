using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace erchashu
{
    class CBinaryTree
    {
        public CBinaryTree()
        {
            treeroot = null;
        }
        CBinaryTreenode<char> treeroot;
        public void CreateBinTreestr(string binitreestr)//根据字符串生成二叉树
        {
            if (treeroot != null)
                treeroot = null;
            string strt = "1234567890+-*/";
            char ch, chlr = ' ';
            CLinkStack<CBinaryTreenode<char>> mystack = new CLinkStack<CBinaryTreenode<char>>();//设置栈
            CBinaryTreenode<char> stp, stpnew;//存放栈顶的返回值
            stpnew = null;
            int n = binitreestr.Length;
            for (int i = 0; i < n; i++)
            {
                ch = binitreestr[i];
                if (((ch >= 'A') && (ch <= 'Z')) || ((ch >= 'a') && (ch <= 'z')) || (strt.IndexOf(ch) >= 0))
                {
                    stp = mystack.Gettop();//取栈顶x
                    //创建节点并于栈顶链接
                    stpnew = new CBinaryTreenode<char>(ch);
                    if (stp == null)
                        treeroot = stpnew;
                    else
                    {
                        if (chlr == 'I') 
                            stp.lchild = stpnew;
                        else 
                            stp.rchild = stpnew;
                    }
                }
                else if (ch == '(')
                {
                    chlr = 'l';//设置左右
                    mystack.Push(stpnew);//当前点入栈
                }
                else if (ch == ',')
                    chlr = 'r';//设置左右
                else if (ch == ')')
                    mystack.Pop();//入栈
            }
        }
        public void DrawBTree(PictureBox pb_bstree)
        {
            CLinkStack<drawbtreetype<char>> stree = new CLinkStack<drawbtreetype<char>>();
            drawbtreetype<char> sp, spt;
            CBinaryTreenode<char> pbtnode, pbtnodenow;
            if (treeroot == null)
                return;
            Graphics myg;
            int xmin = 0;
            int ymin = 0;
            int xmax, ymax;

            myg = pb_bstree.CreateGraphics();
            xmax = pb_bstree.Width;
            ymax = pb_bstree.Height;
            //设置显示颜色
            Color bkColor0;
            Brush bkBrush0;
            Brush bkbrush = new SolidBrush(Color.White);//背景色
            bkColor0 = Color.FromArgb(255, 0, 255, 255);
            bkBrush0 = new SolidBrush(bkColor0);
            Pen pen1 = new Pen(Color.Red, 2);
            //画背景
            myg.FillRectangle(bkbrush, xmin, ymin, xmax - xmin, ymax - ymin);
            string str;
            Font font = new Font("Arial", 10);
            SolidBrush b1 = new SolidBrush(Color.Blue);
            StringFormat sf1 = new StringFormat();

            //画图数据初始化
            double xx = xmax / 2;
            double yy = ymax - 50;
            int level = 1;
            double xnow;
            double ynow;
            double alpha;

            double len = 150;
            double lenbl = 0.8;
            double dw = 0;
            int dt = 100;
            //画树根中心点
            spt = new drawbtreetype<char>();
            spt.pbtnode = treeroot;
            spt.px = xx;
            spt.py = yy;
            spt.level = level;
            stree.Push(spt);//树根入栈
            myg.FillEllipse(bkBrush0, (int)(xx - 12), (int)(ymax - yy - 12), 24, 24);
            myg.DrawEllipse(pen1, (int)(xx - 12), (int)(ymax - yy - 12), 24, 24);
            str = "" + treeroot.data;
            myg.DrawString(str, font, b1, (int)(xx - 5), (int)(ymax - yy - 8), sf1);
            Thread.Sleep(dt);
            while (!stree.IsEmpty())
            {
                sp = stree.Pop();
                pbtnode = sp.pbtnode;
                xx = sp.px;
                yy = sp.py;
                level = sp.level;
                //设置比例
                if (level == 0)
                { lenbl = 0; dw = 0; }
                else if (level == 1)
                { lenbl = 1; dw = 70; }
                else if (level == 2)
                { lenbl = 0.8; dw = 40; }
                else if (level == 3)
                { lenbl = 0.6; dw = 30; }
                else if (level == 4)
                { lenbl = 0.5; dw = 20; }
                else if (level == 5)
                { lenbl = 0.4; dw = 15; }
                else
                { lenbl = 0.3; dw = 15; }
                pbtnodenow = pbtnode.lchild;
                if (pbtnodenow != null)
                {
                    //设置转角
                    alpha = -90 - dw;
                    //求新点坐标
                    xnow = xx + len * lenbl * Math.Cos(alpha * 3.14 / 180.0);
                    ynow = yy + len * lenbl * Math.Sin(alpha * 3.14 / 180.0);
                    //画线
                    myg.DrawLine(pen1, (int)xx, (int)(ymax - yy), (int)xnow, (int)(ymax - ynow));
                    //画中心点
                    myg.FillEllipse(bkBrush0, (int)(xx - 12), (int)(ymax - yy - 12), 24, 24);
                    myg.DrawEllipse(pen1, (int)(xx - 12), (int)(ymax - yy - 12), 24, 24);
                    str = "" + pbtnode.data;
                    myg.DrawString(str, font, b1, (int)(xx - 5), (int)(ymax - yy - 8), sf1);
                    myg.FillEllipse(bkBrush0, (int)(xnow - 12), (int)(ymax - ynow - 12), 24, 24);
                    myg.DrawEllipse(pen1, (int)(xnow - 12), (int)(ymax - ynow - 12), 24, 24);
                    str = "" + pbtnodenow.data;
                    myg.DrawString(str, font, b1, (int)(xnow - 5), (int)(ymax - ynow - 8), sf1);

                    //左孩子结点入栈
                    spt = new drawbtreetype<char>();
                    spt.pbtnode = pbtnodenow;
                    spt.px = xnow;
                    spt.py = ynow;
                    spt.level = level + 1;
                    stree.Push(spt);
                }
                Thread.Sleep(dt);
                pbtnodenow = pbtnode.rchild;
                if (pbtnodenow != null)
                {
                    //设置转角
                    alpha = -90 + dw;
                    //求新点坐标
                    xnow = xx + len * lenbl * Math.Cos(alpha * 3.14 / 180.0);
                    ynow = yy + len * lenbl * Math.Sin(alpha * 3.14 / 180.0);
                    //画线
                    myg.DrawLine(pen1, (int)xx, (int)(ymax - yy), (int)xnow, (int)(ymax - ynow));
                    //画中心点
                    myg.FillEllipse(bkBrush0, (int)(xx - 12), (int)(ymax - yy - 12), 24, 24);
                    myg.DrawEllipse(pen1, (int)(xx - 12), (int)(ymax - yy - 12), 24, 24);
                    str = "" + pbtnode.data;
                    myg.DrawString(str, font, b1, (int)(xx - 5), (int)(ymax - yy - 8), sf1);
                    myg.FillEllipse(bkBrush0, (int)(xnow - 12), (int)(ymax - ynow - 12), 24, 24);
                    myg.DrawEllipse(pen1, (int)(xnow - 12), (int)(ymax - ynow - 12), 24, 24);
                    str = "" + pbtnodenow.data;
                    myg.DrawString(str, font, b1, (int)(xnow - 5), (int)(ymax - ynow - 8), sf1);

                    //右孩子结点入栈
                    spt = new drawbtreetype<char>();
                    spt.pbtnode = pbtnodenow;
                    spt.px = xnow;
                    spt.py = ynow;
                    spt.level = level + 1;
                    stree.Push(spt);
                    Thread.Sleep(dt);
                }
            }
        }

        public void Traversal(int k, out string m_strout)
        {
            m_strout = "";
            if (k == 0)
            {
                CQueue<CBinaryTreenode<char>> qtree = new CQueue<CBinaryTreenode<char>>();
                CBinaryTreenode<char> p;
                if (treeroot != null)
                    qtree.In(treeroot);//树根入队
                else
                {
                    m_strout = "空树!";
                    return;
                }
                while (!qtree.IsEmpty())
                {
                    p = qtree.Out();
                    m_strout += " " + p.data.ToString();
                    if (p.lchild != null)
                        qtree.In(p.lchild);
                    if (p.rchild != null)
                        qtree.In(p.rchild);
                }
            }
            else
            {
                CLinkStack<CBinaryTreenode<char>> stree = new CLinkStack<CBinaryTreenode<char>>();
                CBinaryTreenode<char> p;
                CLinkStack<int> sno = new CLinkStack<int>();
                int no;
                if (treeroot != null)
                {
                    stree.Push(treeroot);//树根入栈
                    sno.Push(1);
                }
                else
                {
                    m_strout = "空树!\r\n";
                    return;
                }
                while (!stree.IsEmpty())
                {
                    no = sno.Pop();
                    p = stree.Gettop();
                    if (p == null)
                    {
                        stree.Pop();
                        continue;
                    }
                    if (no == 1)
                    {
                        sno.Push(2);
                        stree.Push(p.lchild);
                        sno.Push(1);
                        if (k == 1)
                            m_strout += " " + p.data.ToString();
                    }
                    else if (no == 2)
                    {
                        sno.Push(3);
                        stree.Push(p.rchild); sno.Push(1);
                        if (k == 2)
                            m_strout += " " + p.data.ToString();
                    }
                    else if (no == 3)
                    {
                        stree.Pop();
                        if (k == 3)
                            m_strout += " " + p.data.ToString();
                    }
                }
            }
        }

    }
    public class drawbtreetype<Type>
    {
        public CBinaryTreenode<Type> pbtnode;
        public double px, py;
        public int level;
    }; //画二叉树图时的辅助表
}
