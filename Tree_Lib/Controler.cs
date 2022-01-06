namespace TreeCSharp
{
    public class Controler
    {
        public static Tree tree = new Tree("root");

        public Controler()
        {
            tree.AddChildren("using");
            tree.AddChildren("namespace");
            tree.AddChildren("Modifier");
            tree.AddChildren("Class");
            tree.AddChildren("Struct");
            tree.AddChildren("Interface");
            tree.AddChildren("Fields");
            tree.AddChildren("Property");
            tree.AddChildren("Constructor");
            tree.AddChildren("Methods");
        }

        public static void Init()
        {
           
        }
    }
}