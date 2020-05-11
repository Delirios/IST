using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_paralelni
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int[] arr = new int[20];

            int[] arr1 = new int[10]; //перший підмасив
            int[] arr2 = new int[10]; //другий підмасив

            int max = int.MinValue;
            int max1 = int.MinValue;
            int max2 = int.MinValue;

            for (int j = 0; j < arr.Length; j++)
            {
                arr[j] = rand.Next(0, 1000);
            }


            for (int i = 0; i < arr.Length; i++)// Вивід цілого масиву
            {
               Console.WriteLine(arr[i]);
            }
            Console.WriteLine("************");


            for (int i = 0; i < arr.Length / 2; i++)
            {
                arr1[i] = arr[i];
                arr2[i] = arr[i + arr.Length / 2];

            }

            for (int i = 0; i < arr1.Length; i++)// Вивід 1 підмасиву
            {
                Console.WriteLine(arr1[i]);
            }
            Console.WriteLine("************");

            for (int i = 0; i < arr2.Length; i++)// Вивід 2 підмасиву
            {
                Console.WriteLine(arr2[i]);

            }
            Console.WriteLine("************");

            var sw = new Stopwatch();

            sw.Start();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
            }
            sw.Stop();

            Console.WriteLine("Максимальний елемент цiлого масиву:" + max);
            var ts = sw.Elapsed;
            Console.WriteLine("Чаc пошуку елемента в цiлому масивi: " + sw.Elapsed);

            Console.WriteLine("Загальний час: {0} мiлiсекунд", ts.TotalMilliseconds);
            Console.WriteLine();

            sw.Start();
            for (int i = 0; i < arr1.Length; i++)
            {
                //Console.WriteLine(arr1[i]);
                if (arr1[i] > max1)
                    max1 = arr1[i];
            }
            sw.Stop();

            Console.WriteLine("Максимальний елемент першого масиву:" + max1);
            var ts1 = sw.Elapsed;
            Console.WriteLine("Час пошуку елемента в першому пiдмасивi: " + sw.Elapsed);

            Console.WriteLine("Загальний час: {0} мiлiсекунд", ts1.TotalMilliseconds);
            Console.WriteLine();
            sw.Start();
            for (int i = 0; i < arr2.Length; i++)
            {
                //Console.WriteLine(arr2[i]);
                if (arr2[i] > max2)
                    max2 = arr2[i];
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
