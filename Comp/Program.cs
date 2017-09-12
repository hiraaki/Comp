using System;

namespace Comp
{
    class Program
    {
        static void Main(string[] args)
        {
            var Lex = new LexAnalyser(args[0]);
            var Analized = Lex.TokenGen();
            Analized.Add("$");
            foreach (var str in Analized)
            {
                Console.WriteLine(str);
            }
            Console.ReadLine();
        }
    }
}
