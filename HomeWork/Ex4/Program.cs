namespace HelloWorld
{
    class Program
    {
        // Напишите программу, которая будет генерировать массив, заполнять его рандомными числами от 0 до 100 и печатать его в консоль и следом показывать максималтное число
        static void Main(string[] args)
        {
            // Метод заполнения массива рандомными числами
            void FileArray (int[] coll)
            {
                int count = coll.Length;
                int index = 0;
                while (index < count)
                {
                    coll[index] = new Random().Next(1,100);
                    index ++;
                }
            }   
            // Метод печати массива 
            void PrintArray (int[] ArrayWrite)
            {
                int length = ArrayWrite.Length;
                int position = 0;
                while (position < length)
                {
                    Console.Write ($"{ArrayWrite [position]} ");
                    position ++;
                }
            }   
            // Метод нахождения максимального числа в массиве
            int Max (int[] ArrayMax)
            {
                int SizeArrayMax = ArrayMax.Length;
                int ind = 0;
                int max = 0;
                while (ind < SizeArrayMax)
                {
                    if (ArrayMax [ind] > max)
                    {
                        max = ArrayMax [ind];
                    }
                    ind++;
                }  
                return max;
            }
            // Вызов программы
            Console.WriteLine ("Введите размерность массива");
            int size = Convert.ToInt32 (Console.ReadLine());
            int [] ArrayRandom = new int [size]; 
            FileArray (ArrayRandom);
            Console.WriteLine ("Ваш массив:");
            PrintArray (ArrayRandom);
            Max (ArrayRandom);
            Console.WriteLine ();
            int result =  Max (ArrayRandom);
            Console.Write ($"Наибольшее число в массиве: {result}");

        }
    }
}