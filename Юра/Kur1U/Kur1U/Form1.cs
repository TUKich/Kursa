using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kur1U
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Ex.Text = "";
                this.chart1.Series[0].Points.Clear();
                double a = Convert.ToDouble(this.a.Text), b = Convert.ToDouble(this.b.Text), h = Convert.ToDouble(this.h.Text), A = Convert.ToDouble(this.textBoxA.Text), Xmin = 0, Ytemp = 0, Ytemp0 = double.MaxValue;
                if (h > 0)
                {
                    for(double x = a; x <=b; x += h)
                    {
                        if (searchS(x) > A)
                        {
                            Ytemp = YX1(x);
                        }
                        if(searchS(x)<=A)
                        {
                            Ytemp = YX2(x);
                        }
                        this.chart1.Series[0].Points.AddXY(x, Ytemp);
                        if (Ytemp0 > Ytemp)
                        {
                            Ytemp0 = Ytemp;
                            Xmin = x;
                        }
                    }
                    this.Xmin.Text = "Xmin: " + Xmin;
                }
                else
                {
                    this.Ex.Text = "h > 0";
                }

            }
            catch(Exception ex)
            {
                this.Ex.Text = ex.Message;
            }
        }
        private double searchS(double x)
        {
            double S = (Math.Pow(Math.Sin(x), 2) / x) - (Math.Pow(Math.Sin(x), 4) / Math.Pow(x, 2)) + (Math.Pow(Math.Sin(x), 6) / Math.Pow(x, 3)) - (Math.Pow(Math.Sin(x), 8) / Math.Pow(x, 4)) + (Math.Pow(Math.Sin(x), 10) / Math.Pow(x, 5));
            return S;
        }
        private double YX1(double x)
        {
            double Y = 0;
            for(double n = 1; n<10; n++)
            {
                Y += (Math.Pow(x, n) / 10 + Factorial(n));
            }
            return Y;
        }
        private double YX2(double x)
        {
            double Y = 0;
            for (double n = 1; n < 10; n++)
            {
                Y += Factorial(n)/Math.Pow(x,n);
            }
            return Y;
        }
        private double Factorial(double n)
        {
            if (n == 1) return 1;
            return n * Factorial(n - 1);
        }
    }
   
}
