using System;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex z1 = new Complex(3, -2);
            Complex z2 = new Complex(-1, 4);
            Complex z = z1 + z2;
            Console.WriteLine(z.ToString());
            z = z1 - z2;
            Console.WriteLine(z.ToString());
            z = z1 * z2;
            Console.WriteLine(z.ToString());
            z = z1 / z2;
            Console.WriteLine(z.ToString());

            z = (z1 + z2) * (z1 - z2);
            Console.WriteLine(z.ToString());

        }
    }
}
