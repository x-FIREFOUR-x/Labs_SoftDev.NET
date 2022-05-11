using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            IList<User> users = new List<User> {
                new User ("Bill Gates", "Microsoft", 48),
                new User ("Larry Page", "Google", 42)
            };


            using (XmlWriter writer = XmlWriter.Create("users.xml", settings))
            {
                writer.WriteStartElement("users");
                foreach (User user in users)
                {
                    writer.WriteStartElement("user");
                    writer.WriteElementString("name", user.Name);
                    writer.WriteElementString("company", user.Company);
                    writer.WriteElementString("age", user.Age.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }


            XmlDocument doc = new XmlDocument();
            doc.Load("users.xml");

        }

        class User
        {
            public string Name { get; set; }
            public string Company { get; set; }
            public int Age { get; set; }
            public User()
            {
            }
            /// <param name="name">Им'я</param>
            /// <param name="company">Компанія</param>
            /// <param name="age">Вік</param>
            public User(string name, string company, int age)
            {
                Name = name;
                Company = company;
                Age = age;
            }
        }
    }

}
