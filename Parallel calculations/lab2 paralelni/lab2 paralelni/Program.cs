using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_paralelni
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int[,] arr = new int[10, 10];

            int[,] arr1 = new int[5, 10]; //перший підмасив
            int[,] arr2 = new int[5, 10]; //другий підмасив

            int max = int.MinValue;
            int max1 = int.MinValue;
            int max2 = int.MinValue;

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rand.Next(0, 1000);
                }
            }

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + "  ");
                }
                Console.WriteLine("");

            }
            Console.WriteLine();
            //Console.ReadKey();

            for (int i = 0; i < arr.GetLength(0) / 2; i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr1[i, j] = arr[i, j];
                    arr2[i, j] = arr[i + 5, j];
                }
            }
            Console.WriteLine();
            for (int i = 0; i < arr1.GetLength(0); i++)
            {
                for (int j = 0; j < arr1.GetLength(1); j++)
                {
                    Console.Write(arr1[i, j] + "  ");
                }
                Console.WriteLine("");

            }
            Console.WriteLine();
            for (int i = 0; i < arr2.GetLength(0); i++)
            {
                for (int j = 0; j < arr2.GetLength(1); j++)
                {
                    Console.Write(arr2[i, j] + "  ");
                }
                Console.WriteLine("");

            }



            var sw = new Stopwatch();

            sw.Start();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for(int j = 0; j < arr.GetLength(1); j++) 
                if (arr[i,j] > max)
                    max = arr[i,j];
            }
            sw.Stop();

            Console.WriteLine("Максимальний елемент цiлого масиву:" + max);
            var ts = sw.Elapsed;
            Console.WriteLine("Чаc пошуку елемента в цiлому масивi: " + sw.Elapsed);

            Console.WriteLine("Загальний час: {0} мiлiсекунд", ts.TotalMilliseconds);
            Console.WriteLine();

            sw.Start();
            for (int i = 0; i < arr1.GetLength(0); i++)
            {
                for (int j = 0; j < arr1.GetLength(1); j++)
                    if (arr1[i, j] > max1)
                        max1 = arr1[i, j];
            }
            sw.Stop();

            Console.WriteLine("Максимальний елемент першого масиву:" + max1);
            var ts1 = sw.Elapsed;
            Console.WriteLine("Час пошуку елемента в першому пiдмасивi: " + sw.Elapsed);

            Console.WriteLine("Загальний час: {0} мiлiсекунд", ts1.TotalMilliseconds);
            Console.WriteLine();
            sw.Start();
            for (int i = 0; i < arr2.GetLength(0); i++)
            {
                for (int j = 0; j < arr2.GetLength(1); j++)
                    if (arr2[i, j] > max2)
                        max2 = arr2[i, j];
            }
            sw.Stop();

            Console.WriteLine("Максимальний елемент другого масиву:" + max2);
            var ts2 = sw.Elapsed;
            Console.WriteLine("Час пошуку елемента в другому пiдмасивi: " + sw.Elapsed);
            Console.WriteLine("Загальний час: {0} мiлiсекунд", ts2.TotalMilliseconds);
            Console.WriteLine();

            sw.Start();
            for (int i = 0; i <= 2; i++)
            {
                if (max1 > max2)
                    max = max1;
                else
                    max = max2;
            }
            sw.Stop();


            var ts3 = sw.Elapsed;
            Console.WriteLine("Максимальний елемент з 2 пiдмасивiв: {0}", max);

            Console.WriteLine("Час пошуку елемента в 2 пiдмасивах: " + sw.Elapsed);
            Console.WriteLine("Загальний час: {0} мiлiсекунд", ts3.TotalMilliseconds);


            Console.WriteLine();
            if (ts2 > ts1)
                Console.WriteLine("Загальний час: {0} мiлiсекунд", ts3.TotalMilliseconds + ts2.TotalMilliseconds);
            else
                Console.WriteLine("Загальний час: {0} мiлiсекунд", ts3.TotalMilliseconds + ts1.TotalMilliseconds);

            Console.ReadKey();
        
    }

    }
}
