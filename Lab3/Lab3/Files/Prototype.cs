using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    abstract class Prototype
    {
       protected string name;

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

        public abstract List<Prototype> Files();

        public abstract string Format();

        public virtual void addContent(Prototype file) { }
        public virtual void removeContent(string name) { }
    }
}
