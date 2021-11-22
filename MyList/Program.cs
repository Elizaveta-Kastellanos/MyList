using System;
using System.Collections.Generic;

namespace MyList
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> lst = new MyList<int>();
            lst.Add(5);
            lst.Add(12);
            lst.Add(16);
            lst.Add(18);
            lst.Add(20);
            for(int i = 0;i<lst.Count;i++)
            {
                Console.Write($"{lst[i]} ");
            }
            Console.WriteLine();
            int[] mas = new int[] { -9, 10, 7 };

            Console.WriteLine("Method ToArray");
            mas = lst.ToArray();
            for(int i = 0;i<mas.Length;i++)
            {
                Console.Write($"{mas[i]} ");
            }
            Console.WriteLine();
            Console.WriteLine("Method the end");
        //    lst.CopyTo(mas, 3);

            
        //    for (int i = 0; i < lst.Count; i++)
        //    {
        //        Console.Write($"{lst[i]} ");
        //    }
        //    Console.WriteLine();
        //    Console.WriteLine("-------------------------");
        //    lst.RemoveAt(2);
        //    for (int i = 0; i < lst.Count; i++)
        //    {
        //        Console.Write($"{lst[i]} ");
        //    }
        //    Console.WriteLine();
        //    Console.WriteLine("--------------------------------------");

            List<int> list = new List<int>();
           
        //    bool bol = lst.Remove(12);
        //    Console.WriteLine(bol);
        //    for (int i = 0; i < lst.Count; i++)
        //    {
        //        Console.Write($"{lst[i]} ");
        //    }
        //    Console.WriteLine();
        //    Console.WriteLine("--------------------------------------");

        //    foreach (var item in lst)
        //    {
        //        Console.Write($"{lst[item]} ");
        //    }
            
            

                Console.ReadKey();
        }
    }
}
