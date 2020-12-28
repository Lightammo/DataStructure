using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;

namespace SJKS20S30
{
    public class drawbtreetype<Type>
    {
        public CBinaryTreenode<Type> pbtnode;
        public double px, py;
        public int level;
    };  //画二叉树图时的辅助表
    public class help<Type>
    {
        public int t1b, t2b, tln;//先序中开始位置,中序中开始位置,树长
        public CBinaryTreenode<Type> adr;
    }; //由先序序列,中序序列生成二叉树的帮助表
    public class CBinaryTreenode<Type>
    {
        public Type data;
        public CBinaryTreenode<Type> lchild, rchild;
        public CBinaryTreenode()
        {
            lchild = rchild = null;
        }
        public CBinaryTreenode(Type item)
        {
            data = item;
            lchild = rchild = null;
        }
        public CBinaryTreenode(Type item, CBinaryTreenode<Type> lc, CBinaryTreenode<Type> rc)
        {
            data = item;
            lchild = lc; rchild = rc;
        }

    }
    class CBinaryTree
    {
        public interface ICStack<Type>//接口
        {
            bool IsEmpty();//判栈空
            bool IsFull();//判栈满
            void MakeEmpty();//清空
            bool Push(Type item);//入栈
            Type Pop();//出栈
            Type Gettop();//取栈顶
            string GetStackALLDate(string sname);
        }

        class CStacknode<Type>//链栈结点类
        {
            private Type data;
            private CStacknode<Type> next;
            //--------------------------------------------------------------------------------
            public CStacknode()
            {
                next = null;
            }
            public CStacknode(Type data)
            {
                this.data = data;
                next = null;
            }
            public CStacknode(Type data, CStacknode<Type> next)
            {
                this.data = data;
                this.next = next;
            }
            public Type Data
            {
                get { return data; }
                set { data = value; }
            }
            public CStacknode<Type> Next
            {
                get { return next; }
                set { next = value; }
            }
        }
        class CLinkStack<Type> : ICStack<Type>
        {
            private CStacknode<Type> top;
            //--------------------------------------------------------------------------------
            public void MakeEmpty() { top = null; }//清空
            public bool IsEmpty() { return top == null; }//判栈空
            public bool IsFull() { return false; }//判栈满

            public CLinkStack()
            {
                top = null;
            }
            public bool Push(Type item)//入栈
            {
                top = new CStacknode<Type>(item, top);
                return (true);
            }
            public Type Pop()//出栈
            {
                Type dt = top.Data;
                top = top.Next;
                return dt;
            }
            public Type Gettop()//取栈顶
            {
                if (top == null)
                    return default(Type);
                else
                    return top.Data;
            }
            public string GetStackALLDate(string sname)
            {
                string str = "  】";
                if (IsEmpty()) str = sname + " stack is null";
                CStacknode<Type> p = top;
                while (p != null)
                {
                    str = p.Data + "    " + str;
                    p = p.Next;
                }
                str = "【  " + str + "\r\n";
                str = str + "---------------------------------------" + "\r\n";
                return str;
            }
        }

        public class CSeqStack<Type> : ICStack<Type>
        {
            private int top;
            private Type[] elems;
            private int Maxsize = 100;
            //--------------------------------------------------------------------------------
            public void MakeEmpty() { top = -1; }//清空
            public bool IsEmpty() { return top == -1; }//判栈空
            public bool IsFull() { return top == Maxsize - 1; }//判栈满
                                                               ///////////////////////////////////////////////////////////
            public Type this[int index]
            {
                get { return elems[index]; }
                set { elems[index] = value; }
            }
            public int Top
            {
                get { return top; }
            }

            public CSeqStack()
            {
                elems = new Type[Maxsize];
                top = -1;
            }
            public CSeqStack(int max)
            {
                Maxsize = max;
                elems = new Type[Maxsize];
                top = -1;
            }
            ///////////////////////////////////////////////////////////
            public bool Push(Type item)//入栈
            {
                if (!IsFull())
                {
                    elems[++top] = item;
                    return (true);
                }
                else
                    return (false);
            }
            ///////////////////////////////////////////////////////////
            public Type Pop()//出栈
            {
                if (!IsEmpty())
                    return elems[top--];
                else
                    return elems[0];
            }
            ///////////////////////////////////////////////////////////
            public Type Gettop()//取栈顶
            {
                if (!IsEmpty())
                    return elems[top];
                else
                    return elems[0];
            }
            public string GetStackALLDate(string sname)
            {
                string str = "";
                if (IsEmpty()) str = sname + " stack is null";
                for (int i = 0; i <= top; i++)
                {
                    str = str + "  " + elems[i].ToString() + "  ";
                }
                str = str + "\r\n";
                //str = str + "--------------------------------------------------" + "\r\n";
                return str;
            }
            ///////////////////////////////////////////////////////////
        }
        public CBinaryTree()
        {
            treeroot = null;
        }
        CBinaryTreenode<char> treeroot;
        public void CreateBinTreestr(string bintreestr)//根据字符串生成二叉树表
        {
            if (treeroot != null)
                treeroot = null;
            string strt = "1234567890+-*/";
            char ch, chlr = ' ';
            CLinkStack<CBinaryTreenode<char>> mystack = new CLinkStack<CBinaryTreenode<char>>();
            CBinaryTreenode<char> stp, stpnew;//存放栈顶的返回值
            stpnew = null;
            int n = bintreestr.Length;
            for (int i = 0; i < n; i++)
            {
                ch = bintreestr[i];
                if (((ch >= 'A') && (ch <= 'Z')) || ((ch >= 'a') && (ch <= 'z')) || (strt.IndexOf(ch) >= 0))
                {
                    //取栈顶
                    stp = mystack.Gettop();
                    //创建节点并于栈顶链接
                    stpnew = new CBinaryTreenode<char>(ch);
                    if (stp == null)
                        treeroot = stpnew;
                    else
                    {
                        if (chlr == 'l')
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
                    mystack.Pop();//出栈
            }
        }
        /*public void Traversal(int k,out string m_strout)
        {
        }*/
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
        public void StoBT(string t1, string t2)
        {
            return;
        }
        public void Traversal(int k, out string m_strout)
        {
            m_strout = "";
            CLinkStack<CBinaryTreenode<char>> stree = new CLinkStack<CBinaryTreenode<char>>();
            CBinaryTreenode<char> p
;
            CLinkStack<int> sno = new CLinkStack<int>();//栈顶次数
            int no;
            if (treeroot != null)
            {
                stree.Push(treeroot); sno.Push(1);
            }
            else
            {
                m_strout = "空树！\r\n";
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
                    stree.Push(p.rchild);
                    sno.Push(1);
                    if (k == 2)
                    {
                        m_strout += " " + p.data.ToString();
                    }
                }
                else if (no == 3)
                {
                    stree.Pop();
                    if (k == 3)
                        m_strout += " " + p.data.ToString();
                }
            }
        }
        public void cengci(out string m_strout)
        {
            m_strout = "";
            CQueue<CBinaryTreenode<char>> stree = new CQueue<CBinaryTreenode<char>>();
            CBinaryTreenode<char> p;
            if (treeroot != null)
            {
                stree.In(treeroot);
            }
            else
            {
                m_strout = "空树！\r\n";
                return;
            }
            while (!stree.IsEmpty())
            {
                p = stree.Getfront();
                if (p.lchild != null)
                    stree.In(p.lchild);
                if (p.rchild != null)
                    stree.In(p.rchild);
                m_strout += " " + p.data.ToString();
                stree.Out();
            }
        }

    }
    public class CQueue<Type>
    {
        private int front, rear;
        private Type[] elems;
        private const int Maxsize = 1000;
        //--------------------------------------------------------------------------------
        public void MakeEmpty() { front = rear = 0; }//清空
        public bool IsEmpty() { return front == rear; }//判队空
        public bool IsFull() { return (rear + 1) % Maxsize == front; }//判队满
        public int Front() { return front; }
        public int Rear() { return rear; }
        ///////////////////////////////////////////////////////////
        public CQueue()
        {
            elems = new Type[Maxsize];
            front = rear = 0;
        }
        ///////////////////////////////////////////////////////////
        public bool In(Type item)//入队
        {
            if (!IsFull())
            {
                rear = (rear + 1) % Maxsize;
                elems[rear] = item;
                return (true);
            }
            else
                return (false);
        }
        ///////////////////////////////////////////////////////////
        public Type Out()//出队
        {
            front = (front + 1) % Maxsize;
            return elems[front];
        }
        ///////////////////////////////////////////////////////////
        public Type Getfront()
        {
            return elems[(front + 1) % Maxsize];
        }
        ///////////////////////////////////////////////////////////
        public Type Getdata(int k)
        {
            return elems[k];
        }
        ///////////////////////////////////////////////////////////
    }
    //二叉查找树的节点定义
   
    public class Node
    {
        //节点本身的数据
        public int data;
        //左孩子
        public Node left;
        //右孩子
        public Node right;
        public void DisplayData()
        {
            Console.Write(data + " ");
        }
    }


    public class BinarySearchTree
    {
        public Node rootNode = null;
        public int[] a;
        public void Insert(int data)
        {
            Node Parent;
            //将所需插入的数据包装进节点
            Node newNode = new Node();
            newNode.data = data;

            //如果为空树，则插入根节点
            if (rootNode == null)
            {
                rootNode = newNode;
            }
            //否则找到合适叶子节点位置插入
            else
            {
                Node Current = rootNode;
                while (true)
                {
                    Parent = Current;
                    if (newNode.data < Current.data)
                    {
                        Current = Current.left;
                        if (Current == null)
                        {
                            Parent.left = newNode;
                            //插入叶子后跳出循环
                            break;
                        }
                    }
                    else
                    {
                        Current = Current.right;
                        if (Current == null)
                        {
                            Parent.right = newNode;
                            //插入叶子后跳出循环
                            break;
                        }
                    }
                }
            }
        }

        //cengci 
        public int[] CengCi_Tree(Node tree, int n)
        {
            int[] a = new int[n + 10];
            int k = 0;
            if (tree == null)
                return a;

            CQueue<Node> queue = new CQueue<Node>();
            queue.In(tree);

            while (!queue.IsEmpty())
            {
                var item = queue.Out();
                //item.DisplayData();
                a[k++] = item.data;
                if (item.left == null && item.right == null)
                {
                    continue;
                }
                // Console.Write(item.val + " ");
                if (item.left != null)
                {
                    queue.In(item.left);
                }
                /* else
                 {
                      Node newNode = new Node();
                      newNode.data = -1;
                      queue.In(newNode);
                 }*/

                if (item.right != null)
                {
                    queue.In(item.right);
                }
                /*else
                {
                     Node newNode = new Node();
                     newNode.data = -1;
                     queue.In(newNode);
                }*/
            }

            return a;

        }


       // private void cengci(TreeNode n)
        //{
         //   TreeNode no = new TreeNode();
        //    CQueue<TreeNode> cqtree = new CQueue<TreeNode>();
       //     cqtree.In(n);
       //     while (!cqtree.IsEmpty())
       //     {
        ///        no = cqtree.Out();
        //        if (no.FirstNode != null && no.FirstNode.Text == "" && no.LastNode.Text == "")
        //        { no.Nodes.Remove(no.LastNode); no.Nodes.Remove(no.FirstNode); }
          //      if (no.FirstNode != null)
         ///       {
         //           no = no.FirstNode;
       ///             while (no != null)
           //         {
         //               cqtree.In(no);
         //               no = no.NextNode;
        //            }
        //        }
         //   }
    //    }


        /*
        //中序
        public void InOrder(Node theRoot)
        {
             if (theRoot != null)
             {
                  InOrder(theRoot.left);
                  theRoot.DisplayData();
                  InOrder(theRoot.right);
             }
        }
        //先序
        public void PreOrder(Node theRoot)
        {
             if (theRoot != null)
             {
                  theRoot.DisplayData();
                  PreOrder(theRoot.left);
                  PreOrder(theRoot.right);
             }
        }
        //后序
        public void PostOrder(Node theRoot)
        {
             if (theRoot != null)
             {
                  PostOrder(theRoot.left);
                  PostOrder(theRoot.right);
                  theRoot.DisplayData();
             }
        }
        */
        //查找
        public Node Search(int i)
        {
            Node current = rootNode;
            while (true)
            {
                if (i < current.data)
                {
                    if (current.left == null)
                        break;
                    current = current.left;
                }
                else if (i > current.data)
                {
                    if (current == null)
                        break;
                    current = current.right;
                }
                else
                {
                    return current;
                }
            }
            if (current.data != i)
            {
                return null;
            }

            return current;
        }
        //删除二叉查找树中的节点
        public Node Delete(int key)
        {
            Node parent = rootNode;
            Node current = rootNode;
            //首先找到需要被删除的节点&其父节点
            while (true)
            {
                if (key < current.data)
                {
                    if (current.left == null)
                        break;
                    parent = current;
                    current = current.left;
                }
                else if (key > current.data)
                {
                    if (current == null)
                        break;
                    parent = current;
                    current = current.right;
                }
                //找到被删除节点，跳出循环
                else
                {
                    break;
                }
            }
            //找到被删除节点后，分四种情况进行处理
            //情况一，所删节点是叶子节点时，直接删除即可
            if (current.left == null && current.right == null)
            {
                //如果被删节点是根节点，且没有左右孩子
                if (current == rootNode && rootNode.left == null && rootNode.right == null)
                {
                    rootNode = null;
                }
                else if (current.data < parent.data)
                    parent.left = null;
                else
                    parent.right = null;
            }
            //情况二，所删节点只有左孩子节点时
            else if (current.left != null && current.right == null)
            {
                if (current.data < parent.data)
                    parent.left = current.left;
                else
                    parent.right = current.left;


            }
            //情况三，所删节点只有右孩子节点时
            else if (current.left == null && current.right != null)
            {
                if (current.data < parent.data)
                    parent.left = current.right;
                else
                    parent.right = current.right;


            }
            //情况四，所删节点有左右两个孩子
            else
            {
                //current是被删的节点，temp是被删左子树最右边的节点
                Node temp;
                //先判断是父节点的左孩子还是右孩子
                if (current.data < parent.data)
                {

                    parent.left = current.left;
                    temp = current.left;
                    //寻找被删除节点最深的右孩子
                    while (temp.right != null)
                    {
                        temp = temp.right;
                    }
                    temp.right = current.right;


                }
                //右孩子
                else if (current.data > parent.data)
                {
                    parent.right = current.left;
                    temp = current.left;
                    //寻找被删除节点最深的左孩子
                    while (temp.left != null)
                    {
                        temp = temp.left;
                    }
                    temp.right = current.right;
                }
                //当被删节点是根节点，并且有两个孩子时
                else
                {
                    temp = current.left;
                    while (temp.right != null)
                    {
                        temp = temp.right;
                    }
                    temp.right = rootNode.right;
                    rootNode = current.left;
                }

            }
            return current;

        }
        //找到最大节点
        public void FindMax()
        {
            Node current = rootNode;
            //找到最右边的节点即可
            while (current.right != null)
            {
                current = current.right;
            }
            Console.WriteLine("\n最大节点为:" + current.data);

        }
        //找到最小节点
        public void FindMin()
        {
            Node current = rootNode;
            //找到最左边的节点即可
            while (current.left != null)
            {
                current = current.left;
            }
            Console.WriteLine("\n最小节点为:" + current.data);
        }
    }
}
