using System.Collections.Generic;

namespace ClassDiagramGeneratorLib
{
    public class ClassView
    {
        public string ClassName { get; set; }
        public List<Field> Fields { get; set; }
        // public List<Method> Methods { get; set; }
        // public string Constructor { get; set; }
        // public string Destructor { get; set; }

        /// <summary>
        /// Инициализация ClassView
        /// </summary> 
        /// <param name="list"></param>
        /// list хранит в себе все поля класса построчно!
        public void Init(List<string> list)
        {
            List<Field> fields = new List<Field>();
            foreach (var L in list)
            {
                Field temp = new Field();
                temp.ParseField(L);
                fields.Add(temp);
            }
            ClassName = fields[0].ClassName;
            Fields = fields;
        }
    }
}