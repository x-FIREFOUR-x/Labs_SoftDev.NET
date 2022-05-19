using System;
using System.Collections.Generic;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Prototype t1 = new TextFile("Text1", "djjdjdjd");
            Prototype t2 = new TextFile("Text2", "jddgssdhss");
            Prototype t3 = new TextFile("Text3", "avcx");

            Prototype i1 = new Image("Image", new List<List<string>>());
            
            

            Prototype f1 = new Folder("Folder1", new List<Prototype>{t1, t2});
            Prototype f4 = new Folder("Folder4", new List<Prototype> {});
            Prototype f2 = new Folder("Folder2", new List<Prototype> {i1, f4});
            Prototype f3 = new Folder("Folder", new List<Prototype> {f1, f2, t3});


            Provider D = new Provider(f3);
            D.printTree();
        }
    }
}
