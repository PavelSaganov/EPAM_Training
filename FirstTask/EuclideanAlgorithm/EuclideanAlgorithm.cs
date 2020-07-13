using System;
using System.Linq;

namespace EuclideanAlgorithm
{
    static public class EuclideanAlgorithm
    {
        static public int GetGCDByEuclid(out long milliseconds, params int[] numbers)
        {
            // Начало остчета
            long start = DateTime.Now.Ticks;

            if (numbers.Length == 0)
                throw new Exception("Не передано ни одно число");

            while (numbers.Count(n => n != 0) != 1)
            {

                for (int i = 0; i < (numbers = numbers.Where(n => n != 0).ToArray()).Count(); i++)
                {
                int min = numbers.Where(n => n != 0).Min();
                    if (numbers[i] != min)
                    {
                        numbers[i] %= min;
                    }
                }
            }

            // Конец отсчета
            milliseconds = (DateTime.Now.Ticks - start) / 1000000;
            return numbers.Sum();
        }

        static public int GetGCDByEuclid(params int[] numbers)
        {
            if (numbers.Length == 0)
                throw new Exception("Не передано ни одно число");

            while (numbers.Count(n => n != 0) != 1)
            {

                for (int i = 0; i < (numbers = numbers.Where(n => n != 0).ToArray()).Count(); i++)
                {
                    int min = numbers.Where(n => n != 0).Min();
                    if (numbers[i] != min)
                    {
                        numbers[i] %= min;
                    }
                }
            }

            return numbers.Sum();
        }

        static public int GetGCDByStein(out long milliseconds, int A, int B)
        {
            // Начало остчета
            long start = DateTime.Now.Ticks;

            // k - коэффициент, который будет увеличиваться вдвое, 
            // до тех пор, пока хотя бы одно из чисел A или B не станет нечетным
            int k = 1;
            while ((A != 0) && (B != 0))
            {
                // Пока одно из чисел не станет нечетным
                while ((A % 2 == 0) && (B % 2 == 0))
                {
                    A /= 2;
                    B /= 2;
                    k *= 2;
                }

                // Проверка A на четность
                while (A % 2 == 0) 
                    A /= 2;

                // Проверка B на четность
                while (B % 2 == 0) 
                    B /= 2;

                if (A >= B)
                    A -= B;
                else 
                    B -= A;
            }

            // Конец отсчета
            milliseconds = (DateTime.Now.Ticks - start) / 1000000;
            return B * k;
        }

        static public int GetGCDByStein(int A, int B)
        {
            // k - коэффициент, который будет увеличиваться вдвое, 
            // до тех пор, пока хотя бы одно из чисел A или B не станет нечетным
            int k = 1;
            while ((A != 0) && (B != 0))
            {
                // Пока одно из чисел не станет нечетным
                while ((A % 2 == 0) && (B % 2 == 0))
                {
                    A /= 2;
                    B /= 2;
                    k *= 2;
                }

                // Проверка A на четность
                while (A % 2 == 0)
                    A /= 2;

                // Проверка B на четность
                while (B % 2 == 0)
                    B /= 2;

                if (A >= B)
                    A -= B;
                else
                    B -= A;
            }

            return B * k;
        }
    }


}
