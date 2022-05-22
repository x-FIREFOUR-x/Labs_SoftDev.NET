using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    class Complex
    {
        private double real;
        private double image;

        public Complex(double real, double image)
        {
            this.real = real;
            this.image = image;
        }

        public static Complex operator +(Complex a, Complex b)
        {     
            Complex z = new Complex(a.real + b.real, a.image + b.image);
            return z;
        }

        public static Complex operator -(Complex a, Complex b)
        {
            Complex z = new Complex(a.real - b.real, a.image - b.image);
            return z;
        }

        public static Complex operator *(Complex a, Complex b)
        {
            double z_real = (a.real * b.real) - (a.image * b.image);
            double z_image = (a.real * b.image) + (b.real * a.image);
            Complex z = new Complex(z_real, z_image);
            return z;
        }

        public static Complex operator /(Complex a, Complex b)
        {
            double znam = (b.real * b.real) + (b.image * b.image);
            double z_real = ((a.real * b.real) + (a.image * b.image)) / znam;
            double z_image = (b.real * a.image) - (a.real * b.image) / znam;
            Complex z = new Complex(z_real, z_image);
            return z;
        }

        public static bool operator ==(Complex a, Complex b)
        {
            if (a.real == b.real && a.image == b.image)
                return true;
            else
                return false;
        }

        public static bool operator !=(Complex a, Complex b)
        {
            if (a.real != b.real || a.image != b.image)
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            string sign = "";
            if (this.image >= 0)
                sign = "+";

            return (this.real).ToString() +  sign + (this.image).ToString() + "i";
        }

    }
}
