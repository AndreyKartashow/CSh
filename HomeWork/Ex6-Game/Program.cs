namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            // Написать консольную игру, в которой пользователю необходимо отгдать слово побуквенно по контрольному вопросу

            // Метод печати массива
            void PrintArray (char[] array)
            {
                for (int index = 0; index < array.Length; index++)
                {
                    Console.Write ($"{array[index]} ");
                } 
            }
            // Метод заполнения массива пользователя 
            void FileArray (char[] coll)
            {
                int count = coll.Length;
                int index = 0;
                while (index < count)
                {
                    coll[index] = '-';
                    index ++;
                }
            }
/*          string question1 = "Отгадай фамилию создателя ядра ОС <Linyx>";
            string question2 = "Отгадай фамилию создателя ядра ОС <Linyx>";
            string question3 = "Отгадай фамилию создателя ядра ОС <Linyx>";
            string question4 = "Отгадай фамилию создателя ядра ОС <Linyx>";
            string question5 = "Отгадай фамилию создателя ядра ОС <Linyx>";
            string[] ArrayQuestion = {question1, question2, question3, question4, question5};
            string answer1 = "Торвальдс";
            string answer2 = "Торвальдс";
            string answer3 = "Торвальдс";
            string answer4 = "Торвальдс";
            string answer5 = "Торвальдс";
            string[] ArraySystemAnswer00 = {answer1, answer2, answer3, answer4, answer5}; */

            Console.WriteLine ("Привет, в этой игре тебе необходимо отгадать слова!");
            Console.WriteLine ("Отгадай фамилию создателя ядра ОС <Linyx>");
            // Массив с ответом
            string ArraySystemAnswer = "Торвальдс";
            char[] ArraySystemAnswerChar = ArraySystemAnswer.ToCharArray();
            int SizeArraySystemAnswer = ArraySystemAnswer.Length;
            // Массив, в который сохраняется ответ пользователя
            char[] ArrayUserAnsverChar = new char [SizeArraySystemAnswer];
            FileArray (ArrayUserAnsverChar);
            PrintArray (ArrayUserAnsverChar);
            Console.WriteLine ();
            // Цикл нашей игры                    
            for ( ; ; )  // ArrayUserAnsver != ArraySystemAnswer 
            {
                // Цикл сравнения введеной буквы с ответом
                Console.WriteLine ("Введите пожалуйста новую букву");
                string leter = Console.ReadLine();
                char[] leterChar = leter.ToCharArray();
                for (int i = 0; i < SizeArraySystemAnswer; i++)  
                    if (leter[0] == ArraySystemAnswerChar[i])
                    {
                        ArrayUserAnsverChar[i] = leter[0];
                        Console.WriteLine ("Такая буква есть");
                        PrintArray (ArrayUserAnsverChar);
                        Console.WriteLine ();
                    }
                string s1 = String.Concat<char>(ArraySystemAnswerChar);
                string s2 = String.Concat<char>(ArrayUserAnsverChar);
                int result = String.Compare(s1, s2);
                if (result == 0)
                {
                   goto End; 
                }
            }
            End: 
            Console.WriteLine ("Вы отгадали слово!");  
        }
    }
}