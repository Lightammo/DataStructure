using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class CQueue
    {
        private int front, rear;   //定义队头和队尾
        private Type[] elems;      //队列元素
        private const int Maxsize = 1000;   //队列最大长度
        public CQueue()
        {
            elems = new Type[Maxsize];
            front = rear = 0;
        }
        public bool In(Type item)//入队
        {
            if (!IsFull())
            {
                rear = (rear + 1) % Maxsize;
                elems[rear] = item;
                return (true);
            }
            else
                return (false);
        }

        public Type Out()//出队
        {
            front = (front + 1) % Maxsize;
            return elems[front];
        }

        public Type Getfront()//取队头元素值
        {
            return elems[(front + 1) % Maxsize];
        }

        public Type Getdata(int k)//取元素值
        {
            return elems[k];
        }
        public void MakeEmpty() { front = rear = 0; }//清空
        public bool IsEmpty() { return front == rear; }//判断队空
        public bool IsFull() { return (rear + 1) % Maxsize == front; }//判断队满
        public int Front() { return front; } //队头位置
        public int Rear() { return rear; } //队尾位置
    }
}
