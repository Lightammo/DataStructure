using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace guanyibiao
{
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
    }
    
    class CGenListnode//广义表节点类
    {
        public int utype;//广义表节点类型
        public CGenListnode tnext;//指向 广义表地结点
        public object hnext;//指向数据或者子表头结点的通用引用
        public CGenListnode(int u)//构造函数
        {
            utype = u;tnext = null;hnext = null;
        }
        public CGenListnode(int u, CGenListnode tn,object hn)
        {
            utype = u; tnext = tn; hnext = hn;
        }
    }
}
