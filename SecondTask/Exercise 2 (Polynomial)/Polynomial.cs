using System;

namespace Exercise_2__Polynomial_
{
    public class Polynomial
    {
        // Коэффициенты публичные для того, чтобы использовать их в PolynomialEqualityComparer
        public double[] coefficients;

        ///<summary>
        ///  Создание полинома на основе коэффициентов
        ///</summary>
        ///<param name = "coefficients">Коэффициенты полинома, идущие по возрастанию степени переменной</param>
        public Polynomial(params double[] coefficients)
        {
            this.coefficients = coefficients;
        }

        public double this[int i]
        {
            get { return coefficients[i]; }
            set { coefficients[i] = value; }
        }

        public double GetFunctionResult(double x)
        {
            int polynomialDegree = coefficients.Length;
            double result = 0;

            foreach (double coef in coefficients)
            {
                result += coef * Math.Pow(x, polynomialDegree);
                polynomialDegree--;
            }

            return result;
        }

        public static Polynomial operator +(Polynomial polynomial1, Polynomial polynomial2)
        {
            // Ищем максимальную степень полинома
            int itemsCount = Math.Max(polynomial1.coefficients.Length, polynomial2.coefficients.Length);
            var result = new double[itemsCount];

            for (int i = 0; i < itemsCount; i++)
            {
                double coefFromPolynomial1, coefFromPolynomial2;

                // Ищем коэффициенты, которые будем складывать
                FindCoefs(polynomial1, polynomial2, i, out coefFromPolynomial1, out coefFromPolynomial2);

                // Складываем коэффициенты
                result[i] = coefFromPolynomial1 + coefFromPolynomial2;
            }
            return new Polynomial(result);
        }

        public static Polynomial operator -(Polynomial polynomial1, Polynomial polynomial2)
        {
            // Ищем максимальную степень полинома
            int itemsCount = Math.Max(polynomial1.coefficients.Length, polynomial2.coefficients.Length);
            var result = new double[itemsCount];

            for (int i = 0; i < itemsCount; i++)
            {
                double coefFromPolynomial1, coefFromPolynomial2;

                // Ищем коэффициенты, которые будем отнимать
                FindCoefs(polynomial1, polynomial2, i, out coefFromPolynomial1, out coefFromPolynomial2);

                // Складываем коэффициенты
                result[i] = coefFromPolynomial1 - coefFromPolynomial2;
            }
            return new Polynomial(result);
        }

        public static Polynomial operator *(Polynomial polynomial1, Polynomial polynomial2)
        {
            // Ищем максимальную степень полинома
            int itemsCount = polynomial1.coefficients.Length + polynomial2.coefficients.Length - 1;
            var result = new double[itemsCount];

            for (int i = 0; i < polynomial1.coefficients.Length; i++)
            {
                for (int j = 0; j < polynomial2.coefficients.Length; j++)
                {
                    result[i + j] += polynomial1.coefficients[i] * polynomial2.coefficients[j];
                }
            }

            return new Polynomial(result);
        }

        /// <summary>
        /// Вычисляет коффициенты перед переменной в степени i у двух полиномов
        /// </summary>
        /// <param name="polynomial1">Первый полином</param>
        /// <param name="polynomial2">Второй полином</param>
        /// <param name="i">Степень переменной</param>
        /// <param name="coefFromPolynomial1">Коэффициент перед переменной в первом полиноме</param>
        /// <param name="coefFromPolynomial2">Коэффициент перед переменной во втором полиноме</param>
        private static void FindCoefs(Polynomial polynomial1, Polynomial polynomial2, int i, out double coefFromPolynomial1, out double coefFromPolynomial2)
        {
            coefFromPolynomial1 = 0;
            coefFromPolynomial2 = 0;

            // Ищем макиимальную степень коэффициента в первом полиноме
            if (i < polynomial1.coefficients.Length)
            {
                coefFromPolynomial1 = polynomial1.coefficients[i];
            }

            // Ищем макиимальную степень коэффициента во втором полиноме
            if (i < polynomial2.coefficients.Length)
            {
                coefFromPolynomial2 = polynomial2.coefficients[i];
            }
        }
    }
}
