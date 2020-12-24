using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erchashu
{

    public class CBinaryTreenode<Type>//二叉树的结点类
    {
        public Type data;
        public CBinaryTreenode<Type> lchild, rchild;
        public CBinaryTreenode()
        { lchild = rchild = null; }
        public CBinaryTreenode (Type item)
        { data = item;lchild = rchild = null; }
        public CBinaryTreenode (Type item,CBinaryTreenode<Type>lc,CBinaryTreenode<Type>rc)
        {
            data = item;
            lchild = lc;rchild = rc;
        }
    }
    class CBinaryTree
    {

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
            for (int i=0;i<n;i++)
            {
                ch = bintreestr[i];
                if(((ch>='A')&&(ch<='Z'))||((ch>='a')&&(ch<='z'))||(strt.IndexOf(ch)>=0))
                {
                    stp = mystack.Gettop();//取栈顶
                    //创建节点并于栈顶链接
                    stpnew = new CBinaryTreenode<char>(ch);
                    if (stp == null)
                        treeroot = stpnew;
                    else
                    {
                        if (chlr == 'I') ;
                    }
                }
            }

        }
    }
    
}
