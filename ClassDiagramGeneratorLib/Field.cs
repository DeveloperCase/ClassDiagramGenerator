using System;

namespace ClassDiagramGeneratorLib
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

        /// <summary>
        /// Парсинг полей
        /// </summary>
        /// <param name="line">  содержи в себе одну строчку с полем класса</param>
        /// <returns> Возвращает себя с проинициализированными полями для вывода или записи в ClassView</returns>
        public Field ParseField(string line)
        {
            if (ThisIsClass(line)) // если мы нашли класс или структуру
            {
                ParseClass(line);  // то парсим это как класс и инициализирум поля ClassName
                return this;
            }

            ParseAccessModifer(line); // Парсим модификаторы
            ParseDataType(line);      // Парсим тип данных
            ParseVariable(line);      // Парсим переменную
            ParseValue(line);         // Парсим значение если оно есть
            if (line.Contains("get")) Get = true;  // если стока содержит в себе get то инициализируем Get поле
            if (line.Contains("set")) Set = true;  // если стока в себе set то инициализируем Get поле
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

        /// <summary>
        /// Удаляем модификаторы из строки
        /// </summary>
        /// <param name="line"> accessModifier type variableName = value;</param>
        /// <returns>Возвращает type variablename = value;</returns>
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

        /// <summary>
        /// Удаляем тип данных из строки
        /// </summary>
        /// <param name="line"> type variableName = value;</param>
        /// <returns>Возвращает variablename = value;</returns>
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

        /// <summary>
        /// Удаляем имя переменной из строки
        /// </summary>
        /// <param name="line"> variableName = value;</param>
        /// <returns>Возвращает value;</returns>
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

        /// <summary>
        /// Конец строки
        /// </summary>
        /// <param name="line"> передаем значение </param>
        /// <returns>Возвращет найденный конец строки
        /// </returns>
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