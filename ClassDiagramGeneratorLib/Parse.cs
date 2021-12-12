using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace ClassDiagramGeneratorLib
{
    public class Parse
    {
        public string Path { get; set; }
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
            List<string> listKeyWord = new List<string>();
            listKeyWord.Add(";");
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

        public int countChar(char ch, string line)
        {
            int count = 0;

            foreach (var index in line)
            {
                if (count > 1)
                {
                    break;
                }

                if (index == ch)
                {
                    ++count;
                }
            }

            return count;
        }


        public List<string> GetMethods()
        {
            List<string> methods = new List<string>();
            List<string> list = GetBinaryFile();

            int countStart = 0;
            int countEnd = 0;
            string methodStatment = string.Empty;

            int i = 0;

            for (; i < list.Count; ++i)
            {
                if (IsNotMethod(list[i]) || methodStatment.Contains(';'))
                {
                    methodStatment = string.Empty;
                    continue;
                }

                countStart += countChar('(', list[i]);
                countEnd += countChar(')', list[i]);

                if (countStart == countEnd && countStart > 0 && countEnd > 0)
                {
                    var (method, index) = SearcheMethod(list, i); // Перебираем строки ищем конец method statment
                    methodStatment = method;
                    i = index;
                }
                else if (countStart > countEnd && countStart > 0)
                {
                    var (method, index) = SearcheMethod(list, i); // Перебираем строки ищем конец method statment
                    methodStatment = method;
                    i = index;
                }

                if (methodStatment != string.Empty)
                {
                    methods.Add(methodStatment);
                }

                methodStatment = string.Empty;
                countStart = 0;
                countEnd = 0;
            }

            return methods;
        }

        private Tuple<string, int> SearcheMethod(List<string> list, int i)
        {
            List<string> methods = new List<string>();
            bool addStatment = true;

            string method = list[i];

            while (!list[i].Contains("{") && i < list.Count)
            {
                ++i;
                if (list[i].Contains("}"))
                {
                    addStatment = false;
                    break;
                }

                method += list[i];
            }

            if (!method.Contains(';') && addStatment)
            {
                return Tuple.Create(method, i); // кортежи. Метод найден
            }

            return Tuple.Create(string.Empty, i); // кортежи. Метод не найден
        }
    }
}