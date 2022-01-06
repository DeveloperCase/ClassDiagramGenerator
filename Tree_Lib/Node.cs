using System.Collections;
using System.Collections.Generic;

namespace TreeCSharp
{
    public class Node
    {
        public string Name { get; set; }
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