using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    class Complex
    {
        private double Re;
        private double Im;

        public Complex(double real, double image)
        {
            this.Re = real;
            this.Im = image;
        }

        public static Complex operator +(Complex a, Complex b)
        {     
            Complex z = new Complex(a.Re + b.Re, a.Im + b.Im);
            return z;
        }

        public static Complex operator -(Complex a, Complex b)
        {
            Complex z = new Complex(a.Re - b.Re, a.Im - b.Im);
            return z;
        }

        public static Complex operator *(Complex a, Complex b)
        {
            double z_real = (a.Re * b.Re) - (a.Im * b.Im);
            double z_image = (a.Re * b.Im) + (b.Re * a.Im);
            Complex z = new Complex(z_real, z_image);
            return z;
        }

        public static Complex operator /(Complex a, Complex b)
        {
            double znam = (b.Re * b.Re) + (b.Im * b.Im);
            double z_real = ((a.Re * b.Re) + (a.Im * b.Im)) / znam;
            double z_image = (b.Re * a.Im) - (a.Re * b.Im) / znam;
            Complex z = new Complex(z_real, z_image);
            return z;
        }

        public static bool operator ==(Complex a, Complex b)
        {
            if (a.Re == b.Re && a.Im == b.Im)
                return true;
            else
                return false;
        }

        public static bool operator !=(Complex a, Complex b)
        {
            if (a.Re != b.Re || a.Im != b.Im)
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            string sign = "";
            if (this.Im >= 0)
                sign = "+";

            return (this.Re).ToString() +  sign + (this.Im).ToString() + "i";
        }

    }
}
