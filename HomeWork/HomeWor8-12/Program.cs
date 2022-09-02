namespace GB
{
    class Program
    {
        static void Main(string[] args)
        {
            try
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
                    + "\n 4 - показать сумму строк в массиве"
                    + "\n 5 - показать сумму столбцов в массиве"
                    + "\n 6 - показать номер строки с наибольшей суммой ее элементов в массиве"
                    + "\n 7 - показать номер столбца с наибольшей суммой его элементов в массиве"
                    + "\n 8 - показать номер строки с наименьшой суммой ее элементов в массиве"
                    + "\n 9 - показать номер столбца с наименьшой суммой его элементов в массиве"
                    + "\n 10 - показать среднее арифметическое столбцов массива"
                    + "\n 11 - отсортировать строки массива по возрастанию слева на право"
                    + "\n 12 - отсортировать колонки массива по возрастанию сверху вниз"
                    + "\n 13 - задать новый массив");

                    int action = Convert.ToInt32(Console.ReadLine());
                    switch (action)
                    {
                        case 1:
                            PrintArray(array);
                            goto Replay;

                        case 2:
                            MaxNumberArray(array);
                            break;

                        case 3:
                            MinNumberArray(array);
                            break;

                        case 4:
                            int[] summString = SummElementSring(array);
                            PrintArray(summString);
                            break;

                        case 5:
                            int[] summRow = SummElementRow(array);
                            for (int i = 0; i < summRow.Length; i++)
                            {
                                Console.Write($"\t{summRow[i]}");
                            }
                            break;

                        case 6:
                            int[] resultSummStringMax = SummElementSring(array);
                            MaxPositionLineArray(resultSummStringMax);
                            break;

                        case 7:
                            int[] resultSummRowMax = SummElementRow(array);
                            MaxPositionLineArray(resultSummRowMax);
                            break;

                        case 8:
                            int[] resultSummStringMin = SummElementSring(array);
                            MinPositionLineArray(resultSummStringMin);
                            break;

                        case 9:
                            int[] resultSummRowMin = SummElementRow(array);
                            MinPositionLineArray(resultSummRowMin);
                            break;

                        case 10:
                            AverageRowArray(array);
                            break;

                        case 11:
                            int[,] arraySortString = SortStringArray(array);
                            PrintArray(arraySortString);
                            break;

                        case 12:
                            int[,] arraySortRow = SortRowArray(array);
                            PrintArray(arraySortRow);
                            break;


                        case 13:
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
            catch (FormatException)
            {
                Console.WriteLine("Ошибка #1, вы не передали данные для программы");
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

        public static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"\t{array[i]}");
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
                        max =
                        array[i, j];
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

        public static int[,] SortStringArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int k = 0; k < array.GetLength(1); k++)
                {
                    for (int j = 0; j < array.GetLength(1) - k - 1; j++)
                    {
                        if (array[i, j] > array[i, j + 1])
                        {
                            int temp = array[i, j];
                            array[i, j] = array[i, j + 1];
                            array[i, j + 1] = temp;
                        }
                    }
                }
            }
            return array;
        }

        public static int[,] SortRowArray(int[,] array)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                for (int k = 0; k < array.GetLength(0); k++)
                {
                    for (int i = 0; i < array.GetLength(0) - k - 1; i++)
                    {
                        if (array[i, j] > array[i + 1, j])
                        {
                            int temp = array[i, j];
                            array[i, j] = array[i + 1, j];
                            array[i + 1, j] = temp;
                        }
                    }
                }
            }
            return array;
        }

        public static int[] SummElementSring(int[,] array)
        {
            Console.WriteLine();
            int[] resultSumm = new int[array.GetLength(1)];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    resultSumm[i] += array[i, j];
                }
            }
            return resultSumm;
        }

        public static int[] SummElementRow(int[,] array)
        {
            Console.WriteLine();
            int[] resultSumm = new int[array.GetLength(0)];

            for (int j = 0; j < array.GetLength(1); j++)
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    resultSumm[i] += array[i, j];
                }
            }
            return resultSumm;
        }

        public static void MaxPositionLineArray(int[] array)
        {
            Console.WriteLine();
            int max = array[0];
            int numberMaxLine = 0;
            for (int i = 0; i < array.Length; i++)
            {
                {
                    if (array[i] > max)
                    {
                        max = array[i];
                        numberMaxLine = i + (1);
                    }
                }
            }
            Console.WriteLine($"Линия {numberMaxLine} содержит суммарное значение: {max}");
        }

        public static void MinPositionLineArray(int[] array)
        {
            Console.WriteLine();
            int min = array[0];
            int numberMinLine = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[i] < min)
                    {
                        min = array[i];
                        numberMinLine = i + (1);
                    }
                }
            }
            Console.WriteLine($"Линия {numberMinLine} содержит суммарное значение: {min}");
        }

    }
}