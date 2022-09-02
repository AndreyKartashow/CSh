namespace GB
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo exitOrContinueProgram = new ConsoleKeyInfo();

            while (exitOrContinueProgram.Key != ConsoleKey.Escape)
            {
                Console.WriteLine("Эта программа выводит сумму чисел в диапозоне от M до N");

                PrintSumRange();

                Console.WriteLine();
                Console.WriteLine("для выхода нажмите <Escape> или любую другую клавишу для продолжения работы в программе");
                exitOrContinueProgram = Console.ReadKey();
                Console.Clear();
            }
        }

        private static int[] InputData()
        {
            try
            {
                int[] arrayNumber = new int[2];
                Console.WriteLine("Введите пожалуйста первое целое число");
                arrayNumber[0] = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Введите пожалуйста второе целое число");
                arrayNumber[1] = Int32.Parse(Console.ReadLine());
                return arrayNumber;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Вы ввели неверные данные, попробуйте еще раз");
                return InputData();
            }
            catch (FormatException)
            {
                Console.WriteLine("Вы ввели неверные данные, попробуйте еще раз");
                return InputData();
            }
        }

        private static int[] CheckCondition(int[] array)
        {
            if (array[0] > array[1])
            {
                int max =  array[0];
                array[0] = array[1];
                array[1] = max;
            }
            return array;
        }

        public static void PrintSumRange()
        {
            int summ = 0;
            int[] range = InputData();
            range = CheckCondition(range);
            Console.Write($"\n Все числа в диапозоне от M до N : ");
            for (int i = range[0]; i <= range[1]; i++)
            {
                Console.Write($"\t{i}");
                summ += i;
            }
            Console.WriteLine($"\n Сумма чисел в диапозоне составляет: {summ}");
        }

    }
}