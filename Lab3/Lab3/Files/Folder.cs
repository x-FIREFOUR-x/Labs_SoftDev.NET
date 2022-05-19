using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

        public Folder(Folder obj)
        : base(obj.Name)
        {
            this.files = obj.files.Select(p => p.Clone()).ToList();
        }

        public override Prototype Clone()
        {
            Folder cl = new Folder(this);
            return cl;
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
