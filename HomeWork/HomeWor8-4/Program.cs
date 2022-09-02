namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество строк уникального массива");
            int str = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество столбцов уникального массива");
            int row = Convert.ToInt32(Console.ReadLine());
            int sizeList = str * row;
            List<int> listNumber = new List<int>();           

            while (listNumber.Count != sizeList)
            {
                listNumber.Add(new Random().Next(1, sizeList + 1));
                listNumber = listNumber.Distinct().ToList();
                PrintList(listNumber);
            }

            int [,] arrayUnic = new int[str,row];
            int k = 0;
            for (int i = 1; i <= arrayUnic.GetLength(0); i++)
            {
                for (int j = 1; j <= arrayUnic.GetLength(1); j++)
                {                  
                    arrayUnic[i - 1, j - 1] = listNumber[k];    
                    k++;                
                }
            }

            Console.WriteLine();
            PrintArray(arrayUnic);
            
            /* // Зеркалит значения массива по диагонали
             for (int i = 1; i <= arrayUnic.GetLength(0); i++)
            {
                for (int j = 1; j <= arrayUnic.GetLength(1); j++)
                {
                    int k = (i * j) - 1;
                    arrayUnic[i - 1, j - 1] = listNumber[k];
                }
            }  */
        }

        static void PrintList(List<int> collection)
        {
            foreach (int position in collection)
                {
                    Console.Write($"\t {position}");
                }
                Console.WriteLine();
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

    }
}



