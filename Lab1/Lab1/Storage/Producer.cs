using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class Producer
    {
        public string Name { get; set; }       // ім'я виробника
        public string Country { get; set; }

        public override string ToString()
        {
            return string.Format(@"{0} {1}",  Name, Country);
        }
    }
}
