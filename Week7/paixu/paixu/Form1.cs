using System;
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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn());      //两列
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
            //my_sort = new Array_sort();
            //my_sort.SetTable(dataGridView1,60);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
