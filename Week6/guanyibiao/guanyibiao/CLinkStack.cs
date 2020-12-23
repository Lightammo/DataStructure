﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace guanyibiao
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
        public bool Push(Type item)//⼊栈
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
            string str = " 】";
            if (IsEmpty()) str = sname + " stack is null";
            CStacknode<Type> p = top;
            while (p != null)
            {
                str = p.Data + " " + str;
                p = p.Next;
            }
            str = "【 " + str + "\r\n";
            str = str + "---------------------------------------" + "\r\n";
            return str;
        }
    }
}
