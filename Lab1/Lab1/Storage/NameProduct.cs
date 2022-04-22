using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class NameProduct
    {
        private string Name { get; set; }          // Найменування товару
        private string NameProducer { get; set; }    // Ім'я виробника

        public NameProduct() { }

        public NameProduct(string name, string nameProducer) 
        {
            Name = name;
            NameProducer = nameProducer;
        }

        public override string ToString()
        {
            return string.Format(@"Найменування: ""{0}"" Виробник: ""{1}""", Name, NameProducer);
        }
    }
}
