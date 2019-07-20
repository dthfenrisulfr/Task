using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Task
{
    class RegexPatch
    {
        private IEnumerable<string> filesCollectionPath { get; set; }
        private IEnumerable<string> regexFile { get; set; }
        private string resultFile { get; set; }

        public RegexPatch(string firstArg, string secondArg, string thirdArg)
        {
            try
            {
                filesCollectionPath = Directory.EnumerateFiles(firstArg, "*.*", SearchOption.AllDirectories);
                regexFile = File.ReadAllLines(secondArg);
                resultFile = thirdArg;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.FileName + " не существует.");
                SendMessage();
                Console.ReadKey();
                Environment.Exit(1);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message + " не существует.");
                SendMessage();
                Console.ReadKey();
                Environment.Exit(1);
            }
        }
        public void GetMatсh()
        {
            List<string> patchCollection = new List<string>();
            try
            {
                foreach (string path in filesCollectionPath)
                {
                    var file = Path.GetFileName(path);
                    foreach (string regex in regexFile)
                    {
                        Regex reg = new Regex(regex,
                        RegexOptions.IgnoreCase);

                        if (reg.IsMatch(file)) patchCollection.Add(path);
                    }
                }
            }
            catch (ArgumentException e)
            {
                Console.Clear();
                Console.WriteLine("Некорректное регулярное выражение.");
                Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message + '\n' + "Для продолжение нажмите любую клавишу...");
                Console.ReadKey();
                return;
            }

            if (patchCollection.Count != 0)
            {
                Console.WriteLine($"Пути, к файлам удовлетворяющим маске поиска, сохранены в {resultFile}.");
                patchCollection.Add(new string('-', 25));
                try
                {
                    File.AppendAllLines(resultFile, patchCollection);
                }
                catch (DirectoryNotFoundException e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message + '\n' + "Для продолжения нажмите любую клавищу...");
                    Console.ReadKey();
                    return;
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message + '\n' + "Для продолжения нажмите любую клавишу...");
                    Console.ReadKey();
                    return;
                }
            }
            else Console.WriteLine("Совпадения не найдены.");
            Console.WriteLine("Для продолжения нажмите любую клавишу...");
            Console.ReadKey();
        }

        static public void SendMessage()
        {
            Console.WriteLine('\n' + "Убедитесь в правильности ввода передаваемых аргументов." +
    '\n' + "В качестве аргументов командной строки приложение получает три параметра:" +
    '\n' + "1 - Путь к папке" +
    '\n' + "2 - Путь к файлу со списком масок регулярных выражений " +
    '\n' + "3 - Путь к файлу результатов" +
    '\n' + "Для продолжения нажмите любую клавишу...");
        }
    }
}

