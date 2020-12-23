using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace guanyibiao
{
    class Rational
    {
        private int num;//分子
        private int den;//分母
        public int Num
        {
            get { return num; }
            set { num = value; }
        }
        public int Den
        {
            get { return den; }
            set { den = value; }
        }
        public Rational()//无参的构造有理数
        { num = 0; den = 1; }
        public Rational(int x, int y)//已知分子分母构造有理数
        { num = x; den = y; optimization(); }
        public Rational(Rational ob)//拷贝构造函数
        { num = ob.num; den = ob.den; optimization(); }
        public Rational(double x)//通过实数构造有理数
        {
            if ((int)(x) == x)
            { num = (int)x; den = 1; }
            else
            { num = (int)(x * 1000 + 0.5); den = 1000; }
            optimization();
        }
        public Rational string_double(string s)
        {
            int num, den;
            bool is_n = false, is_l = true;
            int p = 0;
            if (s[0] == '-')
            {

            }
            string t = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '-')
                {
                    is_n = true;
                    continue;
                }
                else if (s[i] == '.')
                {
                    is_l = false;
                }
                else
                {
                    if (!is_l)
                    {
                        p++;
                    }
                    t += s[i];
                }
            }
            num = Convert.ToInt32(t);
            if (is_n)
                num = -num;
            den = 1;
            for (int i = 0; i < p; i++)
            {
                den *= 10;
            }
            Rational dou = new Rational(num, den);
            dou.optimization();
            return dou;
        }
        private void optimization()//辗转相除法约分
        {
            if (num * den == 0)
                return;
            if (Math.Abs(num) > Math.Abs(den))
            {
                int x = num;
                int y = den;
                int c = 0;
                while (x * y != 0)
                {
                    c = y;
                    y = x % y;
                    x = c;

                }
                num = num / x;
                den = den / x;
            }
            else
            {
                int x = den;
                int y = num;
                int c = 0;
                while (x * y != 0)
                {
                    c = y;
                    y = x % y;
                    x = c;
                }
                num = num / x;
                den = den / x;
            }

        }
        public string output()//输出有理数字符串
        {
            string s = null;
            if (den == 1)
                s = Convert.ToString(num);
            else if (den < 0 && den != -1)
                s = "-" + Convert.ToString(num) + "/" + Convert.ToString(den);
            else if (den == -1)
                s = "-" + Convert.ToString(num);
            else
                s = Convert.ToString(num) + "/" + Convert.ToString(den);
            return s;
        }
        public static Rational operator +(Rational rat1, Rational rat2)
        {
            Rational temp = new Rational(0, 1);
            temp.den = rat1.den * rat2.den;
            temp.num = rat1.num * rat2.den + rat1.den * rat2.num;
            temp.optimization();
            return temp;
        }
        public static Rational operator -(Rational rat1, Rational rat2)
        {
            Rational temp = new Rational(0, 1);
            temp.den = rat1.den * rat2.den;
            temp.num = rat1.num * rat2.den - rat1.den * rat2.num;
            temp.optimization();
            return temp;
        }
        public static Rational operator *(Rational rat1, Rational rat2)
        {
            Rational temp = new Rational(0, 1);
            temp.den = rat1.den * rat2.den;
            temp.num = rat1.num * rat2.num;
            temp.optimization();
            return temp;
        }
        public static Rational operator /(Rational rat1, Rational rat2)
        {
            Rational temp = new Rational(0, 1);
            temp.den = rat1.den * rat2.num;
            temp.num = rat1.num * rat2.den;
            temp.optimization();
            return temp;
        }
        public static Rational operator ++(Rational rat1)
        {
            Rational rat2 = new Rational(1, 1);
            rat1 = rat1 + rat2;
            rat1.optimization();
            return rat1;
        }
        public static Rational operator ^(Rational rat1, Rational rat2)
        {
            Rational temp1 = new Rational(0, 1);
            double x1 = Convert.ToDouble(rat2.num);
            double x2 = Convert.ToDouble(rat2.den);
            double y1 = Convert.ToDouble(rat1.num);
            double y2 = Convert.ToDouble(rat1.den);
            temp1 = new Rational(Math.Pow(y1 / y2, x1 / x2));
            return temp1;
        }
    }
}
