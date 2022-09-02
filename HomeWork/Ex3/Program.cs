namespace HelloWorld
{
    class Program
    {
        // Напишите программу, которая будет выдавать день недели при вводе числа от 1 до 7
        static void Main(string[] args)
        {
            // 1. Вводим целое число в консоль
            Console.WriteLine ("Введите целое число от 1 до 7");
            int number = Convert.ToInt32 (Console.ReadLine());
            // 2. начинаем сравнивать введеное число с нашим диапозоном от 1 до 7
            if (number == 1)
                {
                Console.WriteLine ("mondey/понедельник");
                }
            else if (number == 2)
                {
                Console.WriteLine ("tuesday/вторник");
                }
            else if (number == 3)
                {
                Console.WriteLine ("wednesday/среда");
                }
            else if (number == 4)
                {
                Console.WriteLine ("thursday/четверг");
                }
            else if (number == 5)
                {
                Console.WriteLine ("friday/пятница");
                }
            else if (number == 6)
                {
                Console.WriteLine ("saturday/суббота");
                }
            else if (number == 7)
                {
                Console.WriteLine ("sunday/воскресенье");
                }
            else 
                {
                Console.WriteLine ("Вы ввели неверное число");
                }
        }
    }
}