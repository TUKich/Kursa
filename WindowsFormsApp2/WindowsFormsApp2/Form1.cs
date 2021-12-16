using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private Double Max;
        private Double Min;
        private double Pmin = 1;
        private double Pmax = 1;
        private double MaxX;
        private double MinX;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.chart1.Series[0].Points.Clear();
            if (CheckNull())
            {
                double a = Convert.ToDouble(this.textBoxA.Text);
                double b = Convert.ToDouble(this.textBoxB.Text);
                double h = Convert.ToDouble(this.textBoxH.Text);
                List<double> results = new List<double>();
                List<double> xi = new List<double>();
                double resultmax;
                double resultmin;
                MaxX = 0;
                MinX = 0;
                Max = 0;
                Min = 0;
                Pmin = 1;
                Pmax = 1;
                for (double x = a; x <= b; x += h)
                {
                  //  double sign = -1;
                    double divider = 1, result = 0, del = 1;
                    
                    for (double k = 1; k <= 10; k++)
                    {
                        
                        divider = Math.Sin(x);
                       // del = (x * divider) / k;
                        result +=Math.Pow(-1,k)*(x * Math.Pow(divider,k)) / k;
                   //     sign *= sign;

                    }
                    this.chart1.Series[0].Points.AddXY(x, result);
                    xi.Add(x);
                    results.Add(result);
                    
                }
                Array1(results,xi);
                
                for (double k = 1; k <= 6; k++)
                {

                    Pmin *= (Math.Pow(MinX, k) / Factorial(k));
                }
                for (double k = 1; k <= 6; k++)
                {

                    Pmax *= (Math.Pow(MaxX, k) / Factorial(k));
                }
                this.label10.Text = "" + Pmin;
                this.label9.Text = "" + Pmax;
            }
        }
        private Boolean CheckNull()
        {
            if (this.textBoxA.Text == "" || this.textBoxB.Text == "" || this.textBoxH.Text == "")
            {
                this.label6.Text = "Пустые поля/е";
                return false;
            }
            this.label6.Text = "";
            return true;
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
