using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {


        static void Main(string[] args)
        {
            List<Producer> b = new List<Producer>
            {
                new Producer("fff", "125" ),
                new Producer("aa", "15" ),
                new Producer("fdf", "5" ),
            };

            foreach (var item in b)
            {
                Console.WriteLine(item.ToString());
            }


        }
    }
}
