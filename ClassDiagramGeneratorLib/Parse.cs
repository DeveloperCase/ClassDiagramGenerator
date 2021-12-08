using System;
using System.Collections.Generic;
using System.IO;
using ClassDiagramGeneratorLib.utils;

namespace ClassDiagramGeneratorLib
{
    public class Parse
    {
        public Tokens NameSpace { get; }
        public Tokens Class { get; }
        public Tokens Property { get; }
        public Tokens Constructors { get; }
        public Tokens Methods { get; }
        public Tokens Comments { get; }

        public string Path { get; set; }

        public Parse()
        {
            Methods = new Tokens();
            Class = new Tokens();
            Constructors = new Tokens();
            NameSpace = new Tokens();
            Comments = new Tokens();
            Property = new Tokens();
        }


        public List<string> GetFile()
        {
            if (Methods.IsEmpty()) return null;
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

        public void GetMethods()
        {
            if (Methods.IsEmpty()) throw new ArgumentNullException("Параметр Methods не инициализирован");
            List<string> list = GetFile();
            foreach (var line in list)
            {
                foreach (var tokenStart in Methods.Start)
                {
                    if (line.Contains(tokenStart))
                    {
                        if (line.Contains("("))
                        {
                            
                        }
                    }
                }
              
            }
            
        }
    }
}