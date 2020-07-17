using System;

namespace Exercise_3__Products_
{
    public class Bread : Product
    {
        public Bread(string Type, string Name, double Cost) : base(Type, Name, Cost) { }


        /// <summary>
        /// Метод, позволяющий складывать объекты (наименование формируется как Name1-Name2, а стоимость - среднее арифметическое)
        /// </summary>
        /// <param name="coconut"></param>
        /// <param name="coconut2"></param>
        /// <returns></returns>
        public static Bread operator +(Bread coconut, Bread coconut2)
        {
            if (coconut.Type != coconut2.Type)
                throw new Exception("Нельзя слаживать продукты разных видов товаров");
            return new Bread(coconut.Type, coconut.Name + "-" + coconut2.Name, (coconut.Cost + coconut2.Cost) / 2);
        }

        /// <summary>
        /// Преобразование из Coconut в Bread
        /// </summary>
        /// <param name="product"></param>
        public static explicit operator Bread(Coconut product)
        {
            return new Bread(product.Type, product.Name, product.Cost);
        }

        /// <summary>
        /// Преобразование из Cheese в Bread
        /// </summary>
        /// <param name="product"></param>
        public static implicit operator Bread(Cheese cheese)
        {
            return new Bread(cheese.Type, cheese.Name, cheese.Cost);
        }


    }
}
