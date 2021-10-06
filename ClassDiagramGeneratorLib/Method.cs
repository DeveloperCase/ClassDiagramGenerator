namespace ClassDiagramGeneratorLib
{
    public class Method : Declare
    {
        public string Parenthesis { get; set; }

        public string NameMethod { get; set; }

        public Method()
        {
            Parenthesis = null;
            NameMethod = null;
        }
    }
}