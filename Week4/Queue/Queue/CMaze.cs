using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public struct sqtype //队列的三元组说明,位置和回退下标
    {
        public int x, y, pre;
    }
    struct moved  //坐标增量表
    {
        public int x, y;
    }
    class CMaze
    {
        private int rows, cols;
        private int[,] elems;
        private CQueue<sqtype> sq;
        static moved[] move = new moved[8];
        private string mazetext;

        public CMaze()
        {
        }


        public CMaze(string mazetext)
        {
            this.mazetext = mazetext;
        }

       

        public int Rows
        {
            get { return rows; }
            set { rows = value; }
        }

        public int Cols
        {
            get { return cols; }
            set { cols = value; }
        }

        public int GetIntData(string strdata, int ks, out int outk)//out 返回
        {
            int len = strdata.Length;
            int data;
            string str;
            while ((ks < len) && ((strdata[ks] < '0') || (strdata[ks] > '9')))
                ks++;
            str = "";
            while ((ks < len) && ((strdata[ks] >= '0') && (strdata[ks] <= '9')))
                str = str + strdata[ks++];
            if (str != "")
                data = Convert.ToInt32(str);
            else
                data = 0;
            outk = ks;
            return (data);
        }
        //自己写Getelems,Setelems
        public int Getelems(int i,int j)
        {

            return 0;
        }

        public int Setelems(int i, int j,int n)
        {

            return 0;
        }


        public int ShortPath(int cs)
        {
            //初始化位置坐标增量
            move[0].x = 0; move[1].x = +1; move[2].x = +1; move[3].x = +1;
            move[4].x = 0; move[5].x = -1; move[6].x = -1; move[7].x = -1;
            move[0].y = +1; move[1].y = +1; move[2].y = 0; move[3].y = -1;
            move[4].y = -1; move[5].y = -1; move[6].y = 0; move[7].y = +1;
            //创建队列
            sq = new CQueue<sqtype>();
            if (rows == 0 || cols == 0)
                return 0;
            int i, j, i1, j1, k, x, y, len;
            int ljcs = 0;//迷宫的路径次数
            sqtype temp = new sqtype();
            temp.x = temp.y = 1; temp.pre = 0;//起点进队
            sq.In(temp);
            Setelems(1, 1, -1);
            Random ran = new Random();
            int kr = ran.Next(8);
            while (!sq.IsEmpty())//队不空时循环
            {
                temp = sq.Getfront();//取队头
                x = temp.x; y = temp.y;

                for (k = 0; k < 8; k++)//查找八个方向
                {
                    kr = (kr + k) % 8;
                    i = x + move[kr].x;
                    j = y + move[kr].y;
                    if (Getelems(i, j) == 0)//路通
                    {
                        temp.x = i;
                        temp.y = j;
                        temp.pre = sq.Front() + 1;//前一个结点
                        sq.In(temp);//进队
                        Setelems(i, j, -1);//走过的设置为-1
                    }
                    if (i == rows && j == cols)
                    {
                        ljcs++;
                        if (ljcs == cs)
                        {
                            j1 = sq.Rear();
                            len = 0;
                            for (i1 = sq.Rear(); i1 >= 1; i1--)
                            {
                                temp = sq.Getdata(i1);
                                if (i1 == j1)
                                {
                                    Setelems(temp.x, temp.y, -1);
                                    j1 = temp.pre;
                                    len++;
                                }
                                else
                                    Setelems(temp.x, temp.y, 0);
                            }
                            return len;
                        }
                    }
                }
                sq.Out();//出队
            }
            return 0;
        }

        public string PrintMazeQueue()
        {
            int n = sq.Rear();
            int m_pre, m_x, m_y;
            string m_strout = "";
            m_strout += "┏━━┳━━┯━━┯━━┓\r\n";
            m_strout += "┃序号┃Pre │ ｘ │ ｙ ┃\r\n";
            m_strout += "┣━━╋━━┿━━┿━━┫\r\n";

            for (int i = n; i >= 1; i--)
            {
                m_pre = sq.Getdata(i).pre;
                m_x = sq.Getdata(i).x;
                m_y = sq.Getdata(i).y;
                m_strout += string.Format("┃ {0:d2} ┃ {1:d2} │ {2:d2} │ {3:d2} ┃\r\n", i, m_pre, m_x, m_y);
                if (i > 1)
                    m_strout += "┣━━╋━━┿━━┿━━┫\r\n";
                else
                    m_strout += "┗━━┻━━┷━━┷━━┛\r\n";
            }
            return m_strout;
        }
    }
}
