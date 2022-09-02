namespace HelloWorld
{
    class Program
    {
        // Напишите программу, которая на вход принимает целое число и выдает его третью цифру или сообщает что его нет
        static void Main(string[] args)
        {
            // 1. Создаем массив на 7 дней
            string[] ArrayWeek = { "Такого дня недели нет", "понедельник", "вторник", "среда", "четверг", "пятница", "суббота-выходной", "воскресенье-выходной" };
            // 2. Просим ввести число, которое будет соответсвовать дню недели
            Console.WriteLine("Введите пожалуйста число и я подскажу какой день недели ему соответсвтвует");
            int number = Convert.ToInt32(Console.ReadLine());
            // 3. В цикле производим проверку на соответсвие введеного числа из консоли и нашего элемента массива
            int index = 0;
            int size = ArrayWeek.Length;
            if (number > size | number < 0)
            {
                Console.WriteLine("Вы ввыели неверное число");
            }
            else
            {
                while (index < size)
                {
                    if (number == index)
                    {
                        Console.WriteLine(ArrayWeek[index]);
                        break;
                    }
                    index++;
                }
            }
        }
    }
}