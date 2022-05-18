using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class TextFile : Prototype
    {
        string text;

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
    }
}
