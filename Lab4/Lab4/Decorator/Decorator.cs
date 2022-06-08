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

        public virtual string Description()
        {
            return character.Description();
        }

    }
}
