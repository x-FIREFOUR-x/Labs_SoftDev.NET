using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Lab2
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
            List<Producer> producers2 = new List<Producer> { producer1, producer2 };

            Product product1 = new Product { Code = "110022", Price = 150.5, Number = 10, DateArrival = "2.02.2022", Weight = 10.5 };
            Product product2 = new Product { Code = "110012", Price = 150.5, Number = 15, DateArrival = "10.03.2022", Weight = 15.75 };
            Product product3 = new Product { Code = "110045", Price = 210.5, Number = 5, DateArrival = "20.04.2022", Weight = 5.1 };
            Product product4 = new Product { Code = "115122", Price = 290.5, Number = 25, DateArrival = "24.03.2022", Weight = 25.5 };
            Product product5 = new Product { Code = "114501", Price = 101.5, Number = 30, DateArrival = "25.03.2022", Weight = 30.5 };
            Product product6 = new Product { Code = "123100", Price = 125.0, Number = 25, DateArrival = "15.04.2022", Weight = 40.5 };

            List<Product> listProduct1 = new List<Product> { product1, product2 };
            List<Product> listProduct2 = new List<Product> { product3, product4 };
            List<Product> listProduct3 = new List<Product> { product5 };
            List<Product> listProduct4 = new List<Product> { product6 };

            NameProduct nameProduct1 = new NameProduct { Name = "Meat", Producer = producer1, Products = listProduct1 };
            NameProduct nameProduct2 = new NameProduct { Name = "Meat", Producer = producer2, Products = listProduct2 };
            NameProduct nameProduct3 = new NameProduct { Name = "IceCream", Producer = producer3, Products = listProduct3 };
            NameProduct nameProduct4 = new NameProduct { Name = "Yogurt", Producer = producer2, Products = listProduct4 };

            List<NameProduct> Storage = new List<NameProduct> { nameProduct1, nameProduct2, nameProduct3, nameProduct4 };



            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            XmlSerializer xmlSerializer = new XmlSerializer(Storage.GetType());
            using (XmlWriter writer = XmlWriter.Create("Storage.xml", settings))
            {
                xmlSerializer.Serialize(writer, Storage);
            }

            #region xmlwriter
            /*
            using (XmlWriter writer = XmlWriter.Create("Storage1.xml", settings))
            {      
                writer.WriteStartElement("NameProducts");
                foreach (NameProduct nameProd in Storage)
                {
                    writer.WriteStartElement("NameProduct");

                    writer.WriteElementString("Name", nameProd.Name);

                    writer.WriteStartElement("Producer");
                    writer.WriteElementString("Name", nameProd.Producer.Name);
                    writer.WriteElementString("Country", nameProd.Producer.Country);
                    writer.WriteEndElement();

                    writer.WriteStartElement("Products");
                    foreach (Product prod in nameProd.Products)
                    {
                        writer.WriteStartElement("Product");

                        writer.WriteElementString("Code", prod.Code);
                        writer.WriteElementString("Price", prod.Price.ToString());
                        writer.WriteElementString("Number", prod.Number.ToString());
                        writer.WriteElementString("DateArrival", prod.DateArrival);
                        writer.WriteElementString("Weight", prod.Weight.ToString());

                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                }
                writer.WriteEndElement();   
            }
            */
            #endregion


            XmlDocument doc = new XmlDocument();
            doc.Load("Storage.xml");

            var format = new NumberFormatInfo() { NumberDecimalSeparator = ".", };

            foreach (XmlNode node in doc.DocumentElement)
            {
                string name = node["Name"].InnerText;

                var producer = node["Producer"];
                string nameProducer = producer["Name"].InnerText;
                string countryProducer = producer["Country"].InnerText;

                Console.WriteLine(string.Format("Name Product = {0}\nProducer = {1}, Country = {2}",
                   name, nameProducer, countryProducer));

                foreach (XmlNode pnode in node["Products"])
                {
                    

                    string code = pnode["Code"].InnerText;
                    double price = Double.Parse(pnode["Price"].InnerText, format);
                    int number = Int32.Parse(pnode["Number"].InnerText);
                    string date = pnode["DateArrival"].InnerText;
                    double weight = Double.Parse(pnode["Weight"].InnerText, format);

                    Console.WriteLine(string.Format("\tCode = {0} Price = {1} Number = {2} Date = {3} Weight = {4}",
                  code, price, number, date, weight));
                }
                Console.WriteLine();
            }




            XDocument xmlDoc = XDocument.Load("Storage.xml");

                //1. Всі партії
            var products =
                from xe in xmlDoc.Root.Elements("NameProduct")
                    .Elements("Products").Elements("Product")
                select new
                {
                    Code = xe.Element("Code").Value,
                    Price = Double.Parse(xe.Element("Price").Value, format),
                    Number = Int32.Parse(xe.Element("Number").Value),
                    Date = xe.Element("DateArrival").Value,
                    Weight = Double.Parse(xe.Element("Weight").Value, format)
                };
            PrintLINQ(products);


                //2. Всі Партії найменування Meat
            var products2 = 
                from xe in xmlDoc.Root.Elements("NameProduct")
                    .Elements("Products").Elements("Product")
                where xe.Parent.Parent.Element("Name").Value == "Meat"
                select new
                {
                    Code = xe.Element("Code").Value,
                    Price = Double.Parse(xe.Element("Price").Value, format),
                    Number = Int32.Parse(xe.Element("Number").Value),
                    Date = xe.Element("DateArrival").Value,
                    Weight = Double.Parse(xe.Element("Weight").Value, format)
                };
                PrintLINQ(products2);


                //3. Партії ціни яких більше 150
            var items =
                from xe in xmlDoc.Root.Elements("NameProduct")
                    .Elements("Products").Elements("Product")
                where Double.Parse(xe.Element("Price").Value, format) > 150
                select new
                {
                    Code = xe.Element("Code").Value,
                    Price = Double.Parse(xe.Element("Price").Value, format),
                    Number = Int32.Parse(xe.Element("Number").Value),
                    Date = xe.Element("DateArrival").Value,
                    Weight = Double.Parse(xe.Element("Weight").Value, format)
                };
            PrintLINQ(items);


                //4. Дати всіх партій найменування товару Meat
            var data =
                from xe in xmlDoc.Root.Elements("NameProduct")
                    .Elements("Products").Elements("Product")
                where xe.Parent.Parent.Element("Name").Value == "Meat"
                select new
                {
                    Date = xe.Element("DateArrival").Value
                };
            PrintLINQ(data);


                //5. Відортовані найменування продуктів
            var sortedNameProduct =
                from xe in xmlDoc.Root.Elements("NameProduct")
                orderby (xe.Element("Name").Value)
                select new 
                {
                    Name = xe.Element("Name").Value,
                    NameProducer = xe.Element("Producer").Element("Name").Value,
                    Country = xe.Element("Producer").Element("Country").Value
                };
            PrintLINQ(sortedNameProduct);


            //6.  Найменування продуктів виробник яких починається на B відсортовані за алфавітом по виробнику і додатково за алфавітом назви продукту
            var sortNameProduct =
                from xe in xmlDoc.Root.Elements("NameProduct")
                where (xe.Element("Producer").Element("Name").Value.ToUpper().StartsWith("B"))
                orderby (xe.Element("Producer").Element("Name").Value)
                orderby (xe.Element("Name").Value)
                select new
                {
                    Name = xe.Element("Name").Value,
                    NameProducer = xe.Element("Producer").Element("Name").Value,
                    Country = xe.Element("Producer").Element("Country").Value
                };
            PrintLINQ(sortNameProduct);


                //7. Перших два найменування товару
            var twoFirstNameProducts =
                 xmlDoc.Root.Elements("NameProduct")
                .Take(2)
                .Select (xmlDoc => new{
                                Name = xmlDoc.Element("Name").Value,
                                NameProducer = xmlDoc.Element("Producer").Element("Name").Value,
                                Country = xmlDoc.Element("Producer").Element("Country").Value
                         });
            PrintLINQ(twoFirstNameProducts);


                //8. Найбільша кількість в партії
            var maxNumber =
                 xmlDoc.Root.Elements("NameProduct")
                    .Elements("Products").Elements("Product")
                 .Max(xe => Int32.Parse(xe.Element("Number").Value))
                 ;
            Console.WriteLine(maxNumber);


                //9.Пропустити всі партії кількість в яких менше 15
            var limitedProducts =
                xmlDoc.Root.Elements("NameProduct")
                    .Elements("Products").Elements("Product")
                .OrderBy(xe => Int32.Parse(xe.Element("Number").Value))
                .SkipWhile(xe => Int32.Parse(xe.Element("Number").Value) < 15)
                .Select(xmlDoc => new {
                            Code = xmlDoc.Element("Code").Value,
                            Price = Double.Parse(xmlDoc.Element("Price").Value, format),
                            Number = Int32.Parse(xmlDoc.Element("Number").Value),
                            Date = xmlDoc.Element("DateArrival").Value,
                            Weight = Double.Parse(xmlDoc.Element("Weight").Value, format)
                    });
            PrintLINQ(limitedProducts);


                //10. Партії продуктів вироблені виробником країна якаго співпадає з певним шаблоном
            var specificProducer = 
                xmlDoc.Root.Elements("NameProduct")
                .Where(xe => Regex.IsMatch(xe.Element("Producer").Element("Country").Value, @"[Ss]p"))
                .Select(xe => new {
                                Name = xe.Element("Name").Value,
                                NameProducer = xe.Element("Producer").Element("Name").Value,
                                 Country = xe.Element("Producer").Element("Country").Value
                        });
            PrintLINQ(specificProducer);


            //11. Кількість постачаємих товарів кожним виробником
            var groupedProducer =
                xmlDoc.Root.Elements("NameProduct")
                .GroupBy(xe => xe.Element("Producer").Element("Name").Value)
                .Select(xe => new { 
                            Name = xe.Key,
                            Count = xe.Count() 
                        });
                PrintLINQ(groupedProducer);


            //12. Список партій кількість товарів в яких яких більше 5 і виробник шаблон B
            var join =
                from xe in xmlDoc.Root.Elements("NameProduct")
                    .Elements("Products").Elements("Product")
                where Int32.Parse(xe.Element("Number").Value) > 5
                join a in xmlDoc.Root.Elements("NameProduct") 
                    on xe.Parent.Parent.Element("Producer") equals a.Element("Producer")
                where (a.Element("Producer").Element("Name").Value.ToUpper().StartsWith("B"))
                select new { 
                            Code = xe.Element("Code").Value,
                            Number = xe.Element("Number").Value,
                            Producer = a.Element("Producer").Element("Name").Value 
                            
                };
            PrintLINQ(join);


                //13 Обєднання списків партій 1- товарів ціна яких більше 200 і товарів кількість яких більше 15
            var unitedlist = 
            xmlDoc.Root.Elements("NameProduct").Elements("Products").Elements("Product")
            .Where(t => Double.Parse(t.Element("Price").Value, format) > 200)
            .Union(
                xmlDoc.Root.Elements("NameProduct").Elements("Products").Elements("Product")
                .Where(t => Int32.Parse(t.Element("Number").Value, format) > 15)
                )
            .Select(xe => new {
                Code = xe.Element("Code").Value,
                Price = xe.Element("Price").Value,
                Number = xe.Element("Number").Value
            });
            PrintLINQ(unitedlist);


                //14 Перетин списків партій 1- товарів ціна яких більше 200 і товарів кількість яких більше 15
            var intersected =
            xmlDoc.Root.Elements("NameProduct").Elements("Products").Elements("Product")
            .Where(t => Double.Parse(t.Element("Price").Value, format) > 200)
            .Intersect(
                xmlDoc.Root.Elements("NameProduct").Elements("Products").Elements("Product")
                .Where(t => Int32.Parse(t.Element("Number").Value, format) > 15)
                )
            .Select(xe => new {
                Code = xe.Element("Code").Value,
                Price = xe.Element("Price").Value,
                Number = xe.Element("Number").Value
            });
            PrintLINQ(intersected);


                //15 Різність списків (елементи першого набору яких нема в другому)
                //партій товарів ціна яких більше 200 і товарів кількість яких більше 15
            var excepted =
            xmlDoc.Root.Elements("NameProduct").Elements("Products").Elements("Product")
            .Where(t => Double.Parse(t.Element("Price").Value, format) > 200)
            .Except(
                xmlDoc.Root.Elements("NameProduct").Elements("Products").Elements("Product")
                .Where(t => Int32.Parse(t.Element("Number").Value, format) > 15)
                )
            .Select(xe => new {
                Code = xe.Element("Code").Value,
                Price = xe.Element("Price").Value,
                Number = xe.Element("Number").Value
            });
            PrintLINQ(excepted);


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
