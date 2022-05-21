using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    enum EnumSex
    {
        Man,
        Woman
    }
    class Sex:Decorator
    {
        private EnumSex sex;

        public Sex(Character c, EnumSex sex) 
            :base(c)
        {
            this.sex = sex;
        }

        public override double CalculateCalories()
        {
            double calories = 0;
            if (sex == EnumSex.Man)
                calories = 1.5;
            else
                calories = 1;
            return (this.character.CalculateCalories() * calories);
        }
    }
}
