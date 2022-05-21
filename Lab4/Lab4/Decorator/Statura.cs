using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    enum EnumStatura
    {
        Mesomorphic,
        Brachymorphic,
        Dolichomorphic
    }
    class Statura : Decorator
    {
        private EnumStatura statura;

        public Statura(Character c, EnumStatura statura)
            : base(c)
        {
            this.statura = statura;
        }

        public override double CalculateCalories()
        {
            double calories = 0;

            switch (statura)
            {
                case EnumStatura.Mesomorphic:
                    calories = 1.25;
                    break;
                case EnumStatura.Brachymorphic:
                    calories = 1;
                    break;
                case EnumStatura.Dolichomorphic:
                    calories = 0.75;
                    break;
                default:
                    break;
            }

            return this.character.CalculateCalories() * calories;
        }

        public override string Description()
        {
            return (this.character.Description() + ", Statura body: " + statura.ToString());
        }
    }
}
