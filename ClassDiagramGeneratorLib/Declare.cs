
namespace ClassDiagramGeneratorLib
{
    public abstract class Declare
    {
        public string ClassName { get; set; }
        public string Type { get; set; }
        public string AccessModifier { get; set; }

        protected Declare()
        {
            Type = null;
            ClassName = null;
            AccessModifier = null;
        }
    }
}