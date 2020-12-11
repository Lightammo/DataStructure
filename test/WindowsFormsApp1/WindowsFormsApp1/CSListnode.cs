using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class CSListnode<Type>//单链表结点类
    {
        private Type data; //定义单链表数据
        private CSListnode<Type> next; //next为指向下一节点的指针
        //
        public Type Data
        {
            //
            //
            //
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
            //get用来获取字段的值，set用来设置字段的值
        }
        public CSListnode<Type> Next
        {
            get
            {
                return next;
            }
            set
            {
                next = value;
            }
        }
        public CSListnode()
        {
            // data = 0;
            next = null;
        }                  //空的链表
        //重载构造函数
        public CSListnode(Type data)
        {
            this.data = data;
            next = null;
        }                  //存有数据、无next指针的单链表
        public CSListnode(Type data, CSListnode<Type> next)
        {
            this.data = data;
            this.next = next;
        }                  //既有数据、又有next指针的单链表
    }
}
