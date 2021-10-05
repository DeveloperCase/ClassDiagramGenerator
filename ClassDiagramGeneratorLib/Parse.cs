using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace ClassDiagramGeneratorLib
{
    public class Parse
    {
        public static List<string> ReadFile(string path)
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