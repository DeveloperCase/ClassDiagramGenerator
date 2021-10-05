using System.Collections.Generic;
using System.IO;

namespace ClassDiagramGeneratorLib
{
    public class Parse
    {
        public static List<string> GetComment(string path)
        {
            using var file = new StreamReader(path);
            List<string> list = new List<string>();

            string line = string.Empty;
            while ((line = file.ReadLine()) != null)
            {
                if (!(line.Contains("//") || line.Contains("/*") || line.Contains("*/")))
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