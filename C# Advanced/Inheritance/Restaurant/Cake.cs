using System;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double defaultGrams = 250;
        private const double defaultCalories = 1000;
        private const decimal defaultCakePrise = 5;

        public Cake(string name)
            : base(name, defaultCakePrise, defaultGrams, defaultCalories)
        {
        }
    }
}
