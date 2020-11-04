using System;

using PizzaCalories.Common;

namespace PizzaCalories.Models
{
    public class Topping
    {
        private const double meat = 1.2;
        private const double veggies = 0.8;
        private const double cheese = 1.1;
        private const double sauce = 0.9;
        private const double baseCaloriesPerGram = 2;
        private string type;
        private int grams;

        public Topping(string type, int grams)
        {
            this.Type = type;
            this.Grams = grams;
        }

        public string Type
        {
            get
            {
                return this.type;
            }
            private set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies"
                    && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException(string.Format(GlobalConstants.toppingExcMsg, value));
                }
                this.type = value;
            }
        }

        public int Grams
        {
            get
            {
                return this.grams;
            }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException(string.Format(GlobalConstants.toppingWeightExcMsg, this.Type));
                }
                this.grams = value;
            }
        }

        public double CalculateToppingCalories()
        {
            double toppingModifier = 0;

            switch (this.Type.ToLower())
            {
                case "meat":
                    toppingModifier = meat;
                    break;

                case "veggies":
                    toppingModifier = veggies;
                    break;

                case "cheese":
                    toppingModifier = cheese;
                    break;

                case "sauce":
                    toppingModifier = sauce;
                    break;
            }

            return baseCaloriesPerGram * this.grams * toppingModifier;
        }
    }
}
