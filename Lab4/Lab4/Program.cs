using System;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Character person = new NumberCharacter(177, 80.8, 19);
            person = new Statura(person, EnumStatura.Mesomorphic);
            person = new Sex(person, EnumSex.Man);
            person = new Activity(person, EnumActivity.Hight);
            Console.WriteLine(person.Description());
            Console.WriteLine($"Kkal used day: {person.CalculateCalories()}");


            Character person2 = new NumberCharacter(55, 167, 19);
            person2 = new Statura(person2, EnumStatura.Dolichomorphic);
            person2 = new Sex(person2, EnumSex.Man);
            person2 = new Activity(person2, EnumActivity.Midle);
            Console.WriteLine(person2.Description());
            Console.WriteLine($"Kkal used day: {person2.CalculateCalories()}");
        }
    }
}
