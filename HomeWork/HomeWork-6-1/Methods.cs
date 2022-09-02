namespace MethodsImplementatHomeWork
{
    public class MethodsTask1
    {
        // Метод подсчета положительных чисел в массиве
        public static int CountPositivePositionArray(double[] array)
        {       
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0) 
                {
                    count++;                    
                }
            }
            return count;
        }

        // Метод преобразования строчных элементов массива в числа
        public static double[] ArrayStringToArrayInt(string[] array)
        {                  
            double[] arrayToDouble = new double [array.Length];
            for (int i = 0; i < array.Length; i++) 
            {
                arrayToDouble[i] = Convert.ToDouble(array[i]);     
            }            
            return arrayToDouble;
        }
    }
}
