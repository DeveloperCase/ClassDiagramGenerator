using System;
using System.IO;
using TreeCSharp;

namespace ClassDiagramGeneratorLib
{
    public class Parse
    {
        private static readonly Tree _tree = new Tree("root");
        public string Path { get; }

        public string[] File = new string[] { };

        public Parse(string path)
        {
            Path = path;
        }

        public void ReadFile()
        {
            string file = string.Empty;
            using (StreamReader sr = new StreamReader(Path))
            {
                file = sr.ReadToEnd();
            }
            
            StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;
            File = file.Split(new[] { '\r', '\n' }, options);
        }
    }
}