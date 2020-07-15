using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_3__Products_.Abstract_Classes
{
    public abstract class Product
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }

        /// <summary>
        /// Конструктор для создания продукта
        /// </summary>
        /// <param name="Type">Тип продукта</param>
        /// <param name="Name">Наименование продукта</param>
        /// <param name="Cost">Стоимость продукта</param>
        public Product (string Type, string Name, double Cost)
        {
            this.Type = Type;
            this.Name = Name;
            this.Cost = Cost;
        }

        public static explicit operator int(Product prod)
        {
            return (int)prod.Cost;
        }

        public static explicit operator double(Product prod)
        {
            return prod.Cost;
        }
    }
}
