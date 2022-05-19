using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Provider
    {
        private Prototype root;

        public Provider(Prototype root)
        {
            this.root = root;
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

    }
}

