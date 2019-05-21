using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    struct InfoClient
    {
        public string Name;
        public string Surname;
        public int Count;
    }

    struct ClientsList
    {
        public InfoClient[] Client;
    }
    class Bank
    {
        public string GetInfo()
        {
            string[] array = File.ReadAllLines("text.txt");
            return "";
        }
    }

    class Count
    {
        class Money
        {

        }
    }
    class Client
    {
        public string New_Acc()
        {
            ClientsList list;
            Console.WriteLine("Введите кол-во новых пользователей:");
            //list.CountOfUsers = int.Parse(Console.ReadLine());
            int CountOfUsers = int.Parse(Console.ReadLine());
            list.Client = new InfoClient[CountOfUsers];
            string userstr = "";
            for (int i = 0; i < CountOfUsers; i++)
            {
                list.Client[i] = new InfoClient
                {   

                    Name = Console.ReadLine(),
                    Surname = Console.ReadLine(),
                    Count = int.Parse(Console.ReadLine()),

                };

                userstr += $"User{i + 1}={list.Client[i].Name};{list.Client[i].Surname};{list.Client[i].Count};\n";
            }

            File.WriteAllText("text.txt", userstr);
            return "";
        }
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Вы хотите создать нового пользователя (Y)");
                string acc_yes = Console.ReadLine();
                if (acc_yes == "Y")
                {
                    Client new_acc = new Client();
                    new_acc.New_Acc();
                }
                else
                {
                    Console.WriteLine("Вы ввели неверное значение");
                }
            }
        }
    }
}
