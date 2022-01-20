namespace Token_lib
{
    public static class TableSumbols
    {
        public static string COMMENTS_LINE = "//";
        public static string COMMENTS_START = "/*";
        public static string COMMENTS_END = "*/";
        public static string BODY_START = "{";
        public static string BODY_END = "}";
        public static string SEMICOLONS = ";";
        public static string METHOD_STATEMENT_START = "(";
        public static string METHOD_STATEMENT_END = ")";
        public static string USING = "using";

        public static string NAMESPACE = "namespace";

        //TODO :: массивы разбить на статические переменные 
        public static string[] MODIFIER =
            { "public", "private", "protected", "internal", "static", "sealed", "extern" };

        public static string[] CLASS =
            { "abstract", "static", "class", "struct", "interface", "record", "partial", "async" };

        public static string[] PROPERTY = { "get", "set", "init" };
        public static string[] FIELD = { "volatile", "readonly", "const" };
        public static string[] METHOD = { "async", "Task", "partial", "virtual", "override", "unsafe" };
        public static string VOID = "void";
        public static string EVENT = "event";
        public static string DELEGATE = "delegate";
        public static string[] SPACE = { " ", "\t", "\n", "\r" };
    }
}