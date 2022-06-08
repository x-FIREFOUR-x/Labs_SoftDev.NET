namespace Lab4
{
    public class NumberCharacter:Character
    {
        protected double height;
        protected double weight;
        protected uint age;

        public NumberCharacter(double height, double weight, uint age)
        {
            this.height = height;
            this.weight = weight;
            this.age = age;
        }

        public double CalculateCalories()
        {
            double calories = 0;
            calories = weight * height * (age / 5);
            return calories;
        }

        public string Description()
        {
            return ("Height: " + height + ", Width: " + weight + ", Age: "+ age );
        }

    }
}
