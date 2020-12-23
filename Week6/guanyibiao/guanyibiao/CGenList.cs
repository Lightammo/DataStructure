using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace guanyibiao
{
    class CGenListnode//广义表节点类
    {
        public int utype;//广义表节点类型
        public CGenListnode tnext;//指向广义表的结点
        public object hnext;//指向数据或者子表头结点的通用引用
        public CGenListnode(int u)//构造函数
        {
            utype = u; tnext = null; hnext = null;
        }
        public CGenListnode(int u, CGenListnode tn, object hn)
        {
            utype = u; tnext = tn; hnext = hn;
        }
    }
    class CGenList//广义表
    {
        const int HEAD = 0;
        const int INT = 1;
        const int DOUBLE = 2;
        const int CHAR = 3;
        const int STRING = 4;
        const int RATIONAL = 5;
        const int CHILD = 10;
        private CGenListnode head;//广义表地头节点
        public CGenList()
        {
            head = new CGenListnode(HEAD);
        }
        public CGenListnode Head
        {
            get { return head; }
            set { head = value; }
        }
        public void MakeEmpty(out String strout)
        {
            if (head.tnext == null)
            {
                strout = "广义表为空表!";
                return;
            }
            else
            {
                strout = "广义表清空!";
                head.tnext = null;
            }
        }
        public void CreateGL(string strin, out string strout)
        {
            if (head.tnext != null)
                MakeEmpty(out strout);
            string tstr;
            strout = "输入字符串=";
            tstr = strin;
            strout += tstr + "\r\n";
            strout = "广义表的创建\r\n";
            CLinkStack<CGenListnode> stp = new CLinkStack<CGenListnode>();
            stp.Push(head);//初态时head结点入栈
            strout += "Create 【BEGIN】";
            strout += "\r\n";
            char ch;
            string temp, temp1;
            CGenListnode cp;//存放栈顶的返回值
            int i = 1, j, k;//从输入串第一个"("的后面开始
            int ti, tnum, tden;
            double tf;
            ch = strin[0];
            int n = strin.Length;
            while (i < n)
            {
                ch = strin[i++];
                if (ch == '(')//'('后应生成子表的标志结点
                {
                    cp = stp.Gettop();
                    cp.tnext = new CGenListnode(CHILD);
                    strout += "Create 【CHILD】\r\n";
                    //将子表的标志结点接在栈顶的tnext域
                    stp.Push(cp.tnext);//子表的标志结点成为新的栈顶
                    cp.tnext.hnext = new CGenListnode(HEAD);
                    //生成子表的head结点
                    stp.Push((CGenListnode)cp.tnext.hnext);
                    //子表的head结点入栈
                    strout += "Create 【HEAD】\r\n";
                    continue;
                }
                string strt = "0123456789./";
                if (strt.IndexOf(ch) >= 0)//输入的是int,double,rational
                {
                    j = 0; temp = ""; temp += ch; ch = strin[i++];
                    while (strt.IndexOf(ch) >= 0)//输入的还是数字
                    { temp += ch; ch = strin[i++]; }
                    if (temp.IndexOf('/') >= 0)//输入的是rational数
                    {
                        j = 0; 
                        temp1 = "";
                        while (temp[j] != '/')
                            temp1 += temp[j++];
                        tnum = Convert.ToInt16(temp1);
                        j++;
                        temp1 = "";
                        while (j < temp.Length)
                            temp1 += temp[j++];
                        tden = Convert.ToInt16(temp1);
                        cp = stp.Gettop();
                        cp.tnext = new CGenListnode(RATIONAL);
                        //将rational结点接在栈顶的tnext域
                        cp.tnext.hnext = new Rational(tnum, tden);
                        strout += "Create 【RATIONAL】--";
                        Rational r = (Rational)cp.tnext.hnext;//补的代码
                        tstr = "(" + r.output() + ")\r\n";//修改
                        strout += tstr;
                        stp.Push(cp.tnext);//将rational结点成为新的栈顶
                        i--;//符号串下标回退一格
                    }
                    else if (temp.IndexOf('.') >= 0)//输入的是double数
                    {
                        tf = Convert.ToDouble(temp);
                        cp = stp.Gettop();
                        cp.tnext = new CGenListnode(DOUBLE);
                        cp.tnext.hnext = tf;
                        strout += "Create 【DOUBLE】--";
                        tstr = "(" + tf + ")\r\n";
                        strout += tstr;
                        stp.Push(cp.tnext);//将double结点成为新的栈顶
                        i--;//符号串下标回退一格
                    }
                    else //输入的是int数
                    {
                        ti = Convert.ToInt16(temp);
                        cp = stp.Gettop();
                        cp.tnext = new CGenListnode(INT);
                        cp.tnext.hnext = ti;
                        strout += "Create 【INT】--";
                        tstr = "(" + ti + ")\r\n";
                        strout += tstr;
                        stp.Push(cp.tnext);//将int结点成为新的栈顶
                        i--;//符号串下标回退一格
                    }
                    continue;
                }
                if (ch == '\'')//输入的字符
                {
                    cp = stp.Gettop();
                    cp.tnext = new CGenListnode(CHAR);
                    ch = strin[i++]; cp.tnext.hnext = ch;
                    strout += "Create 【CHAR】--";
                    tstr = "(\'" + ch + "\')\r\n";
                    strout += tstr;
                    stp.Push(cp.tnext);//将char结点成为新的栈顶
                    ch = strin[i++];
                    continue;
                }
                if (ch == '\"')//输入的字符串
                {
                    cp = stp.Gettop(); j = 0; ch = strin[i++];
                    temp = "";
                    while (ch != '\"')
                    { temp += ch; ch = strin[i++]; }
                    cp.tnext = new CGenListnode(STRING);
                    cp.tnext.hnext = temp;
                    strout += "Create 【STRING】--";
                    tstr = "(\"" + temp + "\")\r\n";
                    strout += tstr;
                    stp.Push(cp.tnext);//将string结点成为新的栈顶
                    continue;
                }
                if (ch == ',')//输入的是','
                { continue; }
                if (ch == ')')//输入的是')'
                {
                    do
                    {
                        cp = stp.Gettop();
                        if (cp.utype != HEAD)
                            stp.Pop();
                    } while (cp.utype != HEAD);//将head指向的结点出栈.
                    stp.Pop();//将head结点出栈.

                    continue;
                }
            }
            strout += "广义表创建完毕----------------------------------\r\n";
        }
    }
}  
