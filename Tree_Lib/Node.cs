using System.Collections.Generic;

namespace TreeCSharp
{
    public class Node
    { 
        public string Name { get; set; } // Имя переменной, класса , свойства , неймспейса
        public List<string> TypeName { get; set; }// хранить class namespace Field Method Constructor для понимаю что находится в ноде
        public Node ParentNodes { get; set; }
        public List<Node> ChildrenNodes { get; set; }

        public bool IsRoot => ParentNodes == null;

        public bool IsLeaf => ChildrenNodes.Count == 0;

        public Node()
        {
            Name = string.Empty;
            ChildrenNodes = new List<Node>();
        }
    }
}