using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    abstract class Prototype
    {
        private string name;

        // Constructor
        public Prototype(string name)
        {
            this.name = name;
        }

        // Property
        public string Name
        {
            get
            {
                return name;
            }
        }
        public abstract Prototype Clone();
    }
}
