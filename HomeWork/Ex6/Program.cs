
        // Задача 1.
        // Напишите программу, которая принимает на вход координаты точки (X и Y), 
        // причём X ≠ 0 и Y ≠ 0 и выдаёт номер четверти плоскости, в которой находится эта точка.
/*
namespace HelloWorld
{
    class Program
    {  
        static void Main(string[] args)
        {
            Console.WriteLine ("Введите целое число");
            // 1. Получаем число
            Console.WriteLine ("Введите переменную Х");
            int numberX = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine ("Введите переменную Y");
            int numberY = Convert.ToInt32(Console.ReadLine());
            // 2. проверяем числа (X ≠ 0 и Y ≠ 0)
            if (numberX > 0 & numberY > 0)
            {
                Console.WriteLine ("Точка находится в первой четверти");
            }
            else if (numberX < 0 & numberY > 0)
            {
                Console.WriteLine ("Точка находится в второй четверти");
            }
            else if (numberX < 0 & numberY < 0)
            {
                Console.WriteLine ("Точка находится в третьей четверти");
            }
            else if (numberX > 0 & numberY < 0)
            {
                Console.WriteLine ("Точка находится в четвертой четверти");
            }
            else 
            {
                Console.WriteLine ("Точка находится на пересечении четвертей");
            }
        }
    }
} */



        // Задача 2. Напишите программу, которая по заданному номеру четверти, 
        // показывает диапазон возможных координат точек в этой четверти (x и y).

namespace HelloWorld
{
    class Program
    {  
        static void Main(string[] args)
        {
            Console.WriteLine ("Введите номер четверти и мы подскажем какой диапозон могут иметь числа");
            int number = Convert.ToInt32(Console.ReadLine());
            // 2. проверяем число и выводим диапозон
            int quarter1 = 1;
            int quarter2 = 2;
            int quarter3 = 3;
            int quarter4 = 4;
            if (number == quarter1)
            {
                Console.WriteLine ("Переменные могут принимать значения X > 0 и Y > 0");
            }
            else if (number == quarter2)
            {
                Console.WriteLine ("Переменные могут принимать значения X < 0 и Y > 0");
            }
            else if (number == quarter3)
            {
                Console.WriteLine ("Переменные могут принимать значения X < 0 и Y < 0");
            }
            else if (number == quarter4)
            {
                Console.WriteLine ("Переменные могут принимать значения X > 0 и Y < 0");
            }
            else 
            {
                Console.WriteLine ("Такой четверти нет!");
            }
        }
    }
}