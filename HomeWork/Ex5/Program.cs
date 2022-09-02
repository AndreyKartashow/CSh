namespace HelloWorld
{
    class Program
    {
        // Напишите программу, которая на вход принимает трехзначное число из консоли и выдает двузначное число, исключая средний элемент
        static void Main(string[] args)
        {
            Console.WriteLine("Введите целое трехзначное число");
            // 1. Получаем число в типе данных "строка"
            string? str = Console.ReadLine();
            // 2. Переводим полученную строку в массив из символов и заполняем его
            char[] ar = str.ToCharArray();
            // 3. создание нового массива и его заполнение
            char[] ArrayChar = new char[2];
            ArrayChar[0] = ar[0];
            ArrayChar[1] = ar[2];
            // 4. Вывод результата
            Console.WriteLine(ArrayChar);
        }
    }
}