using System;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Character person = new NumberCharacter(10, 10, 10);

            Console.WriteLine(person.CalculateCalories());

            person = new Sex(person, EnumSex.Man);
            Console.WriteLine(person.CalculateCalories());

            person = new Statura(person, EnumStatura.Mesomorphic);
            Console.WriteLine(person.CalculateCalories());

            person = new Activity(person, EnumActivity.Hight);
            Console.WriteLine(person.CalculateCalories());

        }
    }
}
