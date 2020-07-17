using System;

namespace Exercise_3__Products_
{
    public class Coconut : Product
    {
        public Coconut(string Type, string Name, double Cost) : base(Type, Name, Cost) { }

        /// <summary>
        /// Метод, позволяющий складывать объекты (наименование формируется как Name1-Name2, а стоимость - среднее арифметическое)
        /// </summary>
        /// <param name="coconut"></param>
        /// <param name="coconut2"></param>
        /// <returns></returns>
        public static Coconut operator +(Coconut coconut, Coconut coconut2)
        {
            if (coconut.Type != coconut2.Type)
                throw new Exception("Нельзя слаживать продукты разных видов товаров");
            return new Coconut(coconut.Type, coconut.Name + "-" + coconut2.Name, (coconut.Cost + coconut2.Cost) / 2);
        }

        /// <summary>
        /// Преобразование из Bread в Coconut
        /// </summary>
        /// <param name="product"></param>
        public static explicit operator Coconut(Bread product)
        {
            return new Coconut(product.Type, product.Name, product.Cost);
        }

        /// <summary>
        /// Преобразование из Cheese в Coconut
        /// </summary>
        /// <param name="product"></param>
        public static explicit operator Coconut(Cheese cheese)
        {
            return new Coconut(cheese.Type, cheese.Name, cheese.Cost);
        }
    }
}
