using System;
using ClassDiagramGeneratorLib;

namespace ClassDiagramGenerator_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Parse parse = new Parse();
            parse.Path = @"C:\del\1.cs";

            var methods = parse.GetMethods();

            Console.WriteLine();
            //Console.WriteLine(String.Join("\n", field));
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine(String.Join("\n", methods));
        }
    }
}