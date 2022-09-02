namespace HelloWorld
{
    class Program
    {
        // Напишите программу, которая на вход принимает число и выдает его квадрат
        static void Main(string[] args)
        {
            Console.WriteLine ("Введите целое число");
            // 1. Получаем число
            int number = Convert.ToInt32(Console.ReadLine());
            // 2. Умножаем число
            int square = number * number;
            // или получаем квадрат в переменной number следующим способом  "number*=number"
            // 3. Вывод результата
            Console.WriteLine ($"Квадрат числа: {square}");
        }
    }
}