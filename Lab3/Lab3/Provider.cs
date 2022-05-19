using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lab3
{
    class Provider
    {
        private Prototype root ;

        public Provider(Prototype root)
        {
            Prototype Disk = new Folder("D:", new List<Prototype> { root });
            this.root = Disk;
        }

        public void printTree()
        {
            TLR(root, 0);
        }

        private void TLR(Prototype node, int hight)
        {
            if (node != null)
            {
                for (int i = 0; i < hight; i++)
                    Console.Write("\t");
                Console.WriteLine(node.Name + node.Format());

                if (node.Files() != null)
                    foreach (Prototype file in node.Files())
                    {
                        TLR(file, hight + 1);
                    }
            }
        }

        public void delete(string path, string filename)
        {
            List<string> folder_names = path.Split('\\').ToList();

            Prototype curente = root;

            bool not_name = true;

            foreach (var folder_name in folder_names)
            {
                not_name = true;
                foreach (var folder in curente.Files())
                {
                    if(folder.Name == folder_name)
                    {
                        not_name = false;
                        curente = folder;
                    }
                }

                if (not_name)
                    break;
            }

            if (!not_name)
            {
                bool is_file = false;
                foreach (var elem in curente.Files())
                {
                    if (elem.Name == filename)
                        is_file = true;
                }

                if(is_file)
                    curente.removeContent(filename);
                else
                    Console.WriteLine("!Вказане ім'я некоректне");
            }    
            else
                Console.WriteLine("!Вказаний шлях не коректний");

        }

    }
}

