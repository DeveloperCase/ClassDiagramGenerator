using System;
using System.Collections.Generic;
using System.IO;
using ClassDiagramGeneratorLib.utils;

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
            string methodStatment = string.Empty;

            // TODO :: СОКРАТИТЬ КОД и разделить на методы

            bool bStart = false;
            bool bEnd = false;
            int countStart = 0;
            int countEnd = 0;
            string statment = string.Empty;

            for (int i = 0; i < list.Count; ++i)
            {
                statment += list[i];
                if (IsNotMethod(list[i]) || statment.Contains(';'))
                {
                    statment = string.Empty;
                    continue;
                }

                if (SearcheStart('(', list[i]))
                {
                    countStart += countChar('(', list[i]);
                }

                if (SearcheEnd(')', list[i]))
                {
                   countEnd += countChar(')', list[i]);
                }

                if (countStart == countEnd && countStart > 0 && countEnd > 0)
                {
                    methods.Add(statment);
                }
                else if (countStart > countEnd && countStart > 0) // Перебираем строки ищем конец метода
                {
                    while (countStart != countEnd)
                    {
                        ++i;
                        countStart += countChar('(', list[i]);
                        countEnd += countChar(')', list[i]);
                        statment += list[i];
                    }

                    if (!statment.Contains(';'))
                    {
                        methods.Add(statment);
                    }
                }

                statment = string.Empty;

                countStart = 0;
                countEnd = 0;
            }

            return methods;
        }

        public bool SearcheStart(char ch, string line)
        {
            return line.Contains(ch);
        }

        public bool NextToken()
        {
            return false;
        }

        public bool SearcheEnd(char ch, string line)
        {
            return line.Contains(ch);
        }
    }
}