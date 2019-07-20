using System;

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
                Console.WriteLine("Неверное количество аргументов.");
                RegexPatch.SendMessage();
                Console.ReadKey();
            }
        }
    }
}
