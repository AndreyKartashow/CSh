namespace GB
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo exitOrContinueProgram = new ConsoleKeyInfo();

            Console.WriteLine("Эта программа предназначена для перемножения элементов матриц");

            while (exitOrContinueProgram.Key != ConsoleKey.Escape)
            {
                Console.WriteLine("Для начала работы создайте первый массив");
                int[,] arrayFirst = NewArray();
                FileArray(arrayFirst);

                Console.WriteLine("Для начала работы создайте второй массив");
                int[,] arraySecond = NewArray();
                FileArray(arraySecond);

                PrintArray(arrayFirst);
                Console.WriteLine();
                PrintArray(arraySecond);

                int[,] inscribedArrayNumber = InscribedArray(arrayFirst, arraySecond);
                int[,] multiplyArrayNumber = MultiplyArrayNumber(arrayFirst, arraySecond, inscribedArrayNumber);
                Console.WriteLine();
                Console.WriteLine("Если в ячейке вы увидели значение 0, значит один из элементов равен нули или массивы разной длинны");
                PrintArray(multiplyArrayNumber);

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
        
        public static int[,] InscribedArray(int[,] arrayFirst, int[,] arraySecond)
        {
            int lenghtMultiplyArrayNumber = arrayFirst.GetLength(0);
            if (arraySecond.GetLength(0) > arrayFirst.GetLength(0))
            {
                lenghtMultiplyArrayNumber = arraySecond.GetLength(0);
            }

            int rowMultiplyArrayNumber = arrayFirst.GetLength(1);
            if (arraySecond.GetLength(1) > arrayFirst.GetLength(1))
            {
                rowMultiplyArrayNumber = arraySecond.GetLength(1);
            }

            int[,] inscribedArrayNumber = new int[lenghtMultiplyArrayNumber, rowMultiplyArrayNumber];
            return inscribedArrayNumber;
        }

        public static int[,] MultiplyArrayNumber(int[,] arrayFirst, int[,] arraySecond, int[,] multiplyArrayNumber)
        {          
            for (int i = 0; i < multiplyArrayNumber.GetLength(0); i++)
            {
                for (int j = 0; j < multiplyArrayNumber.GetLength(1); j++)
                {
                    if (i < arrayFirst.GetLength(0) && i < arraySecond.GetLength(0) && j < arrayFirst.GetLength(1) && j < arraySecond.GetLength(1))
                    {
                        multiplyArrayNumber[i, j] = arrayFirst[i, j] * arraySecond[i, j];
                    }
                    else
                    {
                        multiplyArrayNumber[i, j] = 0;
                    }
                }
            }
            return multiplyArrayNumber;
        }

    }
}