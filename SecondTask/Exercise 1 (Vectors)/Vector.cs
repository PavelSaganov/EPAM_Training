using System;

namespace Exercise_1__Vectors_
{
    public class Vector
    {
        private double[] Coordinates { get; set; } = new double[3];

        public double Length
        {
            get =>
            Math.Sqrt(Math.Pow(Coordinates[0], 2) + Math.Pow(Coordinates[1], 2) + Math.Pow(Coordinates[2], 2));
        }


        /// <summary>
        /// Создание вектора через координаты вектора
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Vector(double x, double y, double z)
        {
            Coordinates[0] = x;
            Coordinates[1] = y;
            Coordinates[2] = z;
        }

        /// <summary>
        /// Создание вектора через координаты двух трехмерных тоечек
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="z1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="z2"></param>
        public Vector(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            Coordinates[0] = x1 - x2;
            Coordinates[1] = y1 - y2;
            Coordinates[2] = z1 - z2;
        }

        public double this[int i]
        {
            get { return Coordinates[i]; }
            set { Coordinates[i] = value; }
        }

        /// <summary>
        /// Поиск скалярного произведения векторов
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns>Результат произведения</returns>
        static public double GetScalarProduct(Vector v1, Vector v2)
        {
            return v1[0] * v2[0] + v1[1] * v2[1] + v1[2] * v2[2];
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1[0] + v2[0], v1[1] + v2[1], v1[2] + v2[2]);
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1[0] - v2[0], v1[1] - v2[1], v1[2] - v2[2]);
        }

        public static Vector operator *(Vector v1, Vector v2)
        {
            double x = v1[1] * v2[2] - v1[2] * v2[1];
            double y = v1[0] * v2[2] - v1[2] * v2[0];
            double z = v1[0] * v2[1] - v1[1] * v2[0];
            return new Vector(x, -y, z);
        }
    }
}
