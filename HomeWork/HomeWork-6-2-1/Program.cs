namespace ImplementationHomeWork
{
    class Task1
    {
        // Напишите программу, которая найдёт точку пересечения двух прямых, заданных уравнениями 
        // y = k1 * x + b1, y = k2 * x + b2.
        // значения b1, k1, b2 и k2 задаются пользователем.
        static void Main(string[] args)
        {
            ConsoleKeyInfo esc = new ConsoleKeyInfo();
            while (esc.Key != ConsoleKey.Escape)
            {
                Console.WriteLine ("Эта програма поможет определить точку пересечения двух прямых в плоскости, заданных функциями типа: y = k * x + b");

                Console.WriteLine ("Пожалуйста, введите параметр функции <k1>");
                double k1 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine ("Пожалуйста, введите параметр функции <b1>");
                double b1 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine ("Пожалуйста, введите параметр функции <k2>");
                double k2 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine ("Пожалуйста, введите параметр функции <b2>");
                double b2 = Convert.ToDouble(Console.ReadLine());

                if (k1 != k2)
                {
                    double[] result = EqualityFunctionLine(k1, b1, k2, b2);
                    Console.WriteLine($"Линии пересекаются в точке X ({result[0]}) и в точке Y ({result[1]})");
                    // или две строчки можно заменить на Console.WriteLine($"Линии пересекаются в точках {EqualityFunctionLine(k1, b1, k2, b2)}");
                }
                else
                {
                    Console.WriteLine ("Линии с заданными параметрами не пересекаются");
                }
                Console.WriteLine ("Нажмите клавишу <Esc> для выхода или любую другую для продолжения");
                esc = Console.ReadKey();
                Console.Clear();
            }
        }
            // y = k * x + b
            // k1 * x + b1 = k2 * x + b2
            // b1 - b2 = (k2 - k1) * x
            // (b1 - b2) / (k2 - k1) = x
        static double[] EqualityFunctionLine(double k1, double b1, double k2, double b2)
        {
            double argumentFunctionX = (b1 - b2) / (k2 - k1);
            double argumentFunctionY = k1 * argumentFunctionX + b1;
            double[] equalityFunction = {argumentFunctionX, argumentFunctionY};
            return equalityFunction;
        }
    }
}
