using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WPF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBoxResults.Items.Clear();

            if (!int.TryParse(txtInputN.Text, out int n) || n <= 0)
            {
                MessageBox.Show("Введіть коректне число n!");
                return;
            }

            double[] array = GenerateArray(n, -7.51, 3.59);
            listBoxResults.Items.Add("Початковий масив: " + string.Join(", ", array));

            double sum = CalculateSumOfModules(array);
            listBoxResults.Items.Add("Сума модулів елементів з дробовою частиною < 0.5: " + sum);

            SortArrayAfterMinimum(array);
            listBoxResults.Items.Add("Масив після сортування: " + string.Join(", ", array));
        }

        private double[] GenerateArray(int n, double min, double max)
        {
            Random random = new Random();
            double[] array = new double[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = Math.Round(random.NextDouble() * (max - min) + min, 2);
            }
            return array;
        }

        private double CalculateSumOfModules(double[] array)
        {
            double sum = 0;
            foreach (double number in array)
            {
                if (number - Math.Floor(number) < 0.5)
                {
                    sum += Math.Abs(number);
                }
            }
            return sum;
        }

        private void SortArrayAfterMinimum(double[] array)
        {
            int minIndex = Array.IndexOf(array, array.Min());
            if (minIndex < array.Length - 1)
            {
                Array.Sort(array, minIndex + 1, array.Length - minIndex - 1);
                Array.Reverse(array, minIndex + 1, array.Length - minIndex - 1);
            }
        }
    }
}
