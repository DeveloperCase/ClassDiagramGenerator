namespace TreeCSharp
{
    public class Tree
    {
        public string Name { get; set; }
        public Node Root { get; }

        public Tree(string name)
        {
            Root = new Node();
            Root.Name = name;
        }

        public void AddChild(string name)
        {
            Node node = new Node();
            node.Name = name;
            Root.ChildrenNodes.Add(node);
        }

        public Node FindAll(string name)
        {
            return FindAll(Root, name);
        }

        private Node FindAll(Node node, string name)
        {
            Node ret = new Node();
            if (node.Name == name) return node;
            foreach (var children in node.ChildrenNodes)
            {
                if (children.Name == name)
                {
                    ret = children;
                    return ret;
                }

                if (!children.IsLeaf) ret = FindAll(children, name);
            }

            return ret;
        }

        public void AddLeafToNode(string name, string leaf)
        {
            Node node = new Node();
            node.Name = leaf;
            Node findNode = FindAll(name);
            findNode.ChildrenNodes.Add(node);
        }
    }
}