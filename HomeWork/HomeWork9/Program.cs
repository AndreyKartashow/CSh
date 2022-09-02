namespace GB
{
    class Program
    {
        // Напишите программу, которая принимает на вход координаты двух точек 
        // и находит расстояние между ними в 3D пространстве.
        static void Main(string[] args)
        {
            Console.WriteLine ("Введите координату X точки А");
            double Xa = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine ("Введите координату Y точки А");
            double Ya = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine ("Введите координату Z точки А");
            double Za = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine ("Введите координату X точки B");
            double Xb = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine ("Введите координату Y точки B");
            double Yb = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine ("Введите координату Z точки B");
            double Zb = Convert.ToDouble(Console.ReadLine());
            // 1. Получаем число
            double length = Math.Sqrt((Xb-Xa)*(Xb-Xa)+(Yb-Ya)*(Yb-Ya)+(Zb-Za)*(Zb-Za));
            Console.WriteLine ($"Расстояние между точками: {length}");
        }
    }
}



