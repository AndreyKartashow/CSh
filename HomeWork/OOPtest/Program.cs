namespace GB
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Создание родительского класса Test1
            Test1 test1 = new Test1();
            test1.str1 = "Привет";
            Test1.Print(test1.str1);
            // Родительскому классу доступен только свой функционал


            // Класс дочерний от Test1 и родительский к Test3 (функционал класса Test3 не доступен)
            Test2 test2 = new Test2();
            test2.age = 5;
            test2.Mes(test2.age);       


            // Класс дочерний от Test2 (функционал класса Test1 и Test2 доступны)
            Test3 test3 = new Test3();
            test3.work = "ingener";
            test3.Message(test3.work);
            // Производим преобразование test2 к типу Test3 (Понижающие преобразование) и получаем новый функционал test2
            // Test3 testPR = (Test3)test2; 
            // testPR.str1 = "564";
            // testPR.Message(testPR.str1);
            // но такое преобразование вызывает исключение "недопустимые преобразования типов"

            Test2 lololo = test3;
            lololo.str1 = "произвели повышающее преобразование";
            Test1.Print(lololo.str1);
            lololo.str1 = test3.work;
            Test2.Print(lololo.str1);
            

            // Создадим класс дочерний к Test1 и "Сестринский" к Test2 
            TestкrUrURU yryry = new TestкrUrURU();
            yryry.str1 = "трололо";
            yryry.name = "уруру";
            yryry.PrintName(yryry.name);
            // Вот тут преобразование по сестренской ветке в коде возможно, но при запуске, программа вызывает ошибку
            /* Test2 testRURU = yryry; 
            testRURU.age = 564;
            testRURU.Mes(testRURU.age); */
            
}

    }

    class Test1
    {
        public string str1;
        
        public static void Print(string str)
        {
            Console.WriteLine(str);
        }
    }

    class Test2 : Test1
    {
        public int age;
        public void Mes(int num)
        {
            Console.WriteLine($"Мой возраст {num}");
        } 
    }

    class Test3 : Test2
    {
        public string work;
        public void Message(string work)
        {
            Console.WriteLine(work);
        } 
    }

    class TestкrUrURU : Test1
    {
        public string name;
        public void PrintName(string name)
        {
            Console.WriteLine(name);
        } 
    }

}