namespace HelloWorld
{
    class Program
    {
        // Напишите программу, которая на вход принимает число (N), а на выходе показывает все чётные числа от 1 до N. (не включая N) 
        static void Main(string[] args)
        {
            Console.WriteLine ("Привет, эта программа пожет тебе найти все четные числа, расположенные от 1 до N");
        // 1. Блок ввода входных данных
            Console.WriteLine ("Введи пожалуйста целое число N");
            int numberN = Convert.ToInt32(Console.ReadLine());
        // 2. Блок действия
            int NumberCurrent = 1;
        // 3. Блок цикла  
            while (NumberCurrent < numberN)
            {
                int Remainder = NumberCurrent % 2;
                if (Remainder == 0)
                Console.Write (NumberCurrent);
                NumberCurrent ++;
            }                   
        }
    }
}