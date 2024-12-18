using System;
using System.Linq;

namespace lab3
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введіть кількість елементів масиву (n): ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("\nПерше завдання");
            double[] array = GenerateArray(n, -7.51, 3.59);
            Console.WriteLine("Початковий масив: " + string.Join(", ", array));

            double sum = CalculateSumOfModules(array);
            Console.WriteLine("Сума модулів елементів з дробовою частиною < 0.5: " + sum);

            Console.WriteLine("\nДруге завдання");
            SortArrayAfterMinimum(array);
            Console.WriteLine("Масив після сортування елементів після мінімального: " + string.Join(", ", array));
        }

        static double[] GenerateArray(int n, double min, double max)
        {
            Random random = new Random();
            double[] array = new double[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = Math.Round(random.NextDouble() * (max - min) + min, 2);
            }
            return array;
        }

        static double CalculateSumOfModules(double[] array)
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

        static void SortArrayAfterMinimum(double[] array)
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
