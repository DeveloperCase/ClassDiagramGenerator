namespace TreeCSharp.Utils
{
    public class KeyWord
    {
        public static string Namespace()
        {
            return "namespace";
        }

        public static string[] Modifier()
        {
            string[] modifier = { "public", "private", "protected", "internal", "static", "sealed", "extern" };
            return modifier;
        }

        public static string[] Class()
        {
            string[] @class = { "abstract", "class", "struct", "interface", "record", "partial", "async" };
            return @class;
        }

        public static string[] Property()
        {
            string[] property = { "get", "set" ,"init"};
            return property;
        } 
        
        public static string[] Field()
        {
            string[] field = { "volatile", "readonly", "const" };
            return field;
        }

        public static string[] Method()
        {
            string[] method = { "async", "Task", "partial", "virtual", "override", "unsafe" };
            return method;
        }

        public static string Void()
        {
            return "void";
        }
        public static string Using()
        {
            return "using";
        }
    }
}