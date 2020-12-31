using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paixu
{
    class Array_sort
    {
        private int[] original, sortpast; //原始数据,处理之后数据
        private int datanumber; //数据容量
        public struct sortmethod
        {
            public int compare; //比较次数
            public int move; //移动次数
        }
        public int Datanumber
        {
            get
            {
                return datanumber;
            }
        }
        public sortmethod[] sortmethods = new sortmethod[7];
        //0 插入排序，1 二分排序，2 希尔排序，3 起泡排序，4 快速排序，5 选择排序，6 堆排序
        public Array_sort(int n, int[] data, DataGridView dataGridView)
        {
            datanumber = n; //数据总数
            original = new int[n];
            sortpast = new int[n];
            for (int i = 0; i < n; i++)
                original[i] = data[i];
            SetTable(dataGridView, n); //创建表格，赋值
            TableShow(dataGridView, 1);
            for (int i = 0; i < 7; i++) //移动次数，比较次数赋值0
            {
                sortmethods[i].compare = 0;
                sortmethods[i].move = 0;
            }
        }

        public void SetTable(DataGridView dataGridView, int n) //建立表格n个数据
        {
            int line; //行数
            if (n / 10.0 > n / 10)
                line = n / 10 + 1;
            else
                line = n / 10;
            dataGridView.Rows.Clear(); //清除原始行和列
            dataGridView.Columns.Clear();
            for (int i = 0; i < 10; i++) //建立十列
            {
                dataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                dataGridView.Columns[i].HeaderCell.Value = "第" + (i + 1) + "列";
                dataGridView.Columns[i].Width = 65;
            }
            for (int i = 0; i < line; i++) //建立line行
            {
                dataGridView.Rows.Add(new DataGridViewRow());
                dataGridView.Rows[i].HeaderCell.Value = "第" + (i + 1) + "行";
                dataGridView.Rows[i].Height = 20;
            }
            dataGridView.RowHeadersWidth = 100; //设置行表头宽度
        }
        public void TableShow(DataGridView dataGridView, int m) //1显示原始数据，2显示排好
        {
            if (m == 1)
            {
                for (int i = 0; i < datanumber; i++)
                    dataGridView[i - 10 * (i / 10), i / 10].Value = original[i];
                dataGridView.TopLeftHeaderCell.Value = "原始数据";
            }
            else
            {
                for (int i = 0; i < datanumber; i++)
                    dataGridView[i - 10 * (i / 10), i / 10].Value = sortpast[i];
                dataGridView.TopLeftHeaderCell.Value = "排序结果";
            }
        }
        public void TableShow2(DataGridView dataGridView) //排序统计数据显示（比较次数、移动
        {
            for (int i = 0; i < 6; i++)
            {
                dataGridView[0, i].Value = sortmethods[i].compare;
                dataGridView[1, i].Value = sortmethods[i].move;
            }
        }




        //直接插入法
        public void Paixu_0(int k) //插入排序
                                   //k=1为升序，k=2为降序
        {
            sortmethods[0].compare = 0; //比较次数初值为0
            sortmethods[0].move = 0; //移动次数初值为0
            int[] data = new int[datanumber];
            int i, j, temp;
            for (i = 0; i < datanumber; i++) //传递数据
                data[i] = original[i];
            for (i = 0; i < datanumber; i++)
            {
                temp = data[i];
                sortmethods[0].move++;
                j = i - 1;
                if (k == 1) //升序
                {
                    while (j >= 0 && temp < data[j])
                    {
                        data[j + 1] = data[j--];
                        sortmethods[0].compare++;
                        sortmethods[0].move++;
                    }
                    if (j >= 0)
                        sortmethods[0].compare++;
                }
                else //降序
                {
                    while (j >= 0 && temp > data[j])
                    {
                        data[j + 1] = data[j--];
                        sortmethods[0].compare++;
                        sortmethods[0].move++;
                    }
                    if (j >= 0)
                        sortmethods[0].compare++;
                }
                data[j + 1] = temp;
                sortmethods[0].move++;
            }
            for (i = 0; i < datanumber; i++)
                sortpast[i] = data[i];
        }

        //二分排序法
        public void Paixu_1(int k)
        //k=1为升序，k=2为降序
        {
            sortmethods[1].compare = 0;
            sortmethods[1].move = 0;
            int[] data = new int[datanumber];
            int i, j, temp;
            for (i = 0; i < datanumber; i++) //传递数据
                data[i] = original[i];
            for (i = 0; i < datanumber; i++)
            {
                temp = data[i];//待插入到前面有序序列的值
                sortmethods[1].move++;
                int left = 0;//有序序列的左侧
                int right = i - 1;//有序序列的右侧
                int middle = 0;//有序序列的中间
                while (left <= right)
                {
                    middle = (left + right) / 2;//赋值
                    if (k == 1)
                    {
                        sortmethods[1].compare++;
                        if (temp < data[middle])
                        {
                            right = middle - 1;
                        }
                        else
                        {
                            left = middle + 1;
                        }
                    }
                    else
                    {
                        sortmethods[1].compare++;
                        if (temp > data[middle])
                        {
                            right = middle - 1;
                        }
                        else
                        {
                            left = middle + 1;
                        }
                    }
                }
                for (j = i - 1; j >= left; j--)
                { //从i-1到left依次向后移动一位,等待temp值插入
                    data[j + 1] = data[j];
                    sortmethods[1].move++;
                }
                if (left != i)
                {
                    data[left] = temp;
                    sortmethods[1].move++;
                }
            }
            for (i = 0; i < datanumber; i++)
                sortpast[i] = data[i];
        }

        //希尔排序
        public void Paixu_2(int k)
        {
            sortmethods[2].compare = 0;
            sortmethods[2].move = 0;
            int[] data = new int[datanumber];
            int i, j, temp, h;
            for (i = 0; i < datanumber; i++) //传递数据
                data[i] = original[i];
            h = datanumber / 2;
            if (h == 0)
                h = 1;
            do
            {
                for (i = 0; i < datanumber; i++)
                {
                    temp = data[i];
                    sortmethods[2].move++;
                    j = i - h;
                    if (k == 1)
                    {
                        while (j >= 0 && temp < data[j])
                        {
                            data[j + h] = data[j];
                            j = j - h;
                            sortmethods[2].compare++;
                            sortmethods[2].move++;
                        }
                        if (j >= 0)
                            sortmethods[2].compare++;
                    }
                    else
                    {
                        while (j >= 0 && temp > data[j])
                        {
                            data[j + h] = data[j];
                            j = j - h;
                            sortmethods[2].compare++;
                            sortmethods[2].move++;
                        }
                        if (j >= 0)
                            sortmethods[2].compare++;
                    }
                    data[j + h] = temp;
                    sortmethods[2].move++;
                }
                h = h / 2;
            } while (h != 0);
            for (i = 0; i < datanumber; i++)
                sortpast[i] = data[i];
        }

        //冒泡排序
        public void Paixu_3(int k)
        {
            sortmethods[3].compare = 0;
            sortmethods[3].move = 0;
            int[] data = new int[datanumber];
            int i, j, temp, noswap;
            for (i = 0; i < datanumber; i++) //传递数据
                data[i] = original[i];
            for (i = 0; i <= datanumber - 2; i++)
            {
                noswap = 1;
                for (j = datanumber - 1; j > i; j--)
                {
                    if (k == 1) //升序
                    {
                        if (data[j - 1] > data[j])
                        {
                            temp = data[j - 1];
                            data[j - 1] = data[j];
                            data[j] = temp;
                            noswap = 0;
                            sortmethods[3].compare++;
                            sortmethods[3].move = sortmethods[3].move + 3;
                        }
                        sortmethods[3].compare++;
                    }
                    else //降序
                    {
                        if (data[j - 1] < data[j])
                        {
                            temp = data[j - 1];
                            data[j - 1] = data[j];
                            data[j] = temp;
                            noswap = 0;
                            sortmethods[3].compare++;
                            sortmethods[3].move = sortmethods[3].move + 3;
                        }
                        sortmethods[3].compare++;
                    }
                }
                if (noswap == 1) break;
            }
            for (i = 0; i < datanumber; i++)
                sortpast[i] = data[i];
        }

        //快速排序
       



        //选择排序
        public void Paixu_5(int k)
        {
            sortmethods[5].compare = 0;
            sortmethods[5].move = 0;
            int[] data = new int[datanumber];
            int i, j, m, temp;
            for (i = 0; i < datanumber; i++) //传递数据
                data[i] = original[i];
            for (i = 0; i < datanumber - 1; i++)
            {
                m = i; //记录位置在哪
                for (j = i + 1; j < datanumber; j++)
                {
                    if (k == 1) //升序
                    {
                        if (data[j] < data[m])
                            m = j;
                        sortmethods[5].compare++;
                    }
                    else//降序
                    {
                        if (data[j] > data[m])
                            m = j;
                        sortmethods[5].compare++;
                    }
                }
            }
            for (i = 0; i < datanumber; i++)
                sortpast[i] = data[i];
        }

        public void Paixu_6(int k)
        {
            sortmethods[6].compare = 0;
            sortmethods[6].move = 0;
            int[] data = new int[datanumber + 1];
            int i, temp;
            for (i = 0; i < datanumber; i++) //传递数据
                data[i + 1] = original[i];
            for (i = datanumber / 2; i >= 1; i--)
                SIFT(data, i, datanumber, k);
            for (i = datanumber; i >= 1; i--)
            {
                temp = data[1];
                data[1] = data[i];
                data[i] = temp;
                sortmethods[6].move = sortmethods[6].move + 3;
                SIFT(data, 1, i - 1, k);
            }
            for (i = 0; i < datanumber; i++)
                sortpast[i] = data[i+1];
        }
        public void SIFT(int[] r, int i, int m, int k)
        {
            int j, temp;
            temp = r[i];
            sortmethods[6].move++;
            j = 2 * i;
            while (j <= m)
            {
                if (k == 1)
                {
                    if ((j < m) && (r[j] < r[j + 1]))
                        j++;
                    if (j < m)
                        sortmethods[6].compare++;
                    sortmethods[6].compare++;
                    if (temp < r[j])
                    {
                        r[i] = r[j];
                        i = j; j = 2 * i;
                        sortmethods[6].move++;
                    }
                    else
                        break;
                }
                else
                {
                   
                }
            }
            r[i] = temp;
            sortmethods[6].move++;
        }
    }
}

