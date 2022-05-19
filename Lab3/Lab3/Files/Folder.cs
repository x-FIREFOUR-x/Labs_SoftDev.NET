using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Folder: Prototype
    {
        private List<Prototype> files;


        // Constructor
        public Folder(string name)
        : base(name)
        {
           
        }
        public Folder(string name, List<Prototype> files)
        : base(name)
        {
            this.files = files;
        }

        

        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }

        public override List<Prototype> Files()
        {
            return files;
        }

        public override string Format()
        {
            return "";
        }

        public override void addContent(Prototype file)
        {
            files.Add(file);
        }

        public override void removeContent(string name)
        {
            int index = -1;
            for (int i = 0; i < files.Count; i++)
            {
                if (files[i].Name == name)
                    index = i;
            }

            if (index != -1)
                files.RemoveAt(index);
        }
    }
}
