namespace GB
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo exitOrContinueProgram = new ConsoleKeyInfo();

            Console.WriteLine("Создай новый массив и посмотри на возможности данной программы");

            int[,] array = NewArray();
            FileArray(array);

            while (exitOrContinueProgram.Key != ConsoleKey.Escape)
            {
            Replay:
                Console.WriteLine();
                Console.WriteLine("Выберите действие, которое хотите совершить с массивом:"
                + "\n 1 - показать массив"
                + "\n 2 - показать наибольшее число в массиве"
                + "\n 3 - показать наименьшее число в массиве"
                + "\n 4 - показать среднее арифметическое столбцов массива"
                + "\n 5 - задать новый массив");

                int action = Convert.ToInt32(Console.ReadLine());
                switch (action)
                {
                    case 1:
                        PrintArray(array);
                        goto Replay;
                        break;

                    case 2:
                        MaxNumberArray(array);
                        break;

                    case 3:
                        MinNumberArray(array);
                        break;

                    case 4:
                        AverageRowArray(array);
                        break;

                    case 5:
                        int[,] arrayNew = NewArray();
                        FileArray(arrayNew);
                        array = arrayNew;
                        Console.Clear();
                        goto Replay;

                    default:
                        Console.WriteLine("Вы указали не верный вариант");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("для выхода нажмите <Escape> или любую другую клавишу для продолжения работы в программе");
                exitOrContinueProgram = Console.ReadKey();
                Console.Clear();
            }
        }

        public static int[,] NewArray()
        {
            Console.WriteLine("Введите количество строк массива");
            int str = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество столбцов массива");
            int row = Convert.ToInt32(Console.ReadLine());
            int[,] array = new int[str, row];
            return array;
        }

        public static void PrintArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"\t{array[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        public static void FileArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = new Random().Next(-100, 100);
                }
            }
        }

        public static void MaxNumberArray(int[,] array)
        {
            Console.WriteLine();
            int max = array[0, 0];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] > max)
                    {
                        max = array[i, j];
                    }
                }
            }
            Console.WriteLine($"Максимальный элемент массива {max}");
        }

        public static void MinNumberArray(int[,] array)
        {
            Console.WriteLine();
            int min = array[0, 0];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] < min)
                    {
                        min = array[i, j];
                    }
                }
            }
            Console.WriteLine($"Минимальный элемент массива {min}");
        }

        public static void AverageRowArray(int[,] array)
        {
            Console.WriteLine();
            for (int i = 0; i < array.GetLength(1); i++)
            {
                float summRowPosition = 0;
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    summRowPosition += array[j, i];
                }
                float result = summRowPosition / array.GetLength(0);
                Console.Write($"\t{result}");
            }
        }
    }
}