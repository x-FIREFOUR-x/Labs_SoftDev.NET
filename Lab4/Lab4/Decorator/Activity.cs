using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    enum EnumActivity
    {
        Hight,
        Midle,
        Low
    }

    class Activity : Decorator
    {
        private EnumActivity activity;

        public Activity(Character c, EnumActivity activity)
            : base(c)
        {
            this.activity = activity;
        }

        public override double CalculateCalories()
        {
            double calories = 0;

            switch (activity)
            {
                case EnumActivity.Hight:
                    calories = 1.5;
                    break;
                case EnumActivity.Midle:
                    calories = 1.25;
                    break;
                case EnumActivity.Low:
                    calories = 1.0;
                    break;
                default:
                    break;
            }

            return this.character.CalculateCalories() * calories;
        }

        public override string Description()
        {
            return (this.character.Description() + ", Level activity: " + activity.ToString());
        }
    }
}
