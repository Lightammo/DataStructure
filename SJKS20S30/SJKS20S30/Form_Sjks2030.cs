using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SJKS20S30
{
    public partial class Form_Sjks2030 : Form
    {
        public Form_Sjks2030()
        {
            InitializeComponent();
        }

        int length;
        int[] number;
        int num;
        int n;
        private void button1_Click(object sender, EventArgs e)
        {
             string s = textBox1.Text;
                length = (textBox1.Text).Length;
                number = new int[length]; 
               num = 0;
               int base1 = 1;
               int k = 0;
               for (int i = length - 1;i >= 0; i--)
               {
                    if (s[i] >= '0' && s[i] <= '9')
                    {
                         num = num + base1*(s[i] - '0');
                         base1 *= 10;
                         
                    }
                    else
                    {
                         number[k++] = num;
                         num = 0;
                         base1 = 1;
                    }
               }
               number[k++] = num;
               n = k;
               int m1 = 0, m2 = n - 1,temp;
               while(m1 < m2)
               {
                    temp = number[m1];
                    number[m1] = number[m2];
                    number[m2] = temp;
                    m1++;
                    m2--;
               }
               string s2 = "";
               for(int i = 0; i < n; i++)
               {
                    s2 +=( Convert.ToInt32(number[i])  + "\n") ;
               }
               richTextBox2.Text = s2;
               s2 = "";
               for (int k1 = 0; k1 < n - 1; k1++)
               {
                    s2 += Convert.ToString(number[k1]);
                    s2 += ",";
               }
               s2 += Convert.ToString(number[n - 1]);
               s2 += "\n";
               richTextBox1.Text = s2;

        }

        static string Bubble_Sort(int[] a, int n)
        {
            string s = "直接交换法排序(起泡排序)\n\n";
            for (int i = 0; (i < n); i++)
            {

                for (int j = n - 1; j >= i + 1; j--)
                {
                    if (a[j] < a[j - 1])
                    {
                        int temp = a[j];
                        a[j] = a[j - 1];
                        a[j - 1] = temp;
                    }
                }
                for (int k = 0; k < n - 1; k++)
                {
                    s += Convert.ToString(a[k]);
                    s += ",";
                }
                s += Convert.ToString(a[n - 1]);
                s += "\n";
            }
            return s;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = Bubble_Sort(number,n);
        }

        
    }
}
