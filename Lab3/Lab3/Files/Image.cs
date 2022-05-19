using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Image: Prototype
    {
        private List<List<string>> pixels;

        // Constructor
        public Image(string name, List<List<string>> pixels)
        : base(name)
        {
            this.pixels = pixels;
        }

        public Image(Image obj)
        : base(obj.Name)
        {
            pixels = new List<List<string>>(obj.pixels);
        }

        public override Prototype Clone()
        {
            Image cl = new Image(this);
            return cl;
        }

        public override List<Prototype> Files()
        {
            return null;
        }

        public override string Format()
        {
            return ".png";
        }
    }
}
