using System.Collections.Generic;
using System.Dynamic;

namespace ClassDiagramGeneratorLib.utils
{
    public class Tokens
    {
        public List<string> Start { get; set; }
        public List<string> KeyWord { get; set; }
        public List<string> Comment { get; set; }
        public List<string> End { get; set; }

        public Tokens()
        {
            Start = new List<string>();
            KeyWord = new List<string>();
            End = new List<string>();
            Comment = new List<string>();
        }

        public void AddComment(params string[] comment)
        {
            foreach (var token in comment)
            {
                Comment.Add(token);
            }
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
                KeyWord.Add(token);
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