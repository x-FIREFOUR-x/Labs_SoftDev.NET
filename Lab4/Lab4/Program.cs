using System;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Character person = new NumberCharacter(10, 10, 10);
            person = new Statura(person, EnumStatura.Mesomorphic);
            person = new Sex(person, EnumSex.Man);
            person = new Activity(person, EnumActivity.Hight);
            Console.WriteLine(person.Description());
            Console.WriteLine($"Kkal used day: {person.CalculateCalories()}");

        }
    }
}
