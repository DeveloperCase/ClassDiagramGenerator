using System;
using System.Collections.Generic;
using System.IO;
using ClassDiagramGeneratorLib.utils;

namespace ClassDiagramGeneratorLib
{
    public class Parse
    {
        public string Path { get; set; }
        public const string START = "{";
        public const string END = "}";
        public List<string> File { get; set; }

        public Parse()
        {
            File = new List<string>();
        }

        private List<string> GetFile()
        {
            using var file = new StreamReader(Path);
            List<string> list = new List<string>();
            string line = string.Empty;
            while ((line = file.ReadLine()) != null)
            {
                line = line.Trim();
                if (line != "" && line != "\r")
                {
                    list.Add(line);
                }
            }

            return list;
        }

        private List<string> GetBinaryFile()
        {
            if (File.Count == 0)
            {
                File = GetFile();
            }

            return File;
        }

        public bool IsNotMethod(string line)
        {
            // TODO :: добавить еще ключевых слов в котрых используется ()
            // IS METHOD
            List<string> listKeyWord = new List<string>();
            listKeyWord.Add("foreach");
            listKeyWord.Add("for");
            listKeyWord.Add("else");
            listKeyWord.Add("fix");
            listKeyWord.Add("throw");
            listKeyWord.Add("using");
            listKeyWord.Add("switch");
            listKeyWord.Add("while");
            listKeyWord.Add("if");
            listKeyWord.Add("catch");

            for (int i = 0; i < listKeyWord.Count; ++i)
            {
                if (line.Contains(listKeyWord[i]))
                    return true;
            }

            return false;
        }

        public int countChar(char symbol, string line)
        {
            int count = 0;

            //////////////  Проверяем если в статменте две скобки ( ( , то это не метод
            foreach (var c in line)
            {
                if (count > 1)
                {
                    break;
                }

                if (c == '(')
                {
                    ++count;
                }
            }

            //////////
            return count;
        }

        public List<string> GetMethods()
        {
            List<string> methods = new List<string>();
            List<string> file = GetBinaryFile();
            string methodStatment = string.Empty;
            int countStartToken = 0;


            // TODO :: 1. Найти START_TOKEN ("(")


            foreach (var line in file)
            {
                if (IsNotMethod(line))
                {
                    
                }
            }

            return methods;
        }

        public bool SearcheStart(char ch)
        {
            return false;
        }

        public bool SearcheEnd(char ch)
        {
            return false;
        }
    }
}