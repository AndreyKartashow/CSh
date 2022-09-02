namespace ImplementationHomeWork
{
    class Task2
    {
        // Напишите программу, которая найдёт точку пересечения двух прямых, заданных уравнениями 
        // y = k1 * x + b1, y = k2 * x + b2.
        // значения b1, k1, b2 и k2 задаются пользователем.
        static void Main(string[] args)
        {
            ConsoleKeyInfo esc = new ConsoleKeyInfo();
            while (esc.Key != ConsoleKey.Escape)
            {
                Console.WriteLine("Эта програма может решить ситему уравнений с двумя неизвестными матричнымм методом, заданных функциями типа: y = k * x + b");

                double[,] matrixArgument = new double[2, 2];
                double[,] matrixFreeMembre = new double[2, 1];

                //                      i/j  0   1
                //   y - k1 * x = b1      0 |y   x|   |b1|
                //   y - k2 * x = b2      1 |y   x|   |b2|

                matrixArgument[0, 0] = 1; // коеф перед аргументом У в уравнении 1
                Console.WriteLine("Пожалуйста, введите параметр функции <k1>");
                matrixArgument[0, 1] = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Пожалуйста, введите параметр функции <b1>");
                matrixFreeMembre[0, 0] = Convert.ToDouble(Console.ReadLine());

                matrixArgument[1, 0] = 1; // коеф перед аргументом У в уравнении 2
                Console.WriteLine("Пожалуйста, введите параметр функции <k2>");
                matrixArgument[1, 1] = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Пожалуйста, введите параметр функции <b2>");
                matrixFreeMembre[1, 0] = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Ваша матрица коеффициентов, стоящих перед аргументами");
                PrintMatrix(matrixArgument);
                Console.WriteLine("Ваша матрица свободных членов");
                PrintMatrix(matrixFreeMembre);
                double determinant = DeterminantMatrix(matrixArgument);
                Console.WriteLine($"Определитель матрицы равен: {determinant}");

                if (determinant != 0)
                {
                    Console.WriteLine("Ваша союзная матрица");
                    double[,] unionNatrix = UnionMatrix(matrixArgument);
                    PrintMatrix(unionNatrix);

                    Console.WriteLine("Ваша транспонированая матрица");
                    double[,] transposedMatrix = TransposedMatrix(unionNatrix);
                    PrintMatrix(transposedMatrix);

                    Console.WriteLine("Ваша обратная матрица");
                    double[,] reversNatrix = ReversMatrix(transposedMatrix, determinant);
                    PrintMatrix(reversNatrix);

                    double[,] unknownMembers = MatrixUnknownMembers(reversNatrix, matrixFreeMembre);
                    // double X = Math.Round(unknownMembers[0,0], 3, MidpointRounding.ToEven);
                    // double Y = Math.Round(unknownMembers[1,0]);
                    // Console.WriteLine($"Аргумент X соответствует значению = {X}");
                    // Console.WriteLine($"Аргумент Y соответствует значению = {Y}");
                    Console.WriteLine($"Аргумент X соответствует значению = {unknownMembers[0,0]}");
                    Console.WriteLine($"Аргумент Y соответствует значению = {unknownMembers[1,0]}");
                }
                else
                {
                    Console.WriteLine("Предложенная вами матрица не имеет решения");
                }

                Console.WriteLine("Нажмите клавишу <Esc> для выхода или любую другую для продолжения");
                esc = Console.ReadKey();
                Console.Clear();
            }
        }

        static void PrintMatrix(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($" {matrix[i,j]}  ");
                }
                Console.WriteLine();
            }
        }

        static double DeterminantMatrix(double[,] matrix)
        {
            double determinant = matrix[0,0] * matrix[1,1] - matrix[1,0] * matrix[0,1];
            return determinant;
        }

        static double[,] UnionMatrix(double[,] matrix)
        {
            double[,] unionNatrix = new double[2,2];
            unionNatrix[0,0] = matrix[1,1];
            unionNatrix[0,1] = matrix[1,0] * (-1);
            unionNatrix[1,0] = matrix[0,1] * (-1);
            unionNatrix[1,1] = matrix[0,0];
            return unionNatrix;
        }

        static double[,] TransposedMatrix(double[,] unionMatrix)
        {
            double[,] transposedMatrix = new double[2,2];
            transposedMatrix[0,0] = unionMatrix[0,0];
            transposedMatrix[0,1] = unionMatrix[1,0];
            transposedMatrix[1,0] = unionMatrix[0,1];
            transposedMatrix[1,1] = unionMatrix[1,1];
            return transposedMatrix;
        }

        static double[,] ReversMatrix(double[,] matrix, double determinant)
        {
            double[,] reversNatrix = new double[2,2];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    reversNatrix[i,j] = matrix[i,j] * (1 / determinant);
                }
            }
            return reversNatrix;
        }

        static double[,] MatrixUnknownMembers(double[,] reversMatrix, double[,] freeMembersMatrix)
        {
            double[,] unknownMembers = new double[2,1];
            unknownMembers[0,0] = (reversMatrix[0,0] * freeMembersMatrix[0,0]) + (reversMatrix[0,1] * freeMembersMatrix[1,0]);
            unknownMembers[1,0] = (reversMatrix[1,0] * freeMembersMatrix[0,0]) + (reversMatrix[1,1] * freeMembersMatrix[1,0]);
            return unknownMembers;
        }
    }
}


