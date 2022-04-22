using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class Producer
    {
        private string Name { get; set; }       // ім'я виробника
        private string Country { get; set; }

        public Producer() { }
        public Producer(string name, string country) 
        {
            Name = name;
            Country = country;
        }

        public override string ToString()
        {
            return string.Format(@"Виробник: Назва ""{0}"" Країна ""{1}""",  Name, Country);
        }
    }
}
