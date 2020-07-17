using System;

namespace Exercise_3__Products_
{
    public class Cheese : Product
    {
        public Cheese(string Type, string Name, double Cost) : base(Type, Name, Cost) { }

        /// <summary>
        /// Преобразование из Bread в Cheese
        /// </summary>
        /// <param name="product"></param>
        public static explicit operator Cheese(Bread product)
        {
            return new Cheese(product.Type, product.Name, product.Cost);
        }

        /// <summary>
        /// Преобразование из Coconut в Cheese
        /// </summary>
        /// <param name="product"></param>
        public static explicit operator Cheese(Coconut product)
        {
            return new Cheese(product.Type, product.Name, product.Cost);
        }

        /// <summary>
        /// Метод, позволяющий складывать объекты (наименование формируется как Name1-Name2, а стоимость - среднее арифметическое)
        /// </summary>
        /// <param name="coconut"></param>
        /// <param name="coconut2"></param>
        /// <returns></returns>
        public static Cheese operator +(Cheese coconut, Cheese coconut2)
        {
            if (coconut.Type != coconut2.Type)
                throw new Exception("Нельзя слаживать продукты разных видов товаров");
            return new Cheese(coconut.Type, coconut.Name + "-" + coconut2.Name, (coconut.Cost + coconut2.Cost) / 2);
        }
    }
}
