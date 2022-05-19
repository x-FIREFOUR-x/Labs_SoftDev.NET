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

        public TextFile(TextFile obj)
        : base(obj.Name)
        {
            this.text = obj.text;
        }

        public override Prototype Clone()
        {
            TextFile cl = new TextFile(this);
            return cl;
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
