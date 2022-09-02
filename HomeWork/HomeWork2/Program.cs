namespace HelloWorld
{
    class Program
    {
        // Напишите программу, которая на вход принимает три числа и выдаёт, какое число большее, а какое меньшее. (a = 5; b = 7 -> max = 7) (a = 2 b = 10 -> max = 10) (a = -9 b = -3 -> max = -3)
        static void Main(string[] args)
        {
            Console.WriteLine ("Привет, эта программа пожет тебе сравнить 3 числа и найти min/max");
        // 1. Блок ввода входных данных
            Console.WriteLine ("Введи пожалуйста первое число");
            double number1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine ("Введи пожалуйста второе число");
            double number2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine ("Введи пожалуйста третье число");
            double number3 = Convert.ToInt32(Console.ReadLine());
        // 2. Блок сравнения
            double max = number1;   
            double min = number2;                
            if (number2 > number1)
            {
                max = number2;      
                min = number1;      
            }
            if (number3 > max)
            {
                max = number3;
            }
            if (number3 < min)
            {
                min = number3;
            }
            Console.WriteLine ($"Наибольшее число: {max}");
            Console.WriteLine ($"Наименьшее число: {min}");
        }
    }
}