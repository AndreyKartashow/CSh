using MethodsImplementatHomeWork;

namespace ImplementationHomeWork
{
    class Task1
    {
        // Пользователь вводит с клавиатуры M чисел. 
        // Посчитайте, сколько чисел больше 0 ввёл пользователь.
        static void Main(string[] args)
        {
            ConsoleKeyInfo esc = new ConsoleKeyInfo();
            while (esc.Key != ConsoleKey.Escape)
            {
                Console.WriteLine ("Эта програма поможет посчитать количество положительных чисел");
                Console.WriteLine ("Пожалуйста, введите набор чисел через пробел");
                string[] arrayNumberString = Console.ReadLine().Split(' ');
                double[] arrayNumberDouble = MethodsTask1.ArrayStringToArrayInt(arrayNumberString);
                int result = MethodsTask1.CountPositivePositionArray(arrayNumberDouble);       
                Console.WriteLine ($"Вы ввели следующее количество положительных чисел: {result}");
                Console.WriteLine ("Нажмите клавишу <Esc> для выхода или любую другую для продолжения");
                esc = Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
