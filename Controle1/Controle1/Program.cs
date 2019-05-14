using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle1
{
    struct City
    {
        public string Name;
        public int Population;
        public int Area;
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Please input value");
            //string input = Console.ReadLine();
            string input = $"Kharkiv=1431000,350;Kiev=2804000,839;Las Vegas=603400,352";
            int counter = 1;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ';')//если находим ; то счётчик слов добавляем
                {
                    counter++;
                }
            }
            City[] cities = new City[counter];//Создаём массив для хранения информации о городах в виде строк в ячейках массива
            int indexCity = 0;
            string word = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ';')
                {
                    cities[indexCity].Area = int.Parse(word);
                    indexCity++;
                    word = "";
                }
                else if (input[i] == '=')
                {
                    cities[indexCity].Name = word;
                    word = "";
                }
                else if (input[i] == ',')
                {
                    cities[indexCity].Population = int.Parse(word);
                    word = "";
                }
                else
                    word += input[i];
            }
            cities[indexCity].Area = int.Parse(word);//что бы не потерять последнее значение площади
            indexCity = 0;
            int MaxPopulIndex = 0;//создаём переменную для сравнения максимального значения кол-ва людей
            for (int i = 0; i < cities.Length; i++)
            {
                if (cities[i].Population > cities[MaxPopulIndex].Population)
                {
                    MaxPopulIndex = i;
                }
            }
            Console.WriteLine($"Most populated city: {cities[MaxPopulIndex].Name} ({cities[MaxPopulIndex].Population} people)");

            int temp = 0;//Переменная для сравнения длинны
            int MaxLenghtIndex = 0;
            for (int i = 0; i < counter; i++)
            {
                if (temp < cities[i].Name.Length)
                {
                    temp = cities[i].Name.Length;
                    MaxLenghtIndex = i;
                }
            }
            Console.WriteLine($"Longest name: {cities[MaxLenghtIndex].Name} ({temp} letters)");
            Console.WriteLine($"Density:");
            for (int i = 0; i < counter; i++)
            {
                Console.WriteLine($"{cities[i].Name} - {(double)cities[i].Population / (double)cities[i].Area}"); //Int'овые значения
            }
        }
    }
}
