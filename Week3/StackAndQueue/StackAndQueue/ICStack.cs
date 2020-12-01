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
}
