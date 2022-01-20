using System;
using System.IO;
using TreeCSharp;
using Convert = Converter.Convert;

namespace ClassDiagramGeneratorLib
{
    public class Parse
    {
        public static Tree tree = new Tree("root");

        //public string Path { get; }
        public string file;

        public Parse()
        {
            //Path = path;
        }

        public void ReadFile(string path)
        {
            file = string.Empty;
            using (StreamReader sr = new StreamReader(path))
            {
                file = sr.ReadToEnd();
            }
        }

        public string[] Split()
        {
            StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;
            return file.Split(new[] { '\r', '\n' }, options);
        }

        
    }
}