using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{

    class CSeqList<Type>
    {
        private Type[] data;//顺序表数据
        private int MaxSize;//空间
        private int datasize;//元素个数

        public CSeqList(int MaxSize)//构造函数
        {
            this.MaxSize = MaxSize;
            data = new Type[MaxSize];
            datasize = 0;
        }

        public CSeqList(int MaxSize, Type[] data, int n)//初始化重载
        {
            this.MaxSize = MaxSize;
            this.data = new Type[MaxSize];
            for (int i = 0; i < n; i++)
            {
                this.data[i] = data[i];
            }
            datasize = n;
        }
        public bool Insert(int k, Type dt)
        {
            if (k < 1 || k > datasize + 1)
            {
                return false;
            }
            if (datasize == MaxSize)
            {
                return false;
            }
            for (int i = datasize - 1; i >= k - 1; i--)//逆序
            {
                data[i + 1] = data[i];//将前一个数据付再后一个位置上,一直给到k的位置
            }
            data[k - 1] = dt;
            datasize++;
            return true;
        }

        public bool Delete(int k)
        {
            if (k < 1 || k > datasize)
            {
                return false;
            }
            for (int i = k - 1; i < datasize; i++)
            {
                data[i] = data[i + 1];
            }
            datasize--;
            return true;
        }
        public bool Update(int k, Type dt)
        {
            if (k < 1 || k > datasize)
            {
                return false;
            }
            data[k - 1] = dt;
            return true;
        }

        public void MakeEmpty()
        {
            datasize = 0;
        }

        public int DataSize
        {
            get
            {
                return datasize;
            }
        }

        public string MyPrint()
        {
            string strout = "";
            for (int i = 0; i < MaxSize; i++)
            {
                if (i < MaxSize && i < datasize)
                    strout += (i + 1) + "\t[\t" + data[i] + "\t]\n";
                else if (i > datasize)
                    strout += (i + 1) + "\t[\t" + "\t]\n";
            }
            return strout;
        }
    }

}
