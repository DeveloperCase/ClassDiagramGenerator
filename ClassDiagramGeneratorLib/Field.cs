namespace ClassDiagramGeneratorLib
{
    public class Field
    {
       // public string ClassName { get; set; }
        public string Type { get; set; }
        public string AccessModifier { get; set; }
        public string NameVariable { get; set; }
        public string Value { get; set; }
        public bool Get { get; set; }
        public bool Set { get; set; }

        public Field()
        {
            //ClassName = null;
            Type = null;
            AccessModifier = null;
            NameVariable = null;
            Value = null;
            Get = false;
            Set = false;
        }
    }
}