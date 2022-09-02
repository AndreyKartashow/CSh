namespace GB
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo exitOrContinueProgram = new ConsoleKeyInfo();

            Console.WriteLine("Эта программа предназначена для поиска конкретного элемента массива");
            Console.WriteLine("Для начала работы вам необходимо создать новый массив");
            int[,] array = NewArray();
            FileArray(array);
            PrintArray(array);

            while (exitOrContinueProgram.Key != ConsoleKey.Escape)
            {
                int[] arrayPosition = new int[2];
                Console.WriteLine("Введите номер строки, по которой хотите найти элемент");
                arrayPosition[0] = Convert.ToInt32(Console.ReadLine()) - 1;
                Console.WriteLine("Введите номер столбца, по которому хотите найти элемент");
                arrayPosition[1] = Convert.ToInt32(Console.ReadLine()) - 1;

                SearshPositionArray(array, arrayPosition); 

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
            Console.WriteLine("Введите количество рядов массива");
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
                    array[i, j] = new Random().Next(-20, 20);
                }
            }
        }

        public static void SearshPositionArray(int[,] array, int[] positionSearsh)
        {
            int[] arrayEquals = new int[2] {-1, -1};
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (positionSearsh[0] == i & positionSearsh[1] == j)
                    {
                        arrayEquals[0] = i;
                        arrayEquals[1] = j;
                    }
                }
            }
            if (arrayEquals[0] == positionSearsh[0] & arrayEquals[1] == positionSearsh[1])
            {
                int str = arrayEquals[0];
                int row = arrayEquals[1];
                Console.WriteLine($"Ваша ячейка содержит следующее значение: {array[str, row]}");
            }
            else
            {
                Console.WriteLine("Такой позиции нет");
            }
        } 

        // 2 вариант метода поиска
        public static void SearshPositionArrayVar2(int[,] array, int[] positionSearsh)
        {
            if (positionSearsh[0] < 0 & positionSearsh[0] > array.GetLength(0)-1 
            & positionSearsh[1] < 0 & positionSearsh[1] > array.GetLength(1)-1 )
            {
                Console.WriteLine("Такой позиции нет");
            }
            else
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (positionSearsh[0] == i & positionSearsh[1] == j)
                    Console.WriteLine($"Ваша ячейка содержит следующее значение: {array[i, j]}");
                }
            }      
        }

    }
}
