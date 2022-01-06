namespace TreeCSharp.Utils
{
    public class Symbols 
    {
        public static string[] Comments()
        {
            string[] comments = { "//", "/*", "*/" };
            return comments;
        }

        public static string StartBlock()
        {
            string startSymbol = "{";
            return startSymbol;
        } 
        public static string EndBlock()
        {
            string endSymbol = "}";
            return endSymbol;
        }
        
        public static string StartRoundBracket()
        {
            string start = "(";
            return start;
        }
        
        public static string EndRoundBracket()
        {
            string start = ")";
            return start;
        }
    }
}