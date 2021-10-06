using System.Collections.Generic;
using System.IO;

namespace ClassDiagramGeneratorLib
{
    public class Parse
    {
        public static bool CurlyBrace { get; set; }
        public static bool Parenthesis { get; set; }
        public static char semicolon = ';';
        public static char equals = '=';
        public static char emptySumbol = ' ';
        public static string[] comments = { "//", "/*", "*/" };
        public List<Field> field;
        public List<Method> method;

        public Parse()
        {
            field = new List<Field>();
            method = new List<Method>();
        }

        public static bool IsComment(string line)
        {
            if (line.Contains("//") || line.Contains("/*") || line.Contains("*/"))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Парсит данные из файла, пропуская коментарии
        /// </summary>
        /// <param name="path"> Путь к файлу</param>
        /// <returns>Список полей и методов</returns>
        public static List<string> GetFields(string path)
        {
            using var file = new StreamReader(path);
            List<string> list = new List<string>();

            string line = string.Empty;
            while ((line = file.ReadLine()) != null)
            {
                if (!IsComment(line))
                {
                    line = line.Trim();
                    if (line != "" && line != "\r")
                        list.Add(line);
                }
            }

            return list;
        }
    }
}