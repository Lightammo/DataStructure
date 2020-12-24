using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void SetTable(DataGridView dataGridView, int n) //建立表格n个数据的表格
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
        public void TableShow(DataGridView dataGridView, int m) //1显示原始数据，2显示排好的数据
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
        public void TableShow2(DataGridView dataGridView) //排序统计数据显示（比较次数、移动次数）
        {
            for (int i = 0; i < 7; i++)
            {
                dataGridView[0, i].Value = sortmethods[i].compare;
                dataGridView[1, i].Value = sortmethods[i].move;
            }
        }

    }
