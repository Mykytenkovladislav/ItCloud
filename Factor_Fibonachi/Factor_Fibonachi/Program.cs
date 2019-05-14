using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factor_Fibonachi
{
    class Factor
    {
        private int V;

        public Factor(int v)
        {
            if (v > 0)
                V = v;
            else
                Console.WriteLine("Ведённое значение меньше нуля.");
        }
        public int Factorial(int v)
        {
            if (v == 0)
            {
                return 1;
            }
            else
            {
                return v * Factorial(v - 1);
            }
        }

        public int Fibonachi(int v)
        {
            if (v == 0)
                return 0;
            if (v == 1)
                return 1;
            else
                return Fibonachi(v - 1) + Fibonachi(v - 2);

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Введите значение для вычисления факториала:");
            int x = int.Parse(Console.ReadLine());
            Factor a = new Factor(x);
            Console.WriteLine(a.Fibonachi(x));
        }
    }
}
