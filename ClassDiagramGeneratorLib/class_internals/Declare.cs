using System;

namespace ClassDiagramGeneratorLib.class_internals
{
    public abstract class Declare
    {
        public string ClassName { get; set; }
        public string Type { get; set; }
        public string AccessModifier { get; set; }
        protected string Name { get; set; }

        protected Declare()
        {
            Type = null;
            ClassName = null;
            AccessModifier = null;
            Name = null;
        }
    }
}