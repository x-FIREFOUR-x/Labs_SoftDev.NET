using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Image: Prototype
    {
        List<List<string>> pixels;

        // Constructor
        public Image(string name, List<List<string>> pixels)
        : base(name)
        {
            this.pixels = pixels;
        }

        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }
    }
}
