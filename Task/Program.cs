﻿using System;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 3)
            {
                RegexPatch pathRegex = new RegexPatch(args[0], args[1], args[2]);
                pathRegex.GetMatсh();
            }
            else
            {
                Console.WriteLine("Неверное количество аргументов." +
                    '\n' + "В качестве аргументов командной строки приложение получает три параметра:" +
                    '\n' + "1 - Путь к папке" +
                    '\n' + "2 - Путь к файлу со списком масок регулярных выражений " +
                    '\n' + "3 - Путь к файлу результатов");
                Console.WriteLine("Для продолжения нажмите любую клавишу...");
                Console.ReadKey();
            }
        }
    }
}
