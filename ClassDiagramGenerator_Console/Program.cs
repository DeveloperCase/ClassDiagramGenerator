using System;
using ClassDiagramGeneratorLib;

namespace ClassDiagramGenerator_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Parse parse = new Parse();
            parse.Comments.AddComment("//", "/*", "*/");
            parse.Methods.AddStart("public", "private");
            parse.Methods.AddKeyWord("void", "int", "bool", "double", "float", "char", "string");
            parse.Methods.AddEnd("}");
            parse.Path = @"C:\del\1.cs";

            var temp = parse.GetFile();
            Console.WriteLine(String.Join("\n", temp));


            //var list = Parse.GetFields(@"C:\del\1.cs");
            //var list = Parse.GetFields(@"C:\Users\vyshk\RiderProjects\ClassDiagramGenerator\ClassDiagramGeneratorLib\Field.cs");

            //ClassView classView = new ClassView();
            // classView.Init(list);
            // Print(classView);
        }

        // public static void Print(ClassView classView)
        // {
        //     Console.WriteLine(classView.ClassName);
        //     foreach (var C in classView.Fields)
        //     {
        //         if (C.Type == "class" || C.Type == "struct")
        //         {
        //             Console.ForegroundColor = ConsoleColor.DarkYellow;
        //             Console.WriteLine($"{C.AccessModifier} {C.Type} {C.ClassName}");
        //             Console.ResetColor();
        //             continue;
        //         }
        //
        //         if (C.CurlyBrace != null)
        //         {
        //             Console.ForegroundColor = ConsoleColor.Magenta;
        //             Console.WriteLine(C.CurlyBrace);
        //             Console.ResetColor();
        //             continue;
        //         }
        //
        //         Console.ForegroundColor = ConsoleColor.Blue;
        //         Console.Write($@"{C.AccessModifier} ");
        //         Console.ResetColor();
        //
        //         Console.ForegroundColor = ConsoleColor.Green;
        //         Console.Write($@"{C.Type} ");
        //         Console.ResetColor();
        //
        //         Console.ForegroundColor = ConsoleColor.Yellow;
        //         Console.Write($@"{C.NameVariable} ");
        //         Console.ResetColor();
        //
        //         if (C.Get || C.Set)
        //         {
        //             Console.ForegroundColor = ConsoleColor.DarkBlue;
        //             Console.Write("{есть get; или set; метод}");
        //             Console.ResetColor();
        //         }
        //
        //         if (C.Value != null)
        //         {
        //             Console.ForegroundColor = ConsoleColor.Magenta;
        //             Console.WriteLine($@"{C.Value}");
        //             Console.ResetColor();
        //         }
        //         else Console.WriteLine();
        //     }
        // }
    }
}