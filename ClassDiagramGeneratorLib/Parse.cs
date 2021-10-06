using System.Collections.Generic;
using System.IO;

namespace ClassDiagramGeneratorLib
{
    public class Parse
    {
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