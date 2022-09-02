// Задайте двумерный массив размером m×n, заполненный случайными вещественными числами
namespace HomeWork
{
    class Program
    {
        public static void Main()
        {
            ArrayNumber objectArray = new ArrayNumber();
            ConsoleKeyInfo esc = new ConsoleKeyInfo();

            Console.WriteLine("Эта программа создает массив с размерами m*n и заполняет его случайными значениями в указанном диапозоне");
            while (esc.Key != ConsoleKey.Escape)
            {
                Console.WriteLine(ArrayNumber.textAddM);
                objectArray.SizeM = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(ArrayNumber.textAddN);
                objectArray.SizeN = Convert.ToInt32(Console.ReadLine());

                int[,] arrayTask = objectArray.NewArray(objectArray.SizeM, objectArray.SizeN);

                Console.WriteLine(ArrayNumber.textLowerLineRandom);
                objectArray.lowerLineRandom = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(ArrayNumber.textUpperLineRandom);
                objectArray.upperLineRandom = Convert.ToInt32(Console.ReadLine());

                objectArray.FillArrayNumberRandom(arrayTask, objectArray.lowerLineRandom, objectArray.upperLineRandom);
                objectArray.PrintArray(arrayTask);


                Console.WriteLine("Нажмите клавишу <Esc> для выхода или любую другую для продолжения");
                esc = Console.ReadKey();
                Console.Clear();
            }
        }

    }
    public class ArrayNumber
    {
        public static string textAddM = "Введите целое число, соответствующее количеству строк массива";
        public int SizeM { get; set; }
        public static string textAddN = "Введите целое число, соответствующее количеству столбцов массива";
        public int SizeN { get; set; }
        public static string textLowerLineRandom = "Введите число, соответствующее нижней границе значений массива";
        public int lowerLineRandom;
        public static string textUpperLineRandom = "Введите число, соответствующее вверхней границе значений массива";
        public int upperLineRandom;

        public int[,] NewArray(int sizeM, int sizeN)
        {
            int[,] array = new int[sizeM, sizeN];
            return array;
        }

        public void FillArrayNumberRandom(int[,] array, int lowerLineRandom, int upperLineRandom)
        {

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = new Random().Next(lowerLineRandom, upperLineRandom + 1);
                }
            }
        }

        public void PrintArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"\t" + array[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}