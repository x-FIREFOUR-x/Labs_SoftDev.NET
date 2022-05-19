using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class TextFile : Prototype
    {
        private string text;

        // Constructor
        public TextFile(string name, string text)
        : base(name)
        {
            this.text = text;
        }

        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }

        public override List<Prototype> Files()
        {
            return null;
        }

        public override string Format()
        {
            return ".txt";
        }
    }
}
