using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.Security.Cryptography;

namespace Пакетик
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private double[] massiv;
        private double[,] polinom;
        private double[] koefisients;
        private double[] igriks;
        private void button2_Click(object sender, EventArgs e)
        {
            string a = textBox1.Text;
            string b = textBox2.Text;
            string с = textBox3.Text;
            CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            double a_1 = double.Parse(a);
            double b_1 = double.Parse(b);
            Thread.CurrentThread.CurrentCulture = temp_culture;
            int c_1 = Convert.ToInt32(с);
            double shag = (b_1 - a_1) / (c_1 - 1);
            massiv = new double[c_1];
            for (int i = 0; i < c_1; i++)
            {
                massiv[i] = a_1 + shag * i;
            }
            label6.Visible = true;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            button1.Enabled = true;
            textBox4.Enabled = true;
            button2.Enabled = false;
            if (b_1 <= a_1)
            {
                label7.Visible = true;
                button2.Enabled = false;
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                label6.Visible = false;
                button1.Enabled = false;
                textBox4.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (massiv == null) return;
            string d = textBox4.Text;
            string b = textBox2.Text;
            string a = textBox1.Text;
            string с = textBox3.Text;
            int c_1 = Convert.ToInt32(с);
            int d_1 = Convert.ToInt32(d);
            CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            double b_1 = double.Parse(b);
            double a_1 = double.Parse(a);
            Thread.CurrentThread.CurrentCulture = temp_culture;

            double znach = 0;
            if (d_1 > c_1)
            {
                textBox5.BackColor = Color.Red;
                textBox5.Clear();
                label8.Visible = true;
            }
            if (d_1 < 1)
            {
                textBox5.BackColor = Color.Red;
                textBox5.Clear();
                label8.Visible = true;
            }
            if (d_1 >= 1)
            {
                if (d_1 <= c_1)
                {
                    textBox5.BackColor = Color.White;
                    label8.Visible = false;
                    znach = massiv[d_1 - 1];
                    textBox5.Text = znach.ToString();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox5.BackColor = Color.White;
            label6.Visible = false;
            label7.Visible = false;
            button1.Enabled = false;
            textBox4.Enabled = false;
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            button2.Enabled = true;
            label8.Visible = false;
            label10.Visible = false;
            label14.Visible = false;
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            label15.Visible = false;
            button6.Enabled = false;
            button5.Enabled = false;
            textBox6.ReadOnly = false;
            textBox11.Clear();
            textBox10.Clear();
            textBox11.Enabled = false;
            textBox12.Clear();
            textBox13.Clear();
            textBox12.Enabled = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 45 && textBox1.Text.IndexOf("-") != -1)
            {
                e.Handled = true;
                return;
            }
            if (ch == 46 && textBox1.Text.IndexOf(".") != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 45 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 45 && textBox2.Text.IndexOf("-") != -1)
            {
                e.Handled = true;
                return;
            }
            if (ch == 46 && textBox2.Text.IndexOf(".") != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 45 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string a = textBox6.Text;
            int a_1 = Convert.ToInt32(a);
            polinom = new double[a_1, a_1];
            for (int i = 0; i < polinom.GetLength(0); i++)
            {
                for (int j = 0; j < polinom.GetLength(1); j++)
                {
                    if (i == j)
                        polinom[i, j] = 1;
                    else
                        polinom[i, j] = 0;
                }
            }
            label10.Visible = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            button6.Enabled = true;
            button5.Enabled = true;
            textBox6.ReadOnly = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string a = textBox7.Text;
            string b = textBox8.Text;
            string c = textBox6.Text;
            int a_1 = Convert.ToInt32(a);
            int b_1 = Convert.ToInt32(b);
            int c_1 = Convert.ToInt32(c);
            double znach = 0;
            if (a_1 > c_1)
            {
                textBox9.BackColor = Color.Red;
                textBox9.Clear();
                label14.Visible = true;
            }
            if (a_1 < 1)
            {
                textBox9.BackColor = Color.Red;
                textBox9.Clear();
                label14.Visible = true;
            }
            if (b_1 > c_1)
            {
                textBox9.BackColor = Color.Red;
                textBox9.Clear();
                label14.Visible = true;
            }
            if (b_1 < 1)
            {
                textBox9.BackColor = Color.Red;
                textBox9.Clear();
                label14.Visible = true;
            }
            if (a_1 >= 1)
            {
                if (a_1 <= c_1)
                {
                    if (b_1 >= 1)
                    {
                        if (b_1 <= c_1)
                        {
                            znach = polinom[b_1 - 1, a_1 - 1];
                            textBox9.Text = znach.ToString();
                            textBox9.BackColor = Color.White;
                            label14.Visible = false;
                        }
                    }
                }
            }
        }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            string i = textBox6.Text;
            string j = textBox6.Text;
            string k = textBox3.Text;
            int i_1 = Convert.ToInt32(i);
            int j_1 = Convert.ToInt32(j);
            int k_1 = Convert.ToInt32(k);
            for (int str_polinom = 0; str_polinom < i_1; str_polinom++) //длина и перемножение
            {

                double sum_kvadrat = 0;

                for (int str_massiv = 0; str_massiv < k_1; str_massiv++) //длина
                {
                    double sum_znach_massiv = 0;
                    double znach_massiv = massiv[str_massiv];

                    for (int stolb_polinom = 0; stolb_polinom < j_1; stolb_polinom++) //одно значение 
                    {
                        double stepen_massiv = 0;
                        double znach_polinom = polinom[str_polinom, stolb_polinom];
                        stepen_massiv = Math.Pow(znach_massiv, stolb_polinom);
                        sum_znach_massiv += znach_polinom * stepen_massiv;

                    }

                    sum_kvadrat += Math.Pow(sum_znach_massiv, 2);
                }

                double dlina = Math.Sqrt(sum_kvadrat);

                for (int stolb_polinom = 0; stolb_polinom < j_1; stolb_polinom++)
                {
                    double tek_znach = polinom[str_polinom, stolb_polinom];
                    polinom[str_polinom, stolb_polinom] = tek_znach / dlina;
                }

                

                for(int str_sled_polinom = str_polinom+1; str_sled_polinom < i_1; str_sled_polinom++)
                {
                    double proizv_s_drugoy = 0;

                    for (int str_massiv = 0; str_massiv < k_1; str_massiv++)
                    {
                        double sum_znach_tek_massiv = 0;
                        double sum_znach_sled_massiv = 0;
                        double znach_massiv = massiv[str_massiv];

                        for (int stolb_polinom = 0; stolb_polinom < j_1; stolb_polinom++) //вычисление F1 
                        {
                            double stepen_massiv = 0;
                            double znach_polinom = polinom[str_polinom, stolb_polinom];
                            stepen_massiv = Math.Pow(znach_massiv, stolb_polinom);
                            sum_znach_tek_massiv += znach_polinom * stepen_massiv;

                        }

                        for (int stolb_polinom = 0; stolb_polinom < j_1; stolb_polinom++) //вычисление P2
                        {
                            double stepen_massiv = 0;
                            double znach_polinom = polinom[str_sled_polinom, stolb_polinom];
                            stepen_massiv = Math.Pow(znach_massiv, stolb_polinom);
                            sum_znach_sled_massiv += znach_polinom * stepen_massiv;

                        }

                        proizv_s_drugoy += sum_znach_tek_massiv * sum_znach_sled_massiv;
                    }

                    for (int stolb_polinom = 0; stolb_polinom < j_1; stolb_polinom++)
                    {
                        double tek_znach = polinom[str_sled_polinom, stolb_polinom];
                        polinom[str_sled_polinom, stolb_polinom] = tek_znach - (proizv_s_drugoy * polinom[str_polinom, stolb_polinom]);
                        double tekush_znach = polinom[str_sled_polinom, stolb_polinom];
                    }
                }
                
                
            }
            label15.Visible = true;
            button6.Enabled = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string a = textBox6.Text;
            string b = textBox3.Text;
            int a_1 = Convert.ToInt32(a);
            int b_1 = Convert.ToInt32(b);
            Random rnd = new Random();
            igriks = new double[b_1];
            for (int i = 0; i < b_1; i++)
            {
                igriks[i] = 0;
                double j = Math.Round(-10.000 + rnd.NextDouble() * (10.000 + 10.000), 3);
                igriks[i] = j;
            }
            koefisients = new double[a_1];
            for (int i = 0; i < a_1; i++)
            {
                double promej_Koef = 0;
                double summa = 0;
                for(int x = 0; x < b_1; x++)
                {
                    double znach_summa = 0;

                    for(int k = 0; k < a_1; k++)
                    {
                        double znach = polinom[i, k] * Math.Pow(massiv[x], k);
                        znach_summa += znach;
                    }

                    promej_Koef += znach_summa*igriks[x];


                }
                summa += promej_Koef;
                koefisients[i] = summa;
            }
            textBox11.Enabled = true;
            textBox12.Enabled = true;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (igriks == null) return;
            string d = textBox11.Text;
            string с = textBox3.Text;
            int c_1 = Convert.ToInt32(с);
            int d_1 = Convert.ToInt32(d);
            double znach = 0;
            if (d_1 > c_1)
            {
                textBox10.BackColor = Color.Red;
                textBox10.Clear();
                label18.Visible = true;
            }
            if (d_1 < 1)
            {
                textBox10.BackColor = Color.Red;
                textBox10.Clear();
                label18.Visible = true;
            }
            if (d_1 >= 1)
            {
                if (d_1 <= c_1)
                {
                    textBox10.BackColor = Color.White;
                    label18.Visible = false;
                    znach = igriks[d_1 - 1];
                    textBox10.Text = znach.ToString();
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (koefisients == null) return;
            string d = textBox12.Text;
            string с = textBox6.Text;
            int c_1 = Convert.ToInt32(с);
            int d_1 = Convert.ToInt32(d);
            double znach = 0;
            if (d_1 > c_1)
            {
                textBox13.BackColor = Color.Red;
                textBox13.Clear();
                label21.Visible = true;
            }
            if (d_1 < 1)
            {
                textBox13.BackColor = Color.Red;
                textBox13.Clear();
                label21.Visible = true;
            }
            if (d_1 >= 1)
            {
                if (d_1 <= c_1)
                {
                    textBox13.BackColor = Color.White;
                    label21.Visible = false;
                    znach = koefisients[d_1 - 1];
                    textBox13.Text = znach.ToString();
                }
            }
        }
    }
}