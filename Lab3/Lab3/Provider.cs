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

            bool not_correct_path = true;

            if (folder_names[0] == "")
            {
                folder_names = new List<string>();
                not_correct_path = false;
            }


            foreach (var folder_name in folder_names)
            {
                not_correct_path = true;
                foreach (var folder in curente.Files())
                {
                    if(folder.Name == folder_name)
                    {
                        not_correct_path = false;
                        curente = folder;
                    }
                }

                if (not_correct_path)
                    break;
            }

            bool is_file = false;
            foreach (var elem in curente.Files())
            {
                if (elem.Name == filename)
                    is_file = true;
            }

            if (!not_correct_path && is_file)
               curente.removeContent(filename);  
            else
                Console.WriteLine("!Вказаний шлях не коректний");

        }

        public void copy(string path_copy, string filename, string path_insert)
        {
            List<string> folder_names_copy = path_copy.Split('\\').ToList();

            Prototype curente_copy = root;
            bool not_correct_path = true;

            if (folder_names_copy[0] == "")
            {
                folder_names_copy = new List<string>();
                not_correct_path = false;
            }

            folder_names_copy.Add(filename);

            foreach (var folder_name in folder_names_copy)
            {
                not_correct_path = true;
                foreach (var folder in curente_copy.Files())
                {
                    if (folder.Name == folder_name)
                    {
                        not_correct_path = false;
                        curente_copy = folder;
                    }
                }

                if (not_correct_path)
                    break;
            }


            List<string> folder_names_insert = path_insert.Split('\\').ToList();
            Prototype curente_insert = root;
            bool not_correct_path2 = true;

            if (folder_names_insert[0] == "")
            {
                folder_names_insert = new List<string>();
                not_correct_path2 = false;
            }

            foreach (var folder_name in folder_names_insert)
            {
                not_correct_path2 = true;
                foreach (var folder in curente_insert.Files())
                {
                    if (folder.Name == folder_name)
                    {
                        not_correct_path2 = false;
                        curente_insert = folder;
                    }
                }

                if (not_correct_path2)
                    break;
            }


            if (!not_correct_path && !not_correct_path2)
                curente_insert.addContent(curente_copy.Clone());
            else
                Console.WriteLine("!Вказаний шлях не коректний");
        }


    }
}

