using System.Collections.Generic;
using System.Dynamic;

namespace ClassDiagramGeneratorLib.utils
{
    public class Tokens
    {
        public List<string> Start { get; set; }
        public List<string> KeyWords { get; set; }
        public List<string> End { get; set; }

        public Tokens()
        {
            Start = new List<string>();
            KeyWords = new List<string>();
            End = new List<string>();
        }

        public void AddStart(params string[] start)
        {
            foreach (var token in start)
            {
                Start.Add(token);
            }
        }

        public void AddKeyWord(params string[] keyWord)
        {
            foreach (var token in keyWord)
            {
                KeyWords.Add(token);
            }
        }

        public void AddEnd(params string[] end)
        {
            foreach (var token in end)
            {
                End.Add(token);
            }
        }

        public bool IsEmpty()
        {
            if (Start.Count == 0 || End.Count == 0) return true;
            return false;
        }
    }
}