namespace HelloWorld
{
    class Program
    {
        // Напишите программу, которая на вход принимает два числа и выдаёт, какое число большее, а какое меньшее. (a = 5; b = 7 -> max = 7) (a = 2 b = 10 -> max = 10) (a = -9 b = -3 -> max = -3)
        static void Main(string[] args)
        {
            Console.WriteLine ("Привет, эта программа пожет тебе сравнить 2 числа");
            Console.WriteLine ("Введи пожалуйста первое число");
            // 1. Блок ввода входных данных
            double number1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine ("Введи пожалуйста второе число");
            double number2 = Convert.ToInt32(Console.ReadLine());
            // 2. Блок сравнения
            double max = 0;
            double min = 0;
            if (number1 > number2)
            {
                max = number1;
                min = number2;
            }
            else
            {
                max = number2;
                min = number1;
            }
            Console.WriteLine ($"Наибольшее число: {max}");
            Console.WriteLine ($"Наименьшее число: {min}");
        }
    }
}
