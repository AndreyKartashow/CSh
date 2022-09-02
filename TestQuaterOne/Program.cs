namespace GB
{
    class Program
    {
        public static void Main(string[] args)
        {
            ConsoleKeyInfo exitOrContinueProgram = new ConsoleKeyInfo();
            while (exitOrContinueProgram.Key != ConsoleKey.Escape)
            {
                Console.WriteLine("Эта программа из введеной строки формирует массив из строк, длина которых меньше либо равна 3 символа");
                int ConditionSearsh = 3;

                Console.WriteLine("Введите пожалуйста предложение. Разделителем слов является пробел");
                string[] str = InputDataWithConsole().Split(' ');

                string[] strSort = SortArray(str, ConditionSearsh);
                if (strSort != null)
                {
                    Console.WriteLine("Элементы, удовлетворяющие условию, найдены");
                    Print(strSort);
                }
                else
                {
                    Console.WriteLine("Элементы, удовлетворяющие условию, не найдены");
                }
            
                Console.WriteLine();
                Console.WriteLine("для выхода нажмите <Escape> или любую другую клавишу для перезапуска программы");
                exitOrContinueProgram = Console.ReadKey();
                Console.Clear();
            }

        }

        public static string? InputDataWithConsole()
        {
            string? s = Console.ReadLine();
            if (s == "")
            {
                Console.WriteLine("Вы ничего не ввели, попробуйте еще раз");
                return InputDataWithConsole();
            }
            return s;
        }

        public static void Print(string[] str)
        {
            foreach (string s in str)
            {
                Console.Write($" {s}");
            }
            Console.WriteLine();
        }

        private static int CountConditionArray(string[] str, int numberCondition)
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i].Length <= numberCondition)
                {
                    count++;
                }
            }
            return count;
        }

        private static string[] SortArray(string[] str, int numberCondition)
        {
            int count = CountConditionArray(str, numberCondition);
            string[] strSort = new string[count]; 
            if (count != 0)
            {
                for (int i = 0, j = 0; i < str.Length; i++)
                    {
                        if (str[i].Length <= numberCondition)
                        {
                            strSort[j] = str[i];
                            j++;
                        }
                    }    
                return strSort;
            }
            else
            {
                return null;
            }
        }

    }
}