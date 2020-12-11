using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Integer
    {
        private int _num;

        public virtual int Num
        {
            get { return _num; }
            set { _num = value; }
        }

        public Integer()
        {
            _num = 0;
        }

        public Integer(int val)
        {
            _num = val;
        }

        public static implicit operator Integer(int val)
        {
            return new Integer(val);
        }

        public static implicit operator int(Integer val)
        {
            return val.Num;
        }

        public static Integer operator +(Integer a, Integer b)
        {
            return new Integer(a.Num + b.Num);
        }

        public static Integer operator -(Integer a, Integer b)
        {
            return new Integer(a.Num - b.Num);
        }

        public static Integer operator *(Integer a, Integer b)
        {
            return new Integer(a.Num * b.Num);
        }

        public static Integer operator /(Integer a, Integer b)
        {
            return new Integer(a.Num / b.Num);
        }

        public override string ToString()
        {
            return Num.ToString();
        }
    }

    class Fraction : Integer
    {
        private int _down;

        private int _up;

        public int Down
        {
            get { return _down; }
            set
            {
                if (value == 0)
                {
                    throw new Exception("分母不能为零");
                }

                if (value < 0)
                {
                    _up = -_up;
                    _down = -value;
                }
                else
                {
                    _down = value;
                }

                Reduction();
            }
        }

        public int Up
        {
            get { return _up; }
            set
            {
                if (value == 0)
                {
                    _down = 1;
                }

                _up = value;
                Reduction();
            }
        }

        public override int Num
        {
            get { return _up / _down; }
            set { _up = _up % _down + value * _down; }
        }

        public Fraction()
        {
            _up = 0;
            _down = 1;
        }

        public Fraction(int up, int down)
        {
            if (down == 0)
            {
                throw new ArgumentException("分母不能为零", "down");
            }

            if (up == 0)
            {
                _up = 0;
                _down = 1;
            }
            else if (down < 0)
            {
                _up = -up;
                _down = -down;
            }
            else
            {
                _up = up;
                _down = down;
            }

            Reduction();
        }

        public static implicit operator double(Fraction f)
        {
            return (double)f.Up / f.Down;
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            return new Fraction(a.Up * b.Down + b.Up * a.Down,
            a.Down * b.Down).Reduction();
        }

        public static Fraction operator +(Fraction a, Integer b)
        {
            return new Fraction(a.Up + a.Down * b.Num, a.Down).Reduction();
        }

        public static Fraction operator +(Integer a, Fraction b)
        {
            return new Fraction(b.Up + b.Down * a.Num, b.Down).Reduction();
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            return new Fraction(a.Up * b.Down - b.Up * a.Down,
            a.Down * b.Down).Reduction();
        }

        public static Fraction operator -(Fraction a, Integer b)
        {
            return new Fraction(a.Up - a.Down * b.Num, a.Down).Reduction();
        }

        public static Fraction operator -(Integer a, Fraction b)
        {
            return new Fraction(a.Num * b.Down - b.Up, b.Down).Reduction();
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(a.Up * b.Up, a.Down * b.Down).Reduction();
        }

        public static Fraction operator *(Fraction a, Integer b)
        {
            return new Fraction(a.Up * b.Num, a.Down).Reduction();
        }

        public static Fraction operator *(Integer a, Fraction b)
        {
            return new Fraction(a.Num * b.Up, b.Down).Reduction();
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            return new Fraction(a.Up * b.Down, a.Down * b.Up).Reduction();
        }

        public static Fraction operator /(Fraction a, Integer b)
        {
            return new Fraction(a.Up, a.Down * b.Num).Reduction();
        }

        public static Fraction operator /(Integer a, Fraction b)
        {
            return new Fraction(a.Num * b.Down, b.Up).Reduction();
        }

        public override string ToString()
        {
            Reduction();
            if (Down == 1)
            {
                return Up.ToString();
            }
            return string.Format("{0}/{1}", Up, Down);
        }

        private int GetCommonDivisor(int num1, int num2)
        {
            var remainder = 0;
            if (num1 % num2 == 0)
            {
                remainder = num2;
            }
            else
            {
                while (num1 % num2 > 0)
                {
                    remainder = num1 % num2;
                    num1 = num2;
                    num2 = remainder;
                }
            }

            return remainder;
        }

        private Fraction Reduction()
        {
            var d = GetCommonDivisor(Math.Abs(Up), Math.Abs(Down));
            if (d > 1)
            {
                Up /= d;
                Down /= d;
            }
            return this;
        }
    }
}
