using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class CSList<Type>
    {
        private CSListnode<Type> head;
        private CSListnode<Type> current; //指向当前节点的指针（结点类的类型）

        public CSList()
        {
            head = new CSListnode<Type>();
            current = head;
        }
        public CSListnode<Type> Current   //返回私有成员——当前指针
        {
            get
            {
                return current;
            }
            set
            {
                current = value;
            }
        }
        public CSListnode<Type> Rear      //定义尾结点指针函数
        {
            get
            {
                CSListnode<Type> p = head;
                while (p.Next != null)
                    p = p.Next;
                return p;
            }
        }
        public CSListnode<Type> Next
        {
            get
            {
                return current.Next;
            }
        }

        public CSListnode<Type> Head
        {
            get
            {
                return head;
            }
        }
        public Type CurrentData
        {
            get
            {
                return current.Data;
            }
            set
            {
                current.Data = value;
            }
        }
        public void InsertHead(Type value)//头插法生成
        {
            head.Next = new CSListnode<Type>(value, head.Next);
            current = head.Next;
        }
        public void AppendRear(Type value)//尾插法生成
        {
            current = new CSListnode<Type>(value, null);
            Rear.Next = current;
        }
        public void Create(Type[] dt, int n)//生成n个结点
        {
            MakeEmpty();

            for (int i = 1; i <= n; i++)
                Insert(dt[i - 1], 1);
            current = head;
        }
        public void CreateHead(Type[] dt, int n)//头插法生成n个结点
        {
            MakeEmpty();
            for (int i = 1; i <= n; i++)
                head.Next = new CSListnode<Type>(dt[i - 1], head.Next);
            current = head.Next;
        }
        public void CreateRear(Type[] dt, int n)//尾插法生成n个结点
        {
            MakeEmpty();
            for (int i = 1; i <= n; i++)
            {
                current.Next = new CSListnode<Type>(dt[i - 1], null);
                current = current.Next;
            }
        }
        public Type FirstNode() //设置头结点为当前结点
        {
            current = head;
            return current.Data;
        }
        public Type NextNode() //设置下一结点为当前结点
        {
            if (current.Next != null)//若当前结点存在，则将其后继设置为当前结点
                current = current.Next;
            return current.Data;
        }

        public CSListnode<Type> Find(Type value)//按给定值查找单链表
        {
            CSListnode<Type> p = current.Next;//定义节点类成员p，作为当前结点
            while (p != null)
            {
                if (p.Data.Equals(value))
                {
                    current = p;
                    break;
                }
                p = p.Next;
            }
            if (p == null)//如果p指向null,则返回头结点
                current = head;
            return current;
        }
        public CSListnode<Type> Getnode(int i) //返回第i个结点的地址
        {
            if (i < 0) return null;
            if (i == 0) return head;
            CSListnode<Type> p = head;
            for (int j = 1; p != null && j <= i; j++)
                p = p.Next;
            return p;
        }
        public void Insert(Type value, int i)//在第i个结点处插入结点
        {
            if (i < 1) i = 1;
            if (i > this.Length + 1)
                i = this.Length + 1;
            CSListnode<Type> p = Getnode(i - 1);
            CSListnode<Type> newnode = new CSListnode<Type>(value, p.Next);
            p.Next = newnode;
        }
        public void Insert(Type value, bool before)//在当前结点处插入结点（重点）
        //befroe为ture,前插；before为false，后插
        {
            if (current == head)  //如果当前节点为头节点，只能选择后插
                before = false;
            if (before)
            {
                CSListnode<Type> p = head;
                while (p.Next != current)
                    p = p.Next;
                p.Next = new CSListnode<Type>(value, p.Next);
                current = current.Next;
            }
            else
            {
                current.Next = new CSListnode<Type>(value, current.Next);
                current = current.Next;
            }
        }
        public void Delete(int i) //在第i个结点处删除结点
        {
            CSListnode<Type> p = Getnode(i - 1), q;
            q = p.Next;
            p.Next = q.Next;
        }

        public void Remove(Type value) //删除给定值的结点
        {
            CSListnode<Type> p = head, q = p.Next;
            while (q != null && !q.Data.Equals(value))
            {
                p = p.Next;
                q = p.Next;
            }
            if (q != null)
            {
                p.Next = q.Next;
            }
        }
        public void DeleteLast()//删除最后一个节点
        {
            CSListnode<Type> p = head;
            CSListnode<Type> q = p.Next;
            while (q != null)
            {
                if (q.Next != null)
                    p = q;
                else
                    p.Next = null;
                q = q.Next;
            }
        }
        public void DeleteCurrent()//1删除当前节点
        {
            CSListnode<Type> p = head;
            while (p.Next != current)
                p = p.Next;
            p.Next = current.Next;
            current = p.Next;

        }
        public void MakeEmpty()//清空单链表
        {
            head.Next = null;
            current = head;
        }

        public int Length //单链表长度
        {
            get
            {
                CSListnode<Type> p = head.Next;
                int count = 0;
                while (p != null)
                {
                    p = p.Next;
                    count++;
                }
                return count;
            }
        }
        public void Inverse()//倒置单链表
        {
            Type a = current.Data;
            int l = Length;
            current = head;
            for (int i = 1; i <= l; i++)
            {
                Insert(Rear.Data, i);
                DeleteLast();
            }
            Find(a);
        }
    }
}
