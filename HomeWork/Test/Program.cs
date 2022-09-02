namespace Seminar8
{
    // Заполните спирально массив 4 на 4.
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            int[,] array = new int[6, 6];
            Decision.PrintCurrentArray(array);
            Console.WriteLine();
            Decision.FillArray(array);
            Decision.PrintCurrentArray(array);
            Console.WriteLine("\n");
        }
    }

    class Decision
    {
        public static void FillArray(int[,] array)
        {
            int digit = 0;
            int count = 0;
            int i = 0;
            int j = 0;
            int size = array.GetLength(0);
            if (size > array.GetLength(1))
                size = array.GetLength(1);
            while (count < size / 2)
            {
                while (j < array.GetLength(1) - count)
                {
                    array[i, j] = digit;
                    digit++;
                    j++;
                }
                j = array.GetLength(1) - 1 - count;
                i++;
                while (i < array.GetLength(0) - count)
                {
                    array[i, j] = digit;
                    digit++;
                    i++;
                }
                i = array.GetLength(0) - 1 - count;
                j = array.GetLength(1) - 2 - count;
                while (j >= 0 + count)
                {
                    array[i, j] = digit;
                    digit++;
                    j--;
                }
                j = 0 + count;
                if (count < size / 2 - 1)
                {
                    i = array.GetLength(0) - 2 - count;
                    while (i > 1 + count)
                    {
                        array[i, j] = digit;
                        digit++;
                        i--;
                    }
                }
                count++;
            }
        }

        private static int FindMaxSize(int[,] incomingArray)
        {
            int MaxSizeOfElement = 0;
            for (int i = 0; i < incomingArray.GetLength(0); i++)
            {
                for (int j = 0; j < incomingArray.GetLength(1); j++)
                {
                    string temp = incomingArray[i, j].ToString();
                    if (temp.Length > MaxSizeOfElement)
                        MaxSizeOfElement = temp.Length;
                }
            }
            return MaxSizeOfElement;
        }

        private static string QuantityWhitespaces(string elementOfArray, int MaxSizeOfElement)
        {
            string whitespaces = string.Empty;
            int diffOfLength = MaxSizeOfElement - elementOfArray.Length;
            for (byte i = 0; i < diffOfLength; i++)
            {
                whitespaces += " ";
            }
            return whitespaces;
        }

        public static void PrintCurrentArray(int[,] incomingArray)
        {
            int MaxSizeOfElement = FindMaxSize(incomingArray);
            for (int i = 0; i < incomingArray.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < incomingArray.GetLength(1); j++)
                {
                    string whitespaces = QuantityWhitespaces(
                        incomingArray[i, j].ToString(),
                        MaxSizeOfElement
                    );
                    Console.Write($"{whitespaces}{incomingArray[i, j].ToString()} ");
                }
            }
        }
    }
}