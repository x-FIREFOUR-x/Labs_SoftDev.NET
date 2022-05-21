using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    public class Decorator : Character
    {
        protected Character character;

        public Decorator(Character character)
        {
            this.character = character;
        }
        public virtual double CalculateCalories()
        {
            return character.CalculateCalories();
        }

    }
}
