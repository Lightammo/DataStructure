﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paixu
{
    public partial class Form1 : Form
    {
        Array_sort my_sort;
        int n;
        int[] data;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn()); //两列
            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView2.Columns[0].HeaderCell.Value = "比较次数";
            dataGridView2.Columns[0].Width = 80;
            dataGridView2.Columns[1].HeaderCell.Value = "移动次数";
            dataGridView2.Columns[1].Width = 80;
            dataGridView2.Rows.Add(new DataGridViewRow());
            dataGridView2.Rows[0].HeaderCell.Value = "插入排序";
            dataGridView2.Rows.Add(new DataGridViewRow());
            dataGridView2.Rows[1].HeaderCell.Value = "二分排序";
            dataGridView2.Rows.Add(new DataGridViewRow());
            dataGridView2.Rows[2].HeaderCell.Value = "希尔排序";
            dataGridView2.Rows.Add(new DataGridViewRow());
            dataGridView2.Rows[3].HeaderCell.Value = "起泡排序";
            dataGridView2.Rows.Add(new DataGridViewRow());
            dataGridView2.Rows[4].HeaderCell.Value = "快速排序";
            dataGridView2.Rows.Add(new DataGridViewRow());
            dataGridView2.Rows[5].HeaderCell.Value = "选择排序";
            dataGridView2.Rows.Add(new DataGridViewRow());
            dataGridView2.Rows[6].HeaderCell.Value = "堆排序";
            dataGridView2.RowHeadersWidth = 90;
            dataGridView2.Rows[0].Height = 20;
            dataGridView2.Rows[1].Height = 20;
            dataGridView2.Rows[2].Height = 20;
            dataGridView2.Rows[3].Height = 20;
            dataGridView2.Rows[4].Height = 20;
            dataGridView2.Rows[5].Height = 20;
            dataGridView2.Rows[6].Height = 20;
            //my_sort = new Array_sort(int.Parse(textBox1.Text),, dataGridView1));
            //my_sort.SetTable(dataGridView1, 60);
        }
        public int[] getRandomNum(int num, int minValue, int maxValue)
        {
            Random ra = new Random(unchecked((int)DateTime.Now.Ticks));
            int[] arrNum = new int[num];
            int tmp = 0;
            for (int i = 0; i <= num - 1; i++)
            {
                tmp = ra.Next(minValue, maxValue); //随机取数
                arrNum[i] = getNum(arrNum, tmp, minValue, maxValue, ra); //取出值赋到数组中
            }
            return arrNum;
        }

        public int getNum(int[] arrNum, int tmp, int minValue, int maxValue, Random ra)
        {
            int n = 0;
            while (n <= arrNum.Length - 1)
            {
                if (arrNum[n] == tmp) //利用循环判断是否有重复
                {
                    tmp = ra.Next(minValue, maxValue); //重新随机获取。
                    getNum(arrNum, tmp, minValue, maxValue, ra);//递归:如果取出来的数字和已取得的数字有重复就重新随机获取。
                }
                n++;
            }
            return tmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
                int n = int.Parse(textBox1.Text);
                if (radioButton1.Checked == true)
                {
                    data = new int[n];
                    for (int i = 0; i < n; i++)
                        data[i] = i + 1;
                }
                else if (radioButton2.Checked == true)
                {
                    data = new int[n];
                    for (int i = n; i > 0; i--)
                        data[i] = i;
                }
                else
                {
                    data = getRandomNum(n, 1, n);
                }
                my_sort = new Array_sort(n, data, dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (my_sort.Datanumber != 0)
            {
                int k; //1 升序 ，2 降序
                if (radioButton1.Checked == true)
                    k = 1;
                else
                    k = 2;
                my_sort.Paixu_0(k);
                my_sort.Paixu_1(k);
                my_sort.Paixu_2(k);
                my_sort.Paixu_3(k);
                //my_sort.Paixu_4(k);
                my_sort.Paixu_5(k);
                my_sort.Paixu_6(k);
                if (radioButton3.Checked == true)
                    my_sort.TableShow(dataGridView1, 1);
                else
                    my_sort.TableShow(dataGridView1, 2);
                my_sort.TableShow2(dataGridView2);
                //if (radioButton8.Checked == true)
                //Chart(0);
                //else
                //Chart(1);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            
            
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
