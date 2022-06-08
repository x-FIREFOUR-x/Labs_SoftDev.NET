using System.Collections.Generic;

namespace Lab2
{
    public class NameProduct
    {
        public string Name { get; set; }          // Найменування товару
        public Producer Producer { get; set; }    // Ім'я виробника
        public List<Product> Products { get; set; } = new List<Product>();       //партії товару 

        public override string ToString()
        {
            string products = string.Join(" ", Products);
            return string.Format(@"Найменування: ""{0}"" Виробник: ""{1}"" Партії: {2}", Name, Producer, products);
        }
    }
}
