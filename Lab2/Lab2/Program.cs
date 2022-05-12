using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Globalization;

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

            foreach (XmlNode node in doc.DocumentElement)
            {
                string name = node["Name"].InnerText;

                var producer = node["Producer"];
                string nameProducer = producer["Name"].InnerText;
                string countryProducer = producer["Country"].InnerText;

                Console.WriteLine(string.Format("Name Product = {0}\nProducer = {1}, Country = {2}",
                   name, nameProducer, countryProducer));

                foreach(XmlNode pnode in node["Products"])
                {
                    var format = new NumberFormatInfo(){NumberDecimalSeparator = ".",};

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
        }

    }

}
