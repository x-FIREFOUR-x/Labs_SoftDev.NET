using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class Product
    {
        private string Code { get; set; }         // код товару
        private string Name { get; set; }         // Найменування товару
        private double Price { get; set; }        // ціна за одиницю
        private int Number { get; set; }          // кількість в пачці
        private string DateArrival { get; set; }  // дата прибуття на склад
        private double Weight { get; set; }        // вага

        public Product() { }

        public Product(string code, string name, double price, int number, string date, double weight ) 
        {
            Code = code;
            Name = name;
            Price = price;
            Number = number;
            DateArrival = date;
            Weight = weight;
        }

        public override string ToString()
        {
            return string.Format(@"Товар: 
                Код ""{0}"" Найменування ""{1}""
                Ціна одиниці ""{2}"" грн
                Кількість ""{3}"" шт
                Дата привезення ""{4}""
                Вага одиниці ""{5}"" кг", Code, Name, Price, Number, DateArrival, Weight);
        }
    }
}

