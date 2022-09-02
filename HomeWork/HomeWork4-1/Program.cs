namespace GeekBrains
{
    class Program
    {
        // Напишите программу, которая на вход принимает два числа и выдает первое число в степени второго
        static void Main(string[] args)
        {
            Console.WriteLine ("Эта программа предназначенна для возвения числа в степень");
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            do
            {
                Console.WriteLine ("Введите число, которое хотите возвести в степень");
                double number1 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine ("Введите натуральную степень числа");
                double number2 = Convert.ToInt32(Console.ReadLine());
                double result = NumberToPower(number1, number2);
                Console.WriteLine($"{number1} ^ {number2} = {result}"); 
                Console.WriteLine ("Для выхода из программы зажмите клавиши <Esc>");  
                cki = Console.ReadKey();
                Console.Clear();
            }
            while (cki.Key != ConsoleKey.Escape);
        }

        // Метод возведения числа в степень
        static double NumberToPower (double number1, double number2)
        {
            double result = number1;
            for (int i = 1; i < number2; i++)
            {
                result = result * number1;
            }
            return result; 
        }
    }
}