using System;
using System.Linq;
using BookStorage.GroupedModels;
using BookStorage.Extensions;


namespace ConsoleApp
{
    class lab
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine();

            DataSource data = new DataSource();
            Menu menu = new Menu(data, "Лабораторна робота №1, студент Галактіонов Максим. Група ІС-02.", "Введіть 0, щоб закінчити виконання програми");
            menu.RunMenu();
            
            Console.ReadKey();
        }
    }

}

