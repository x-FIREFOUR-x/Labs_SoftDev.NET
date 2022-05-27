﻿using System;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
             /*
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
             */

            Context context = new Context();
            Complex x = new Complex(3, -2);
            Complex y = new Complex(-1, 4);
            Complex z = new Complex(0, 1);

            context.SetVariable("x", x);
            context.SetVariable("y", y);
            context.SetVariable("z", z);

            Expression expression = new NotEqualExpression(
                new AddExpression(
                    new TerminalExpression("x"), new TerminalExpression("y")
                ),
                new TerminalExpression("z")
             );

            Complex result = expression.Interpret(context);
            Console.WriteLine( result.ToString());


        }
    }
}
