using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Folder: Prototype
    {
        List<Prototype> files;

        // Constructor
        public Folder(string name, List<Prototype> files)
        : base(name)
        {
            this.files = files;
        }

        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }
    }
}
