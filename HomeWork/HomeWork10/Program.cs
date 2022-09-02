namespace GeekBrains
{
    class Program
    {
        // Напишите программу, которая на вход принимает число и выдает таблицу кубов от 1 до N
        static void Main(string[] args)
        {
            Console.WriteLine ("Введите целое число");
            // 1. Получаем число
            int number = Convert.ToInt32(Console.ReadLine());
            // 2. Выводим таблицу кубов в цикле 
            for (int i = 1; i < number; i++)
            Console.WriteLine($"{i} x {i} x {i} = {i*i*i}");
        }
    }
}