using System.Collections.Generic;
using ClassDiagramGeneratorLib.class_internals.field;

namespace ClassDiagramGeneratorLib
{
    public class ClassView
    {
        public string ClassName { get; set; }

        public List<Field> Fields { get; set; }
        // public List<Method> Methods { get; set; }
        // public string Constructor { get; set; }
        // public string Destructor { get; set; }

        public void Init(List<string> list)
        {
            List<Field> fields = new List<Field>();
            foreach (var L in list)
            {
                Field temp = new Field();
                temp.ParseField(L);
                fields.Add(temp);
            }
            Fields = fields;
        }
    }
}