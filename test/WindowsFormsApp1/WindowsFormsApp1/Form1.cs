using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            int num = int.Parse(textBox1.Text);//分子
            int den = int.Parse(textBox2.Text); ;//分母

            int num2 = int.Parse(textBox3.Text);//分子
            int den2 = int.Parse(textBox4.Text); ;//分母

            if (den != 0 || den2 != 0)
            {
                if (radioButton1.Checked)
                {
                    textBox5.Text = Convert.ToString(num * den2 + num2 * den);
                    textBox6.Text = Convert.ToString(den2 * den);

                }
                else if (radioButton2.Checked)
                {
                    textBox5.Text = Convert.ToString(num * den2 - num2 * den);
                    textBox6.Text = Convert.ToString(den2 * den);
                }
                else if (radioButton3.Checked)
                {
                    textBox5.Text = Convert.ToString(num * num2);
                    textBox6.Text = Convert.ToString(den2 * den);
                }
                else if (radioButton4.Checked)
                {
                    textBox5.Text = Convert.ToString(num * den2);
                    textBox6.Text = Convert.ToString(den2 * num);
                }
                else if (radioButton5.Checked)
                {
                    textBox5.Text = Convert.ToString(Math.Pow(num, num2/den2));
                    textBox6.Text = Convert.ToString(Math.Pow(den, num2 / den2));
                }
                else if (radioButton6.Checked)
                {
                    textBox5.Text = Convert.ToString(num + den2);
                    textBox6.Text = Convert.ToString(den);
                }
                else
                {
                    textBox5.Text = Convert.ToString(num + den);
                    textBox6.Text = Convert.ToString(den);
                }
            }
            else
            {

            }
            
        }

    }
}
