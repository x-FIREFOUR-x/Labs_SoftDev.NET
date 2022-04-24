using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            List<Producer> producers = new List<Producer> { producer1, producer2, producer3 };
            List<Producer> producers2 = new List<Producer> { producer1, producer2};

            Product product1 = new Product { Code = "110022", Price = 150.5, Number = 10, DateArrival = "2.02.2022", Weight = 10.5 };
            Product product2 = new Product { Code = "110012", Price = 150.5, Number = 15, DateArrival = "10.03.2022", Weight = 15.75 };
            Product product3 = new Product { Code = "110045", Price = 210.5, Number = 5, DateArrival =  "20.04.2022", Weight = 5.1 };
            Product product4 = new Product { Code = "115122", Price = 290.5, Number = 25, DateArrival = "24.03.2022", Weight = 25.5 };
            Product product5 = new Product { Code = "114501", Price = 101.5, Number = 30, DateArrival = "25.03.2022", Weight = 30.5 };
            Product product6 = new Product { Code = "123100", Price = 125.0, Number = 25, DateArrival = "15.04.2022", Weight = 40.5 };

            List<Product> listProduct1 = new List<Product> {product1, product2};
            List<Product> listProduct2 = new List<Product> { product3, product4 };
            List<Product> listProduct3 = new List<Product> { product5 };
            List<Product> listProduct4 = new List<Product> { product6};

            NameProduct nameProduct1 = new NameProduct { Name = "Meat", Producer = producer1, Products = listProduct1 };
            NameProduct nameProduct2 = new NameProduct { Name = "Meat", Producer = producer2, Products = listProduct2 };
            NameProduct nameProduct3 = new NameProduct { Name = "IceCream", Producer = producer3, Products = listProduct3 };
            NameProduct nameProduct4 = new NameProduct { Name = "Yogurt", Producer = producer2, Products = listProduct4 };

            List<NameProduct> Storage = new List<NameProduct> { nameProduct1, nameProduct2, nameProduct3, nameProduct4 };


                        // 1. Партії одного найменування товару 
            var products = from t in nameProduct1.Products
                           select t;
            PrintLINQ(products);

            var products2 = nameProduct1.Products.Select(t => t);
            PrintLINQ(products2);


                        //2. Дати привезення партій одного найменування товару
            var dates = from t in nameProduct1.Products
                           select t.DateArrival;
            PrintLINQ(dates);

            var dates2 = nameProduct1.Products.Select(t => t.DateArrival);
            PrintLINQ(dates2);


                        //3. Характеристики партій одного найменування товару
            var charactProduct = from t in nameProduct1.Products
                                  select new { t.Code, t.Number, t.Weight };
            PrintLINQ(charactProduct);

            var charactProduct2 = nameProduct1.Products
                .Select(t => new { t.Code, t.Number, t.Weight });
            PrintLINQ(charactProduct2);


                        //4. Партії одного найменування продукту вага який більше 20
            var produc = nameProduct2.Products.Where(t => t.Weight > 20);
            PrintLINQ(produc);

            var produc2 = from t in nameProduct2.Products
                          where t.Weight > 20
                          select t;
            PrintLINQ(produc2);


                        //5. Відсортовані за алфавітом найменування продуктів 
            var sortedNameProduct = Storage.OrderBy(t => t.Name)
                .Select(t => new { t.Name, t.Producer});
            PrintLINQ(sortedNameProduct);

            var sortedNameProduct2 = from t in Storage
                                     orderby (t.Name)
                                     select new { t.Name, t.Producer };
            PrintLINQ(sortedNameProduct2);


                        //6.  Найменування продуктів виробник яких починається на B відсортовані за алфавітом по виробнику і додатково за алфавітом назви продукту
            var sortedNameProducts = Storage
                .Where(t => t.Producer.Name.ToUpper().StartsWith("B"))
                .OrderBy(t => t.Producer.Name)
                .ThenBy(t => t.Name)
                .Select(t => new { t.Name, t.Producer });
            PrintLINQ(sortedNameProducts);

            var sortedNameProducts2 = from t in Storage
                where (t.Producer.Name.ToUpper().StartsWith("B"))
                orderby (t.Name)
                orderby (t.Producer.Name)
                select new { t.Name, t.Producer };
            PrintLINQ(sortedNameProducts2);


                        //7. Перших два найменування товару
            var twoFirstNameProducts = Storage
                .Take(2);
            PrintLINQ(twoFirstNameProducts);


                        //8. Максимальна кількість товарів в партії серед партій одного найменування товару
            var maxNumber = nameProduct1.Products.Max(t => t.Number);
            Console.WriteLine(maxNumber);


                        //9. Пропустити всі партії одного найменування продукту після партії задовольняючої умову
            var limitedProducts = nameProduct2.Products
                .SkipWhile(t => DateTime.Parse(t.DateArrival).Month == DateTime.Now.Month );
            PrintLINQ(limitedProducts);


                        //10. Партії продуктів вироблені виробником країна якаго співпадає з певним шаблоном
            var specificProducer = Storage
                .Where(t => Regex.IsMatch(t.Producer.Country, @"[Ss]p"));
            PrintLINQ(specificProducer);


                        //11. Кількість постачаємих товарів кожним виробником
            var groupedProducer = Storage.GroupBy(t => t.Producer)
            .Select(t => new { Name = t.Key, Count = t.Count()});
            PrintLINQ(groupedProducer);

            var groupedProducer2 =
                from t in Storage
                group t by t.Producer into a
                select new { Name = a.Key, Count = a.Count() };
            if (groupedProducer2 is null)
            {
                throw new ArgumentNullException(nameof(groupedProducer2));
            }
            PrintLINQ(groupedProducer2);


                        //12. Список товар і його виробник
            var ListProductProducer =
                from t in Storage
                join a in producers on t.Producer equals a
                select new { Productname = t.Name, Producer = a.Name };
            PrintLINQ(ListProductProducer);


                        //13. Обєднати колекції(партії товару) listProduct1 & listProduct2
            var unitedlistProduct = listProduct1.Union(listProduct2);
            PrintLINQ(unitedlistProduct);

            var unitedlistProduct2 = from listProduct in listProduct1.Union(listProduct2)
                                        select listProduct;
            PrintLINQ(unitedlistProduct2);


                        //14. Отримати колекцію пересікання(спільних елементів) колекціій producers & producers2
            var intersectedProducers = producers.Intersect(producers2);
            PrintLINQ(intersectedProducers);

            var intersectedProducers2 = from producers_ in producers.Intersect(producers2)
                                        select producers_;
            PrintLINQ(intersectedProducers2);


                        //15. Отримати колекцію різних елементів колекцій producers & producers2
            var exceptedProducers = producers.Except(producers2);
            PrintLINQ(exceptedProducers);

            var exceptedProducers2 = from producers_ in producers.Except(producers2)
                                        select producers_;
            PrintLINQ(exceptedProducers2);
        }


        private static void PrintLINQ<T>(IEnumerable<T> list)
        {
            Console.WriteLine("--------------------------");
            foreach (T value in list)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine();
        }
    }
}
