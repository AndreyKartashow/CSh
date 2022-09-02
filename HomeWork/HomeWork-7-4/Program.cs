namespace GB
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo exitOrContinueProgram = new ConsoleKeyInfo();

            int[] array = NewArray();
            FileArray(array);

            while (exitOrContinueProgram.Key != ConsoleKey.Escape)
            {
            Replay:
                Console.WriteLine("Выберите действие, которое хотите совершить с массивом");
                Console.WriteLine("1 - показать массив");
                Console.WriteLine("2 - показать наибольшее число в массиве");
                Console.WriteLine("3 - показать наименьшее число в массиве");
                Console.WriteLine("4 - задать новый массив");

                int action = Convert.ToInt32(Console.ReadLine());
                switch (action)
                {
                    case 1:
                        PrintArray(array);
                        break;

                    case 2:
                        Console.WriteLine(MaxNumberArray(array));
                        break;

                    case 3:
                        Console.WriteLine(MinNumberArray(array));
                        break;

                    case 4:
                        int[] arrayNew = NewArray();
                        FileArray(arrayNew);
                        array = arrayNew;
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

        public static int[] NewArray()
        {
            Console.WriteLine("Введите размерность массива");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[size];
            return array;
        }

        public static void PrintArray(int[] array)
        {
            for (int index = 0; index < array.Length; index++)
            {
                Console.Write($"{array[index]} ");
            }
        }

        public static void FileArray(int[] array)
        {
            int count = array.Length;
            int index = 0;
            while (index < count)
            {
                array[index] = new Random().Next(0, 10);
                index++;
            }
        }

        public static int MaxNumberArray(int[] array)
        {
            Console.WriteLine();
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            Console.WriteLine($"Максимальный элемент массива {max}");
            return max;
        }


        public static int MinNumberArray(int[] array)
        {
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }
            Console.WriteLine($"Минимальный элемент массива {min}");
            return min;
        }
    }
}