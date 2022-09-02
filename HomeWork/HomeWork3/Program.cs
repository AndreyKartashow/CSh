namespace HelloWorld
{
    class Program
    {
        // Напишите программу, которая на вход принимает число и выдаёт, является ли число чётным (делится ли оно на два без остатка)
        static void Main(string[] args)
        {
            Console.WriteLine ("Привет, эта программа пожет тебе определить, является ли число четным или нет");
        // 1. Блок ввода входных данных
            Console.WriteLine ("Введи пожалуйста целое число");
            double number = Convert.ToInt32(Console.ReadLine());
        // 2. Блок действия
            double remainder = number % 2;  
        // 3. Блок условия                
            if (remainder == 0)
            {
                Console.WriteLine ("Число является четным");     
            }
            else 
            {
                Console.WriteLine ("Число не является четным");  
            }
        }
    }
}