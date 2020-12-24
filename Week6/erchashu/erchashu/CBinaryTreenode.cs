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
   
 }
