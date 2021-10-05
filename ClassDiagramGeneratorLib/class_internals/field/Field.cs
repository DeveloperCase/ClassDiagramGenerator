using System;

namespace ClassDiagramGeneratorLib.class_internals.field
{
    public class Field : Declare
    {
        public string NameVariable
        {
            get => Name;
            private set => Name = value;
        }

        public string Value { get; set; }
        public string SplitSumbol { get; set; }
        public bool Get { get; set; }
        public bool Set { get; set; }

        public Field() : base()
        {
            Value = null;
            SplitSumbol = null;
            AccessModifier = null;
            Get = false;
            Set = false;
        }

        private bool ThisIsClass(string line)
        {
            if (line.Contains("class") || line.Contains("struct"))
            {
                return true;
            }

            return false;
        }

        private bool ThisIsStruct(string line)
        {
            return ThisIsClass(line);
        }

        private void ParseClass(string line)
        {
            ParseAccessModifer(line);
            line = DeleteAccessModifier(line);
            var indexEnd = line.IndexOf(" ");
            Type = line.Remove(indexEnd, line.Length - indexEnd);
            ClassName = line.Remove(0, indexEnd).Trim();
        }

        private void ParseStruct(string line)
        {
            ParseClass(line);
        }

        public Field ParseField(string line)
        {
            if (ThisIsClass(line))
            {
                ParseClass(line);
                return this;
            }

            ParseAccessModifer(line);
            ParseDataType(line);
            ParseVariable(line);
            ParseValue(line);
            if (line.Contains("get")) Get = true;
            if (line.Contains("set")) Set = true;
            return this;
        }

        private bool IsSplitSumbol(string line)
        {
            if (line == string.Empty) return false;
            line = line.Trim();
            if (line == "{" || line == "}")
            {
                return true;
            }

            return false;
        }

        private void ParseAccessModifer(string line)
        {
            if (line == string.Empty) return;
            if (IsSplitSumbol(line))
            {
                SplitSumbol = line.Trim();
                return;
            }

            if (line.Length <= 7) return;
            string[] modifiers =
            {
                "public ",
                "private ",
                "protected ",
                "internal ",
                "static ",
                "readonly ",
                "abstract "
            };

            foreach (var modifier in modifiers)
            {
                if (line.Contains(modifier))
                {
                    AccessModifier += modifier;
                }
            }

            AccessModifier = AccessModifier.TrimEnd();
        }

        private string DeleteAccessModifier(string line)
        {
            if (line == string.Empty) return string.Empty;
            var modifiers = AccessModifier.Split(" ");

            foreach (var modifier in modifiers)
            {
                if (line.Contains(modifier))
                {
                    line = line.Replace(modifier, "");
                }
            }

            return line.TrimStart();
        }

        private string DeleteDataType(string line)
        {
            if (line == string.Empty) return string.Empty;
            if (line.Contains("const"))
            {
                line = line.Replace("const", "");
                line = line.TrimStart();
            }

            var indexToDel = line.IndexOf(" ");
            line = line.Remove(0, indexToDel);
            return line.TrimStart();
        }

        private string DeleteVariableName(string line)
        {
            if (line == string.Empty) return string.Empty;

            var variableStart = line.LastIndexOf("=");
            ++variableStart;
            line = line.Remove(0, variableStart);

            line = line.TrimStart();

            var variableEnd = line.IndexOf(';');
            line = line.Remove(variableEnd, line.Length - variableEnd);


            return line.TrimEnd();
        }

        private void ParseDataType(string line)
        {
            if (line == string.Empty) return;
            if (IsSplitSumbol(line))
            {
                SplitSumbol = line.Trim();
                return;
            }

            line = DeleteAccessModifier(line);

            var constSplit = "";

            if (line.Contains("const"))
            {
                Type = "const";
                constSplit = " ";
                int endConst = line.IndexOf(" ");
                line = line.Remove(0, endConst);
                line = line.TrimStart();
            }

            int splitIntoType = line.IndexOf(" ");
            Type += constSplit + line.Remove(splitIntoType, line.Length - splitIntoType);
        }

        private int EndOfLine(string line)
        {
            int endLineIndex = line.IndexOf("=");

            if (endLineIndex == -1)
            {
                endLineIndex = line.IndexOf(" ");

                if (endLineIndex == -1)
                {
                    endLineIndex = line.IndexOf(";");

                    if (endLineIndex == -1)
                    {
                        Console.WriteLine("Исключение");
                        return -1;
                    }
                }
            }

            return endLineIndex;
        }

        private void ParseVariable(string line)
        {
            if (line == string.Empty) return;
            if (IsSplitSumbol(line))
            {
                SplitSumbol = line.Trim();
                return;
            }

            line = DeleteAccessModifier(line);
            line = DeleteDataType(line);
            int splitIntoNameVariable = EndOfLine(line);
            if (splitIntoNameVariable == -1) return;
            NameVariable = line.Remove(splitIntoNameVariable, line.Length - splitIntoNameVariable).TrimEnd();
        }

        private void ParseValue(string line)
        {
            if (line == string.Empty) return;
            if (IsSplitSumbol(line))
            {
                SplitSumbol = line.Trim();
                return;
            }

            line = DeleteAccessModifier(line);
            line = DeleteDataType(line);
            if (!line.Contains("="))
            {
                Value = null;
                return;
            }

            line = DeleteVariableName(line);
            Value = line;
        }
    }
}