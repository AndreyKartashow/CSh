namespace GeekBrains
{
    class Program
    {
        // Задайте массив вещественных чисел. 
        // Найдите разницу между максимальным и минимальным элементов массива.
        static void Main(string[] args)
        {
            ConsoleKeyInfo esc = new ConsoleKeyInfo();
            do
            {
                Console.WriteLine ("Эта програма поможет определить максимальное и минимальное число в случайно сгененерированного массива, а так же посчитать их разницу");
                Console.WriteLine ("Пожалуйста, введите целое число для формирования нижней границы случайной размерности массива");
                int minValyeSize = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine ("Пожалуйста, введите целое число для формирования вверхней границы случайной размерности массива");
                int maxValyeSize = Convert.ToInt32(Console.ReadLine()) + 1;
                Console.WriteLine ("Пожалуйста, введите целое число для формирования нижней границы случайных значений массива");
                int minValyeNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine ("Пожалуйста, введите целое число для формирования вверхней границы случайных значений массива");
                int maxValyeNumber = Convert.ToInt32(Console.ReadLine()) + 1;
                int[] array = NewFillRandomArray(minValyeSize, maxValyeSize, minValyeNumber, maxValyeNumber);
                PrintArray(array);
                int max = MaxNumberArray(array);
                int min = MinNumberArray(array);
                Console.WriteLine ($"Разница между максимальным и минимальным элементами массива составляет: {max - min}");
                Console.WriteLine();
                Console.WriteLine ("Нажмите клавишу <Esc> для выхода или любую другую для продолжения");
                esc = Console.ReadKey();
                Console.Clear();
            }
            while (esc.Key != ConsoleKey.Escape);

        // Метод заполнения массива случайной размерности из случайных чисел в веденом жиапозоне
            int[] NewFillRandomArray(int minValyeSize, int maxValyeSize, int minValyeNumber, int maxValyeNumber)
            {              
                int[] arrayRandom = new int [new Random().Next(minValyeSize, maxValyeSize)];
                for (int i = 0; i < arrayRandom.Length; i++)
                {
                    arrayRandom[i] = new Random().Next(minValyeNumber, maxValyeNumber);
                }
                Console.WriteLine ("Ваш случайный массив сформирован");
                return arrayRandom;
            }
            
            // Метод печати массива
            void PrintArray(int[] array)
            {       
                Console.WriteLine ("Ваш массив: ");
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write($"{array[i]} ");
                }
            }
            
            // Метод определения максимального элемента массива
            int MaxNumberArray(int[] array)
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
            // Метод определения минимального элемента массива
            int MinNumberArray(int[] array)
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
}