namespace GB
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo exitOrContinueProgram = new ConsoleKeyInfo();

            while (exitOrContinueProgram.Key != ConsoleKey.Escape)
            {
                Console.WriteLine("Эта программа выводит значение функции Аккермана для целых чисел N и M");

                uint[] arrayData = InputDataWithConsole();
                uint resultAkkerman = FunctionAkkerman(arrayData[0], arrayData[1]);
                Console.WriteLine($"\n Значение функции Аккермана для числа N({arrayData[0]}) и N({arrayData[1]}) = {resultAkkerman}");

                Console.WriteLine();
                Console.WriteLine("для выхода нажмите <Escape> или любую другую клавишу для продолжения работы в программе");
                exitOrContinueProgram = Console.ReadKey();
                Console.Clear();
            }
        }

        public static uint[] InputDataWithConsole()
        {
            try
            {
                uint[] arrayNumber = new uint[2];
                Console.WriteLine("Введите пожалуйста первое целое число");
                arrayNumber[0] = uint.Parse(Console.ReadLine());
                Console.WriteLine("Введите пожалуйста второе целое число");
                arrayNumber[1] = UInt32.Parse(Console.ReadLine());
                return arrayNumber;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Вы ввели неверные данные, попробуйте еще раз");
                return InputDataWithConsole();
            }
            catch (FormatException)
            {
                Console.WriteLine("Вы ввели неверные данные, попробуйте еще раз");
                return InputDataWithConsole();
            }
        }

        public static uint FunctionAkkerman(uint numberN, uint numberM)
        {

            if (numberN == 0)
            {
                return numberM + 1;
            }
            else if ((numberN != 0) && (numberM == 0))
            {
                return FunctionAkkerman(numberN - 1, 1);
            }
            else
            {
                return FunctionAkkerman(numberN - 1, FunctionAkkerman(numberN, numberM - 1));
            }

        }

    }
}