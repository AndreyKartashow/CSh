namespace HelloWorld
{
    class Program
    {
        // Напишите программу, которая на вход принимает два числа и проверяет является ли первое число квадратом второго
        static void Main(string[] args)
        {
            // 1. Получаем число №1
            Console.WriteLine ("Введите первое целое число");
            int number1 = Convert.ToInt32 (Console.ReadLine());
            // 2. Получаем число №2
            Console.WriteLine ("Введите второе целое число");
            int number2 = Convert.ToInt32 (Console.ReadLine());
            // 3. Определяем квадрат второго числа
            int SquareNumber2 = number2 * number2;
            // 4. Сравниваем первое число с квадратом второго числа
            if (number1 == SquareNumber2)
                {
                Console.WriteLine ("Первое число является квадратом второго числа");
                }
            else
            {
                Console.WriteLine ("Первое число не является квадратом второго числа");
            }
        }
    }
}