using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private double Max;
        private double Min;
        private double Pmin = 1;
        private double Pmax = 1;
        private double MaxX;
        private double MinX;

        public Form1()
        {
            InitializeComponent();
            this.chart1.Series[0].Points.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.chart1.Series[0].Points.Clear();
            try
            {
                
                double a = Convert.ToDouble(this.textBoxA.Text), b = Convert.ToDouble(this.textBoxB.Text), h = Convert.ToDouble(this.textBoxH.Text);
                if (h!=0) {
                    List<double> results = new List<double>();
                    List<double> xi = new List<double>();
                    MaxX = 0;
                    MinX = 0;
                    Max = 0;
                    Min = 0;
                    Pmin = 1;
                    Pmax = 1;
                    for (double x = a; x <= b; x += h)
                    {
                        double divider = 1, result = 0;
                        for (double k = 1; k <= 10; k++)
                        {
                            divider = Math.Sin(x);
                            result += Math.Pow(-1, k) * (x * Math.Pow(divider, k)) / k;
                        }
                        this.chart1.Series[0].Points.AddXY(x, result);
                        xi.Add(x);
                        results.Add(result);
                    }
                    Array1(results, xi);
                    for (double k = 1; k <= 6; k++)
                    {
                        Pmin *= (Math.Pow(MinX, k) / Factorial(k));
                        Pmax *= (Math.Pow(MaxX, k) / Factorial(k));
                    }
                    this.label10.Text = "" + Pmin;
                    this.label9.Text = "" + Pmax;
                }
                else {
                    this.label6.Text = "h имеет нулевое значение";
                }
            }catch(Exception ex)
            {
                this.label6.Text = ex.Message;
            }
        }
        private void Array1(List<double> t, List<double> ti)
        {
            double[] u = new double[t.Count];
            for(int i =0; i<u.Length;i++)
            {
                u[i] = t.ElementAt(i);
            }
            Max = u.Max();
            Min = u.Min();
            t.Sort();
            MaxX = ti[Array.IndexOf(u,Max)];
            MinX = ti[Array.IndexOf(u,Min)];
            this.label13.Text = "" + Min;
            this.label14.Text = "" + Max;
        }
        private double Factorial(double n)
        {
            if (n == 1) return 1;
            return n * Factorial(n - 1);
        }

    }
}
