using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Producer producer1 = new Producer { Name = "Bedronka", Country = "Poland" };
            Producer producer2 = new Producer { Name = "Bayer", Country = "English" };
            Producer producer3 = new Producer { Name = "TOF", Country = "Spanish" };

            Product product1 = new Product { Code = "110022", Price = 150.5, Number = 10, DateArrival = "15.02.2022", Weight = 10.5 };
            Product product2 = new Product { Code = "110012", Price = 150.5, Number = 15, DateArrival = "10.03.2022", Weight = 15.75 };
            Product product3 = new Product { Code = "110045", Price = 210.5, Number = 5, DateArrival =  "20.03.2022", Weight = 5.1 };
            Product product4 = new Product { Code = "115122", Price = 290.5, Number = 25, DateArrival = "20.03.2022", Weight = 25.5 };
            Product product5 = new Product { Code = "114501", Price = 101.5, Number = 30, DateArrival = "25.03.2022", Weight = 30.5 };
            Product product6 = new Product { Code = "123100", Price = 125.0, Number = 25, DateArrival = "15.04.2022", Weight = 40.5 };

            List<Product> listProduct1 = new List<Product> {product1, product2};
            List<Product> listProduct2 = new List<Product> { product3, product4 };
            List<Product> listProduct3 = new List<Product> { product5 };
            List<Product> listProduct4 = new List<Product> { product6};

            NameProduct nameProduct1 = new NameProduct { Name = "Meat", Producer = producer1, Products = listProduct1 };
            NameProduct nameProduct2 = new NameProduct { Name = "Flakes", Producer = producer2, Products = listProduct2 };
            NameProduct nameProduct3 = new NameProduct { Name = "IceCream", Producer = producer3, Products = listProduct3 };
            NameProduct nameProduct4 = new NameProduct { Name = "Yogurt", Producer = producer1, Products = listProduct4 };

            List<NameProduct> Storage = new List<NameProduct> { nameProduct1, nameProduct2, nameProduct3, nameProduct4 };

            foreach (var item in Storage)
            {
                Console.WriteLine(item.ToString());
            }


        }
    }
}
