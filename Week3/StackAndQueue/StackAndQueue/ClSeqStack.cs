using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackAndQueue
{
    public interface ICStack<Type>//接口
    {
        bool IsEmpty();//判断空
        bool IsFull();//判断栈满
        void MakeEmpty();//清空
        bool Push(Type item);//入栈
        Type Pop();//出栈
        Type Gettop();//取栈顶
        String GetStackALLData(string sname);//输出栈中全部元素
    }
    class ClSeqStack
    {
        public class CSeqStack<Type> : ICStack<Type>
        {
            private int top;
            private Type[] elems;
            private int Maxsize = 100;
            public Type this[int index]
            {
                get { return elems[index]; }
                set { elems[index] = value; }
            }
            //对top进行属性封装
            public int Top
            {
                get { return top; }
            }
        }
        public class CSeStack<Type>:ICStack<Type>
        {

        }
    }
}
//get return top 
// top=-1;判断栈空
// return top==-1; //判断栈满 
// return top==MaxSize-1;
