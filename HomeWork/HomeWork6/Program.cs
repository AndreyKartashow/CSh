namespace HelloWorld
{
    class Program
    {
        // Напишите программу, которая на вход принимает целое число и выдает его третью цифру или сообщает что его нет
        static void Main(string[] args)
        {
            Console.WriteLine("Введите целое число");
            // 1. Получаем из консоли число в типе данных "строка"
            string str = Console.ReadLine();
            int size = str.Length;
            int index = 0;
            // 2. Производим проверку по третьй цифре
            if (size < 3)
                {
                    Console.WriteLine("Третьей цифры нет");
                }
            else 
                {
                    Console.WriteLine(str [2]);
                }
        }
    }
}