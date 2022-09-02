namespace HelloWorld
{
    class Program
    {
        // Напишите программу, которая на вход принимает трехзначное число и выдает его вторую цифру этого числа
        static void Main(string[] args)
        {
            Console.WriteLine("Введите целое трехзначное число");
            // 1. Получаем из консоли число в типе данных "строка"
            string str = Console.ReadLine();
            // 2. Выводим вторую цифру 
            Console.WriteLine(str [1]);
        }
    }
}