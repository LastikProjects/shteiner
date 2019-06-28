using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shteiner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double line_length;
        int n = 1;
        bool use = false;
        int large_angles = 0;//количество углов больше 120 градусов
        bool first = false;
        bool second = false;
        bool third = false;
        bool forth = false;
        private void button1_Click(object sender, EventArgs e)
        {
            Graphics gr = pictureBox1.CreateGraphics();
            gr.Clear(Color.White);

            float scale = float.Parse(textBox10.Text);

            double x1 = Convert.ToDouble(textBox1.Text);
            double y1 = Convert.ToDouble(textBox2.Text);
            double x2 = Convert.ToDouble(textBox3.Text);
            double y2 = Convert.ToDouble(textBox4.Text);
            double x3 = Convert.ToDouble(textBox5.Text);
            double y3 = Convert.ToDouble(textBox6.Text);
            double x4 = Convert.ToDouble(textBox7.Text);
            double y4 = Convert.ToDouble(textBox8.Text);
            gr.FillEllipse(Brushes.Black, scale * (float)x1 - 3.5f + pictureBox1.Width / 2, pictureBox1.Height / 2 - scale * (float)y1 - 3.5f, 7f, 7f);
            gr.FillEllipse(Brushes.Black, scale * (float)x2 - 3.5f + pictureBox1.Width / 2, pictureBox1.Height / 2 - scale * (float)y2 - 3.5f, 7f, 7f);
            gr.FillEllipse(Brushes.Black, scale * (float)x3 - 3.5f + pictureBox1.Width / 2, pictureBox1.Height / 2 - scale * (float)y3 - 3.5f, 7f, 7f);
            gr.FillEllipse(Brushes.Black, scale * (float)x4 - 3.5f + pictureBox1.Width / 2, pictureBox1.Height / 2 - scale * (float)y4 - 3.5f, 7f, 7f);

            double ab = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
            double bc = Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));
            double cd = Math.Sqrt(Math.Pow(x3 - x4, 2) + Math.Pow(y3 - y4, 2));
            double ad = Math.Sqrt(Math.Pow(x1 - x4, 2) + Math.Pow(y1 - y4, 2));
            double ac = Math.Sqrt(Math.Pow(x1 - x3, 2) + Math.Pow(y1 - y3, 2));
            double bd = Math.Sqrt(Math.Pow(x4 - x2, 2) + Math.Pow(y4 - y2, 2));

            first = false;
            second = false;
            third = false;
            forth = false;

            line_length = 0;
            large_angles = 0;
            search_angles(ab, bc, cd, ac, ad, bd, x1, y1, x2, y2, x3, y3, x4, y4, gr, scale);



            if (large_angles >= 2)
            {
                double first_second = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));//если найдено более 1 угла более 120 градусов,
                double second_third = Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));//то находим кратчайшие расстояния и соединяем их
                double first_third = Math.Sqrt(Math.Pow(x1 - x3, 2) + Math.Pow(y1 - y3, 2));
                double first_forth = Math.Sqrt(Math.Pow(x1 - x4, 2) + Math.Pow(y1 - y4, 2));
                double second_forth = Math.Sqrt(Math.Pow(x2 - x4, 2) + Math.Pow(y4 - y2, 2));
                double third_forth = Math.Sqrt(Math.Pow(x3 - x4, 2) + Math.Pow(y3 - y4, 2));
                double f, s, t, fh;
                if (first_second <= first_third & first_second < first_forth)
                {
                    f = first_second;
                    gr.DrawLine(new Pen(Brushes.Black), (float)x1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y1 * scale, (float)x2 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y2 * scale);
                }
                else
                if (first_third <= first_second & first_third < first_forth)
                {
                    f = first_third;
                    gr.DrawLine(new Pen(Brushes.Black), (float)x1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y1 * scale, (float)x3 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y3 * scale);
                }
                else
                {
                    gr.DrawLine(new Pen(Brushes.Black), (float)x1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y1 * scale, (float)x4 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y4 * scale);
                    f = first_forth;
                }

                if (second_third <= first_second & second_third < second_forth)
                {
                    gr.DrawLine(new Pen(Brushes.Black), (float)x3 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y3 * scale, (float)x2 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y2 * scale);
                    s = second_third;
                }
                else
                if (first_second <= second_third & first_second < second_forth)
                {
                    gr.DrawLine(new Pen(Brushes.Black), (float)x1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y1 * scale, (float)x2 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y2 * scale);
                    s = first_second;
                }
                else
                {
                    gr.DrawLine(new Pen(Brushes.Black), (float)x4 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y4 * scale, (float)x2 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y2 * scale);
                    s = second_forth;
                }

                if (first_third <= second_third & first_third < third_forth)
                {
                    gr.DrawLine(new Pen(Brushes.Black), (float)x3 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y3 * scale, (float)x4 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y4 * scale);
                    t = first_third;
                }
                else
                if (second_third <= first_third & second_third < third_forth)
                {
                    gr.DrawLine(new Pen(Brushes.Black), (float)x3 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y3 * scale, (float)x2 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y2 * scale);
                    t = second_third;
                }
                else
                {
                    gr.DrawLine(new Pen(Brushes.Black), (float)x3 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y3 * scale, (float)x4 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y4 * scale);
                    t = third_forth;
                }

                if (first_forth <= second_forth & first_forth < third_forth)
                {
                    gr.DrawLine(new Pen(Brushes.Black), (float)x1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y1 * scale, (float)x4 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y4 * scale);
                    fh = first_forth;
                }
                else
                if (second_forth <= first_forth & second_forth < third_forth)
                {
                    gr.DrawLine(new Pen(Brushes.Black), (float)x4 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y4 * scale, (float)x2 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y2 * scale);
                    fh = second_forth;
                }
                else
                {
                    gr.DrawLine(new Pen(Brushes.Black), (float)x3 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y3 * scale, (float)x4 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y4 * scale);
                    fh = third_forth;
                }

                double result = f + s + t + fh;
                if (f == s | f == t | f == fh)
                    result -= f;
                else if (s == t | s == fh)
                    result -= s;
                else
                    result -= t;

                textBox9.Text = "минимальное расстояние - " + result.ToString();
                textBox9.Text += "Найдено два угла больше чем 120 градусов";
                return;
            }
            else if (large_angles == 1)//если угол больше 120 градусов один, то находим сеть для оставшихся трех точек
            {
                textBox9.Text += "Найден угол больше 120 градусов, ";
                if (first == true)
                    setb(x2, y2, x3, y3, x4, y4);
                else
                    if (second == true)
                    setb(x1, y1, x3, y3, x4, y4);
                else if (third == true)
                    setb(x1, y1, x2, y2, x4, y4);
                else
                    setb(x1, y1, x2, y2, x3, y3);
            }
            else
            {
                if (n == 1 & use == false)//если таких углов нету, заменяем две точки на одну и строим для трех точек сеть,
                {                         //а потом возвращаем замененную точку и уже строим сеть для оставшихся
                    function(x1, y1, x2, y2, x3, y3, x4, y4);
                    use = true;
                }
                else if (n == 1 & use == true)
                {
                    function(x1, y1, x2, y2, x3, y3, x4, y4);
                    use = false;
                    n++;
                }
                else if (n == 2 & use == false)
                {
                    function(x2, y2, x3, y3, x4, y4, x1, y1);
                    use = true;
                }
                else if (n == 2 & use == true)
                {
                    function(x2, y2, x3, y3, x4, y4, x1, y1);
                    use = false;
                    n++;
                }
                else if (n == 3 & use == false)
                {
                    function(x3, y3, x4, y4, x1, y1, x2, y2);
                    use = true;
                }
                else if (n == 3 & use == true)
                {
                    function(x3, y3, x4, y4, x1, y1, x2, y2);
                    use = false;
                    n++;
                }
                else if (use == false)
                {
                    function(x4, y4, x1, y1, x2, y2, x3, y3);
                    use = true;
                }
                else
                {
                    n = 1;
                    function(x4, y4, x1, y1, x2, y2, x3, y3);
                    use = false;
                }
            }

        }

        public void search_angles(double ab, double bc, double cd, double ac, double ad, double bd, double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4, Graphics gr, float scale)
        {
            if (Math.Acos((ac * ac + ad * ad - cd * cd) / (2 * ac * ad)) * 180 / Math.PI >= 120)
            {
                large_angles++;
                if (bc > bd)
                {
                    line_length = Math.Sqrt(Math.Pow(x1 - x3, 2) + Math.Pow(y1 - y3, 2));
                    third = true;
                    gr.DrawLine(new Pen(Brushes.Black), (float)x3 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y3 * scale, (float)x1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y1 * scale);
                }
                else
                {
                    line_length = Math.Sqrt(Math.Pow(x1 - x4, 2) + Math.Pow(y1 - y4, 2));
                    forth = true;
                    gr.DrawLine(new Pen(Brushes.Black), (float)x4 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y4 * scale, (float)x1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y1 * scale);
                }
            }

            if (Math.Acos((ab * ab + ad * ad - bd * bd) / (2 * ab * ad)) * 180 / Math.PI >= 120)
            {
                large_angles++;
                if (bc > cd)
                {
                    line_length = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
                    second = true;
                    gr.DrawLine(new Pen(Brushes.Black), (float)x2 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y2 * scale, (float)x1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y1 * scale);
                }
                else
                {
                    line_length = Math.Sqrt(Math.Pow(x1 - x4, 2) + Math.Pow(y1 - y4, 2));
                    forth = true;
                    gr.DrawLine(new Pen(Brushes.Black), (float)x4 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y4 * scale, (float)x1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y1 * scale);
                }
            }

            if (Math.Acos((ab * ab + ac * ac - bc * bc) / (2 * ac * ab)) * 180 / Math.PI >= 120)
            {
                large_angles++;
                if (bd > cd)
                {
                    line_length = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
                    second = true;
                    gr.DrawLine(new Pen(Brushes.Black), (float)x1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y1 * scale, (float)x2 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y2 * scale);
                }
                else
                {
                    line_length = Math.Sqrt(Math.Pow(x1 - x3, 2) + Math.Pow(y1 - y3, 2));
                    third = true;
                    gr.DrawLine(new Pen(Brushes.Black), (float)x1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y1 * scale, (float)x3 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y3 * scale);
                }
            }

            if (Math.Acos((ab * ab + bd * bd - ad * ad) / (2 * ab * bd)) * 180 / Math.PI >= 120)
            {
                large_angles++;
                if (ac > cd)
                {
                    line_length = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
                    first = true;
                    gr.DrawLine(new Pen(Brushes.Black), (float)x1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y1 * scale, (float)x2 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y2 * scale);
                }
                else
                {
                    line_length = Math.Sqrt(Math.Pow(x2 - x4, 2) + Math.Pow(y2 - y4, 2));
                    forth = true;
                    gr.DrawLine(new Pen(Brushes.Black), (float)x4 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y4 * scale, (float)x2 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y2 * scale);
                }
            }

            if (Math.Acos((ab * ab + bc * bc - ac * ac) / (2 * ab * bc)) * 180 / Math.PI >= 120)
            {
                line_length = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
                large_angles++;
                if (ad > cd)
                {
                    first = true;
                    gr.DrawLine(new Pen(Brushes.Black), (float)x2 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y2 * scale, (float)x1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y1 * scale);
                }
                else
                {
                    line_length = Math.Sqrt(Math.Pow(x2 - x3, 2) + Math.Pow(y2 - y3, 2));
                    third = true;
                    gr.DrawLine(new Pen(Brushes.Black), (float)x2 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y2 * scale, (float)x3 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y3 * scale);
                }
            }

            if (Math.Acos((bc * bc + bd * bd - cd * cd) / (2 * bc * bd)) * 180 / Math.PI >= 120)
            {
                large_angles++;
                if (ad > ac)
                {
                    line_length = Math.Sqrt(Math.Pow(x2 - x4, 2) + Math.Pow(y2 - y4, 2));
                    forth = true;
                    gr.DrawLine(new Pen(Brushes.Black), pictureBox1.Width / 2 + (float)x2 * scale, pictureBox1.Height / 2 - (float)y2 * scale, (float)x4 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y4 * scale);
                }
                else
                {
                    line_length = Math.Sqrt(Math.Pow(x2 - x3, 2) + Math.Pow(y2 - y3, 2));
                    third = true;
                    gr.DrawLine(new Pen(Brushes.Black), pictureBox1.Width / 2 + (float)x2 * scale, pictureBox1.Height / 2 - (float)y2 * scale, (float)x3 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y3 * scale);
                }
            }

            if (Math.Acos((bc * bc + ac * ac - ab * ab) / (2 * ac * bc)) * 180 / Math.PI >= 120)
            {
                large_angles++;
                if (ad > bd)
                {
                    line_length = Math.Sqrt(Math.Pow(x1 - x3, 2) + Math.Pow(y1 - y3, 2));
                    first = true;
                    gr.DrawLine(new Pen(Brushes.Black), (float)x3 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y3 * scale, (float)x1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y1 * scale);
                }
                else
                {
                    line_length = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
                    second = true;
                    gr.DrawLine(new Pen(Brushes.Black), (float)x2 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y2 * scale, (float)x1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y1 * scale);
                }
            }

            if (Math.Acos((bc * bc + cd * cd - bd * bd) / (2 * bc * cd)) * 180 / Math.PI >= 120)//
            {
                large_angles++;
                if (ab > ad)
                {
                    line_length = Math.Sqrt(Math.Pow(x2 - x3, 2) + Math.Pow(y2 - y3, 2));
                    second = true;
                    gr.DrawLine(new Pen(Brushes.Black), (float)(x3 * scale + pictureBox1.Width / 2), (float)(pictureBox1.Height / 2 - y3 * scale), (float)(x2 * scale + pictureBox1.Width / 2), (float)(pictureBox1.Height / 2 - y2 * scale));
                }
                else
                {
                    line_length = Math.Sqrt(Math.Pow(x4 - x3, 2) + Math.Pow(y4 - y3, 2));
                    forth = true;
                    gr.DrawLine(new Pen(Brushes.Black), (float)x4 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y4 * scale, (float)x3 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y3 * scale);
                }
            }

            if (Math.Acos((ac * ac + cd * cd - ad * ad) / (2 * ac * cd)) * 180 / Math.PI >= 120)
            {
                large_angles++;
                if (ab > bd)
                {
                    line_length = Math.Sqrt(Math.Pow(x1 - x3, 2) + Math.Pow(y1 - y3, 2));
                    first = true;
                    gr.DrawLine(new Pen(Brushes.Black), (float)x3 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y3 * scale, (float)x1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y1 * scale);
                }
                else
                {
                    line_length = Math.Sqrt(Math.Pow(x4 - x3, 2) + Math.Pow(y4 - y3, 2));
                    forth = true;
                    gr.DrawLine(new Pen(Brushes.Black), (float)x4 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y4 * scale, (float)x3 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y3 * scale);
                }
            }

            if (Math.Acos((bd * bd + cd * cd - bc * bc) / (2 * bd * cd)) * 180 / Math.PI >= 120)
            {
                large_angles++;
                if (ab > ac)
                {
                    line_length = Math.Sqrt(Math.Pow(x2 - x4, 2) + Math.Pow(y2 - y4, 2));
                    second = true;
                    gr.DrawLine(new Pen(Brushes.Black), (float)x2 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y2 * scale, (float)x4 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y4 * scale);
                }
                else
                {
                    line_length = Math.Sqrt(Math.Pow(x4 - x3, 2) + Math.Pow(y4 - y3, 2));
                    third = true;
                    gr.DrawLine(new Pen(Brushes.Black), (float)x4 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y4 * scale, (float)x3 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y3 * scale);
                }
            }

            if (Math.Acos((ad * ad + cd * cd - ac * ac) / (2 * cd * ad)) * 180 / Math.PI >= 120)
            {
                large_angles++;
                if (ab > bc)
                {
                    line_length = Math.Sqrt(Math.Pow(x1 - x4, 2) + Math.Pow(y1 - y4, 2));
                    first = true;
                    gr.DrawLine(new Pen(Brushes.Black), (float)x1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y1 * scale, (float)x4 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y4 * scale);
                }
                else
                {
                    line_length = Math.Sqrt(Math.Pow(x4 - x3, 2) + Math.Pow(y4 - y3, 2));
                    third = true;
                    gr.DrawLine(new Pen(Brushes.Black), (float)x4 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y4 * scale, (float)x3 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y3 * scale);
                }
            }

            if (Math.Acos((ad * ad + bd * bd - ab * ab) / (2 * bd * ad)) * 180 / Math.PI >= 120)
            {
                large_angles++;
                if (ac > bc)
                {
                    line_length = Math.Sqrt(Math.Pow(x1 - x4, 2) + Math.Pow(y1 - y4, 2));
                    first = true;
                    gr.DrawLine(new Pen(Brushes.Black), (float)x4 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y4 * scale, (float)x1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y1 * scale);
                }
                else
                {
                    line_length = Math.Sqrt(Math.Pow(x2 - x4, 2) + Math.Pow(y2 - y4, 2));
                    second = true;
                    gr.DrawLine(new Pen(Brushes.Black), (float)x4 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y4 * scale, (float)x2 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y2 * scale);
                }
            }
        }

        private void function(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            float scale = float.Parse(textBox10.Text);
            Graphics gr = pictureBox1.CreateGraphics();

            double newx1, newy1;//координаты точки равностороннего треугольника
            double newx2 = x4 + (x3 - x4) / 2 + (y3 - y4) * Math.Sqrt(3) / 2, newy2 = y4 - (x3 - x4) * Math.Sqrt(3) / 2 + (y3 - y4) / 2;//координаты точки равностороннего треугольника но уже от других точек
            if (use == false)
            {
                newx1 = (x2 - x1) / 2 - (y2 - y1) * Math.Sqrt(3) / 2 + x1;
                newy1 = (x2 - x1) * Math.Sqrt(3) / 2 + (y2 - y1) / 2 + y1;
            }
            else
            {
                newx1 = x1 + (x2 - x1) / 2 + (y2 - y1) * Math.Sqrt(3) / 2;
                newy1 = y1 - (x2 - x1) * Math.Sqrt(3) / 2 + (y2 - y1) / 2;
            }
            gr.FillEllipse(Brushes.Green, (float)(pictureBox1.Width / 2 + newx1 * scale - 3.5), (float)(pictureBox1.Height / 2 - newy1 * scale - 3.5), 7f, 7f);
            gr.DrawLine(new Pen(Brushes.Green), (float)newx1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)newy1 * scale, (float)x1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y1 * scale);
            gr.DrawLine(new Pen(Brushes.Green), (float)newx1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)newy1 * scale, (float)x2 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y2 * scale);
            gr.DrawLine(new Pen(Brushes.Green), (float)x1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y1 * scale, (float)x2 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y2 * scale);
            //textBox1.Text = Math.Sqrt(Math.Pow(newx2 - x4, 2) + Math.Pow(newy2 - y4, 2)).ToString();

            double ab = Math.Sqrt(Math.Pow(x3 - x4, 2) + Math.Pow(y3 - y4, 2));
            double bc = Math.Sqrt(Math.Pow(newx1 - x4, 2) + Math.Pow(newy1 - y4, 2));
            double ac = Math.Sqrt(Math.Pow(x3 - newx1, 2) + Math.Pow(y3 - newy1, 2));
            if (Math.Acos((ab * ab + ac * ac - bc * bc) / (2 * ab * ac)) * 180 / Math.PI >= 120)
            {
                gr.DrawLine(new Pen(Brushes.Black), (float)x3 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y3 * scale, (float)x4 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y4 * scale);
                gr.DrawLine(new Pen(Brushes.Black), (float)x3 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y3 * scale, (float)newx1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)newy1 * scale);
                line_length = Math.Sqrt(Math.Pow(x3 - x4, 2)+ Math.Pow(y3 - y4, 2)) + Math.Sqrt(Math.Pow(x3 - newx1, 2) + Math.Pow(y3 - newy1, 2));
                setb(x1, y1, x2, y2, x3, y3);
                gr.FillEllipse(Brushes.Red, (float)(pictureBox1.Width / 2 + newx1 * scale - 3.5), (float)(pictureBox1.Height / 2 - newy1 * scale - 3.5), 7f, 7f);
                return;
            }

            if (Math.Acos((ab * ab + bc * bc - ac * ac) / (2 * ab * bc)) * 180 / Math.PI >= 120)
            {
                gr.DrawLine(new Pen(Brushes.Black), (float)x3 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y3 * scale, (float)x4 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y4 * scale);
                gr.DrawLine(new Pen(Brushes.Black), (float)x4 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y4 * scale, (float)newx1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)newy1 * scale);
                line_length = Math.Sqrt(Math.Pow(x3 - x4, 2) + Math.Pow(y3 - y4, 2)) + Math.Sqrt(Math.Pow(x4 - newx1, 2) + Math.Pow(y4 - newy1, 2));
                setb(x1, y1, x2, y2, x4, y4);
                gr.FillEllipse(Brushes.Red, (float)(pictureBox1.Width / 2 + newx1 * scale - 3.5), (float)(pictureBox1.Height / 2 - newy1 * scale - 3.5), 7f, 7f);
                return;
            }

            if (Math.Acos((ac * ac + bc * bc - ab * ab) / (2 * ac * bc)) * 180 / Math.PI >= 120)
            {
                gr.DrawLine(new Pen(Brushes.Black), (float)x3 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y3 * scale, (float)newx1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)newy1 * scale);
                gr.DrawLine(new Pen(Brushes.Black), (float)x4 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y4 * scale, (float)newx1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)newy1 * scale);
                line_length = Math.Sqrt(Math.Pow(newx1 - x4, 2) + Math.Pow(newy1 - y4, 2)) + Math.Sqrt(Math.Pow(x3 - newx1, 2) + Math.Pow(y3 - newy1, 2));
                ab = Math.Sqrt(Math.Pow(newx1 - x1, 2) + Math.Pow(newy1 - y1, 2));
                bc = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
                ac = Math.Sqrt(Math.Pow(newx1 - x2, 2) + Math.Pow(newy1 - y2, 2));
                if (Math.Acos((ab * ab + ac * ac - bc * bc) / (2 * ab * ac)) * 180 / Math.PI >= 120)
                {
                    gr.DrawLine(new Pen(Brushes.Black), (float)newx1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)newy1 * scale, (float)x2 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y2 * scale);
                    gr.DrawLine(new Pen(Brushes.Black), (float)x1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y1 * scale, (float)newx1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)newy1 * scale);
                    textBox9.Text += "сумма длин дорог = " + (line_length + Math.Sqrt(Math.Pow(newx1 - x1, 2) + Math.Pow(newy1 - y1, 2)) + Math.Sqrt(Math.Pow(x2 - newx1, 2) + Math.Pow(y2 - newy1, 2))).ToString() + Environment.NewLine;
                    return;
                }
                if (Math.Acos((ab * ab + bc * bc - ac * ac) / (2 * ab * bc)) * 180 / Math.PI >= 120)
                {
                    gr.DrawLine(new Pen(Brushes.Black), (float)x1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y1 * scale, (float)x2 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y2 * scale);
                    gr.DrawLine(new Pen(Brushes.Black), (float)x1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y1 * scale, (float)newx1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)newy1 * scale);
                    textBox9.Text += "сумма длин дорог = " + (line_length + Math.Sqrt(Math.Pow(newx1 - x1, 2) + Math.Pow(newy1 - y1, 2)) + Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2))).ToString() + Environment.NewLine;
                    return;
                }
                if (Math.Acos((ac * ac + bc * bc - ab * ab) / (2 * ac * bc)) * 180 / Math.PI >= 120)
                {
                    gr.DrawLine(new Pen(Brushes.Black), (float)x1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y1 * scale, (float)x2 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y2 * scale);
                    gr.DrawLine(new Pen(Brushes.Black), (float)x2 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y2 * scale, (float)newx1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)newy1 * scale);
                    textBox9.Text += "сумма длин дорог = " + (line_length + Math.Sqrt(Math.Pow(newx1 - x2, 2) + Math.Pow(newy1 - y2, 2)) + Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y1 - y2, 2))).ToString() + Environment.NewLine;
                    return;
                }
                gr.FillEllipse(Brushes.Red, (float)(pictureBox1.Width / 2 + newx1 * scale - 3.5), (float)(pictureBox1.Height / 2 - newy1 * scale - 3.5), 7f, 7f);
                setb( x1, y1, x2, y2,newx1, newy1);
                return;
            }

            double Centrex = ((x3 * x3 + y3 * y3) * (y4 - newy2) + (x4 * x4 + y4 * y4) * (newy2 - y3) + (newy2 * newy2 + newx2 * newx2) * (y3 - y4)) / (2 * (x3 * (y4 - newy2) + x4 * (newy2 - y3) + newx2 * (y3 - y4)));
            double Centrey = ((x3 * x3 + y3 * y3) * (newx2 - x4) + (x4 * x4 + y4 * y4) * (x3 - newx2) + (newy2 * newy2 + newx2 * newx2) * (x4 - x3)) / (2 * (x3 * (y4 - newy2) + x4 * (newy2 - y3) + newx2 * (y3 - y4)));
            //gr.FillEllipse(Brushes.Green, (float)(pictureBox1.Width / 2 + Centrex * 30f - 3.5), (float)(pictureBox1.Height / 2 - Centrey * 30f - 3.5), 7f, 7f);
            double radius = Math.Sqrt(Math.Pow(Centrex - x3, 2) + Math.Pow(Centrey - y3, 2));
            double k = (newy2 - newy1) / (newx2 - newx1);
            double b = newy2 - k * newx2;
            double newx3 = 0, newy3 = 0;
            if (newx2 - newx1 == 0)
            {
                //newy3 = (2 * b + Math.Sqrt(4 * b * b - 4 * (1 + k * k) * (b * b - radius * radius * k * k))) / (2 * (k * k + 1));//координаты точки пересечения окружности и прямой
                //if (Math.Round(newy3, 5) == Math.Round(newy2, 5))
                //    newy3 = (2 * b - Math.Sqrt(4 * b * b - 4 * (1 + k * k) * (b * b - radius * radius * k * k))) / (2 * (k * k + 1));
                //else
                //    if (Math.Round((2 * b - Math.Sqrt(4 * b * b - 4 * (1 + k * k) * (b * b - radius * radius * k * k))) / (2 * (k * k + 1)), 5) != Math.Round(newy2, 5))
                //    textBox9.Text = "Ошибка при нахождении точки пересечения окружности и прямой";
                //newx3 = (newy3 - b) / k;
                if (Centrey + radius == newy2)
                    newy3 = Centrey - radius;
                else
                    if (Centrey - radius == newy2)
                    newy3 = Centrey + radius;
                else
                    textBox9.Text = "Ошибка при нахождении точки пересечения окружности и прямой";
                newx3 = newx1;
            }
            else
            {
                newx3 = (-2 * k * (b - Centrey) + 2 * Centrex + Math.Sqrt(Math.Pow((2 * k * (b - Centrey) - 2 * Centrex), 2) - 4 * (k * k + 1) * (Math.Pow(b - Centrey, 2) + Centrex * Centrex - radius * radius))) / (2 * (k * k + 1));//координаты точки пересечения окружности и прямой
                if (Math.Round(newx3, 5) == Math.Round(newx2, 5))
                    newx3 = (-2 * k * (b - Centrey) + 2 * Centrex - Math.Sqrt(Math.Pow((2 * k * (b - Centrey) - 2 * Centrex), 2) - 4 * (k * k + 1) * (Math.Pow(b - Centrey, 2) + Centrex * Centrex - radius * radius))) / (2 * (k * k + 1));
                else
                    if (Math.Round((-2 * k * (b - Centrey) + 2 * Centrex - Math.Sqrt(Math.Pow((2 * k * (b - Centrey) - 2 * Centrex), 2) - 4 * (k * k + 1) * (Math.Pow(b - Centrey, 2) + Centrex * Centrex - radius * radius))) / (2 * (k * k + 1)), 5) != Math.Round(newx2, 5))
                    textBox9.Text = "Ошибка при нахождении точки пересечения окружности и прямой";
                newy3 = k * newx3 + b;
            }
            newx1 = (x2 - x1) / 2 - (y2 - y1) * Math.Sqrt(3) / 2 + x1;
            newy1 = (x2 - x1) * Math.Sqrt(3) / 2 + (y2 - y1) / 2 + y1;
            gr.DrawLine(new Pen(Brushes.Green), (float)newx1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)newy1 * scale, (float)x1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y1 * scale);
            gr.DrawLine(new Pen(Brushes.Green), (float)newx1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)newy1 * scale, (float)x2 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y2 * scale);
            gr.DrawLine(new Pen(Brushes.Green), (float)x1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y1 * scale, (float)x2 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y2 * scale);
            gr.DrawEllipse(new Pen(Brushes.Green), (float)(pictureBox1.Width / 2 + (Centrex - radius) * scale), (float)(pictureBox1.Height / 2 - Centrey * scale - radius * scale), (float)(2 * radius * scale), (float)(2 * radius * scale));//30
            k = (newy3 - newy1) / (newx3 - newx1);
            b = newy3 - k * newx3;
            Centrex = ((x1 * x1 + y1 * y1) * (y2 - newy1) + (x2 * x2 + y2 * y2) * (newy1 - y1) + (newy1 * newy1 + newx1 * newx1) * (y1 - y2)) / (2 * (x1 * (y2 - newy1) + x2 * (newy1 - y1) + newx1 * (y1 - y2)));
            Centrey = ((x1 * x1 + y1 * y1) * (newx1 - x2) + (x2 * x2 + y2 * y2) * (x1 - newx1) + (newy1 * newy1 + newx1 * newx1) * (x2 - x1)) / (2 * (x1 * (y2 - newy1) + x2 * (newy1 - y1) + newx1 * (y1 - y2)));
            //gr.FillEllipse(Brushes.Green, (float)(pictureBox1.Width / 2 + Centrex * 30f - 3.5), (float)(pictureBox1.Height / 2 - Centrey * 30f - 3.5), 7f, 7f);
            radius = Math.Sqrt(Math.Pow(Centrex - x1, 2) + Math.Pow(Centrey - y1, 2));
            double newy4 = 0, newx4 = 0;
            if (newx3 - newx1 == 0)
            {
                //newy4 = (2 * b + Math.Sqrt(4 * b * b - 4 * (1 + k * k) * (b * b - radius * radius * k * k))) / (2 * (k * k + 1));//координаты точки пересечения окружности и прямой
                //if (Math.Round(newy4, 5) == Math.Round(newy1, 5))
                //    newy4 = (2 * b - Math.Sqrt(4 * b * b - 4 * (1 + k * k) * (b * b - radius * radius * k * k))) / (2 * (k * k + 1));
                //else
                //    if (Math.Round((2 * b - Math.Sqrt(4 * b * b - 4 * (1 + k * k) * (b * b - radius * radius * k * k))) / (2 * (k * k + 1)), 5) != Math.Round(newy1, 5))
                //    textBox9.Text = "Ошибка при нахождении точки пересечения окружности и прямой";
                //newx4 = (newy4 - b) / k;
                if (Centrey + radius == newy1)
                    newy4 = Centrey - radius;
                else
                    if (Centrey - radius == newy1)
                    newy4 = Centrey + radius;
                else
                    textBox9.Text = "Ошибка при нахождении точки пересечения окружности и прямой";
                newx4 = newx1;
            }
            else
            {
                newx4 = (-2 * k * (b - Centrey) + 2 * Centrex + Math.Sqrt(Math.Pow((2 * k * (b - Centrey) - 2 * Centrex), 2) - 4 * (k * k + 1) * (Math.Pow(b - Centrey, 2) + Centrex * Centrex - radius * radius))) / (2 * (k * k + 1));
                //textBox2.Text = newx4.ToString();
                if (Math.Round(newx4, 5) == Math.Round(newx1, 5))
                    newx4 = (-2 * k * (b - Centrey) + 2 * Centrex - Math.Sqrt(Math.Pow((2 * k * (b - Centrey) - 2 * Centrex), 2) - 4 * (k * k + 1) * (Math.Pow(b - Centrey, 2) + Centrex * Centrex - radius * radius))) / (2 * (k * k + 1));
                else
                    if (Math.Round((-2 * k * (b - Centrey) + 2 * Centrex - Math.Sqrt(Math.Pow((2 * k * (b - Centrey) - 2 * Centrex), 2) - 4 * (k * k + 1) * (Math.Pow(b - Centrey, 2) + Centrex * Centrex - radius * radius))) / (2 * (k * k + 1)), 5) != Math.Round(newx1, 5))
                    textBox9.Text = "Ошибка при нахождении точки пересечения окружности и прямой";
                newy4 = k * newx4 + b;
            }
            //textBox1.Text = Math.Round((-2 * k * (b - Centrey) + 2 * Centrex - Math.Sqrt(Math.Pow((2 * k * (b - Centrey) - 2 * Centrex), 2) - 4 * (k * k + 1) * (Math.Pow(b - Centrey, 2) + Centrex * Centrex - radius * radius))) / (2 * (k * k + 1)), 5).ToString();
            gr.DrawLine(new Pen(Brushes.Black), (float)newx3 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)newy3 * scale, (float)x3 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y3 * scale);
            gr.DrawLine(new Pen(Brushes.Black), (float)newx3 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)newy3 * scale, (float)x4 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y4 * scale);
            gr.DrawLine(new Pen(Brushes.Black), (float)newx3 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)newy3 * scale, (float)newx4 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)newy4 * scale);
            gr.DrawLine(new Pen(Brushes.Black), (float)newx4 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)newy4 * scale, (float)x1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y1 * scale);
            gr.DrawLine(new Pen(Brushes.Black), (float)newx4 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)newy4 * scale, (float)x2 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y2 * scale);


            gr.DrawLine(new Pen(Brushes.Green), (float)newx2 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)newy2 * scale, (float)x3 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y3 * scale);
            gr.DrawLine(new Pen(Brushes.Green), (float)newx2 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)newy2 * scale, (float)x4 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y4 * scale);
            gr.DrawLine(new Pen(Brushes.Green), (float)x3 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y3 * scale, (float)x4 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y4 * scale);

            gr.FillEllipse(Brushes.Green, (float)(pictureBox1.Width / 2 + newx1 * scale - 3.5), (float)(pictureBox1.Height / 2 - newy1 * scale - 3.5), 7f, 7f);
            gr.FillEllipse(Brushes.Green, (float)(pictureBox1.Width / 2 + newx2 * scale - 3.5), (float)(pictureBox1.Height / 2 - newy2 * scale - 3.5), 7f, 7f);
            gr.FillEllipse(Brushes.Red, (float)(pictureBox1.Width / 2 + newx3 * scale - 3.5), (float)(pictureBox1.Height / 2 - newy3 * scale - 3.5), 7f, 7f);
            gr.FillEllipse(Brushes.Red, (float)(pictureBox1.Width / 2 + newx4 * scale - 3.5), (float)(pictureBox1.Height / 2 - newy4 * scale - 3.5), 7f, 7f);


            gr.DrawEllipse(new Pen(Brushes.Green), (float)(pictureBox1.Width / 2 + (Centrex - radius) * scale), (float)(pictureBox1.Height / 2 - Centrey * scale - radius * scale), (float)(2 * radius * scale), (float)(2 * radius * scale));//30

            textBox9.Text += "сумма длин дорог = " + (Math.Sqrt(Math.Pow(x1 - newx4, 2) + Math.Pow(y1 - newy4, 2)) + Math.Sqrt(Math.Pow(x2 - newx4, 2) + Math.Pow(y2 - newy4, 2)) + Math.Sqrt(Math.Pow(x3 - newx3, 2) + Math.Pow(y3 - newy3, 2)) + Math.Sqrt(Math.Pow(x4 - newx3, 2) + Math.Pow(y4 - newy3, 2)) + Math.Sqrt(Math.Pow(newx4 - newx3, 2) + Math.Pow(newy4 - newy3, 2))).ToString() + Environment.NewLine;
            //double ab = Math.Sqrt(Math.Pow(x3 - newx3, 2) + Math.Pow(y3 - newy3, 2));
            //double bc = Math.Sqrt(Math.Pow(newx3 - newx4, 2) + Math.Pow(newy3 - newy4, 2));
            //double ac = Math.Sqrt(Math.Pow(x3 - newx4, 2) + Math.Pow(y3 - newy4, 2));
            //textBox1.Text = (Math.Acos((ab * ab + bc * bc - ac * ac) / (2 * ab * bc)) * 180 / Math.PI).ToString();

        }

        private void setb(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            float scale = float.Parse(textBox10.Text);
            Graphics gr = pictureBox1.CreateGraphics();
            double newx1 = (x2 - x1) / 2 - (y2 - y1) * Math.Sqrt(3) / 2 + x1, newy1 = (x2 - x1) * Math.Sqrt(3) / 2 + (y2 - y1) / 2 + y1;
            gr.DrawLine(new Pen(Brushes.Green), (float)newx1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)newy1 * scale, (float)x1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y1 * scale);
            gr.DrawLine(new Pen(Brushes.Green), (float)newx1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)newy1 * scale, (float)x2 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y2 * scale);
            gr.DrawLine(new Pen(Brushes.Green), (float)x1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y1 * scale, (float)x2 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y2 * scale);
            //gr.FillEllipse(Brushes.Black, 30f * (float)x1 - 2.5f + pictureBox1.Width / 2, pictureBox1.Height / 2 - 30f * (float)y1 - 2.5f, 5f, 5f);
            gr.FillEllipse(Brushes.Green, (float)(pictureBox1.Width / 2 + newx1 * scale - 3.5), (float)(pictureBox1.Height / 2 - newy1 * scale - 3.5), 7f, 7f);
            double Centrex = ((x1 * x1 + y1 * y1) * (y2 - newy1) + (x2 * x2 + y2 * y2) * (newy1 - y1) + (newy1 * newy1 + newx1 * newx1) * (y1 - y2)) / (2 * (x1 * (y2 - newy1) + x2 * (newy1 - y1) + newx1 * (y1 - y2)));
            double Centrey = ((x1 * x1 + y1 * y1) * (newx1 - x2) + (x2 * x2 + y2 * y2) * (x1 - newx1) + (newy1 * newy1 + newx1 * newx1) * (x2 - x1)) / (2 * (x1 * (y2 - newy1) + x2 * (newy1 - y1) + newx1 * (y1 - y2)));
            //gr.FillEllipse(Brushes.BlueViolet, (float)(pictureBox1.Width / 2 + Centrex * scale - 3.5), (float)(pictureBox1.Height / 2 - Centrey * scale - 3.5), 7f, 7f);
            double radius = Math.Sqrt(Math.Pow(Centrex - x1, 2) + Math.Pow(Centrey - y1, 2));
            double k = (y3 - newy1) / (x3 - newx1);
            double b = y3 - k * x3;
            double newx2 = 0, newy2 = 0;
            if (x3 - newx1 == 0)
            {
                if (Centrey + radius == newy1)
                    newy2 = Centrey - radius;
                else
                    if (Centrey - radius == newy1)
                    newy2 = Centrey + radius;
                else
                    textBox9.Text = "Ошибка при нахождении точки пересечения окружности и прямой";
                newx2 = newx1;
            }
            else
            {
                newx2 = (-2 * k * (b - Centrey) + 2 * Centrex + Math.Sqrt(Math.Pow((2 * k * (b - Centrey) - 2 * Centrex), 2) - 4 * (k * k + 1) * (Math.Pow(b - Centrey, 2) + Centrex * Centrex - radius * radius))) / (2 * (k * k + 1));
                if (Math.Round(newx2, 5) == Math.Round(newx1, 5))
                    newx2 = (-2 * k * (b - Centrey) + 2 * Centrex - Math.Sqrt(Math.Pow((2 * k * (b - Centrey) - 2 * Centrex), 2) - 4 * (k * k + 1) * (Math.Pow(b - Centrey, 2) + Centrex * Centrex - radius * radius))) / (2 * (k * k + 1));
                else
                    if (Math.Round((-2 * k * (b - Centrey) + 2 * Centrex - Math.Sqrt(Math.Pow((2 * k * (b - Centrey) - 2 * Centrex), 2) - 4 * (k * k + 1) * (Math.Pow(b - Centrey, 2) + Centrex * Centrex - radius * radius))) / (2 * (k * k + 1)), 5) != Math.Round(newx1, 5))
                    textBox9.Text = "Ошибка при нахождении точки пересечения окружности и прямой";
                newy2 = k * newx2 + b;
            }
            //gr.FillEllipse(Brushes.Black, (float)(pictureBox1.Width / 2 + Centrex * 30f - 2.5), (float)(pictureBox1.Height / 2 - Centrey * 30f - 2.5), 5f, 5f);
            //textBox1.Text = Centrex.ToString();
            //textBox2.Text = Centrey.ToString();
            gr.DrawEllipse(new Pen(Brushes.Green), (float)(pictureBox1.Width / 2 + (Centrex - radius) * scale), (float)(pictureBox1.Height / 2 - Centrey * scale - radius * scale), (float)(2 * radius * scale), (float)(2 * radius * scale));//30
            
            gr.FillEllipse(Brushes.Red, (float)(pictureBox1.Width / 2 + newx2 * scale - 3.5), (float)(pictureBox1.Height / 2 - newy2 * scale - 3.5), 7f, 7f);
            gr.DrawLine(new Pen(Brushes.Black), (float)newx2 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)newy2 * scale, (float)x1 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y1 * scale);
            gr.DrawLine(new Pen(Brushes.Black), (float)newx2 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)newy2 * scale, (float)x2 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y2 * scale);
            gr.DrawLine(new Pen(Brushes.Black), (float)newx2 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)newy2 * scale, (float)x3 * scale + pictureBox1.Width / 2, pictureBox1.Height / 2 - (float)y3 * scale);
            double setb_length = line_length;
            setb_length += Math.Sqrt(Math.Pow(x1 - newx2, 2) + Math.Pow(y1 - newy2, 2));
            setb_length += Math.Sqrt(Math.Pow(x2 - newx2, 2) + Math.Pow(y2 - newy2, 2));
            setb_length += Math.Sqrt(Math.Pow(x3 - newx2, 2) + Math.Pow(y3 - newy2, 2));
            textBox9.Text += "сумма длин дорог = " + setb_length.ToString() + Environment.NewLine;
            //textBox1.Text = (Math.Pow((2 * k * (b - Centrey) - 2 * Centrex), 2) - 4 * (k * k + 1) * (Math.Pow(b - Centrey, 2) + Centrex * Centrex - radius * radius)).ToString();
        }
    }
}
