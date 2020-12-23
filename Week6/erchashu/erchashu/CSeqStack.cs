using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace erchashu
{
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
}
