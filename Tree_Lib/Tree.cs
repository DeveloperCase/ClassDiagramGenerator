namespace TreeCSharp
{
    public class Tree
    {
        public Node Root { get; }

        public Tree(string name)
        {
            Root = new Node();
            Root.Name = name;
        }

        public void AddChildToRoot(string name)
        {
            Node childrenNode = new Node();
            childrenNode.Name = name;
            Root.ChildrenNodes.Add(childrenNode);
        }

        public Node Find(string name)
        {
            return Find(Root, name);
        }

        private Node Find(Node node, string name)
        {
            Node ret = null;
            if (node.Name == name) return node;
            foreach (var children in node.ChildrenNodes)
            {
                if (children.Name == name)
                {
                    return children;
                }

                if (!children.IsLeaf) ret = Find(children, name);
            }
            return ret;
        }

        public void AddLeafToFindNode(string name, string addLeaf)
        {
            Node findNode = Find(name);
            if (findNode == null) return;
            Node _leaf = new Node();
            _leaf.Name = addLeaf;
            _leaf.ParentNodes = findNode;
            findNode.ChildrenNodes.Add(_leaf);
        }
    }
}