using System;

using PizzaCalories.Common;

namespace PizzaCalories.Models
{
    public class Dough
    {
        private const double white = 1.5;
        private const double wholegrain = 1.0;
        private const double crispy = 0.9;
        private const double chewy = 1.1;
        private const double homemade = 1.0;
        private const double baseCaloriesPerGram = 2;
        private int grams;

        public Dough(Flour flour, BakingTechnique technique, int grams)
        {
            this.Flour = flour;
            this.Technique = technique;
            this.Grams = grams;
        }

        public Flour Flour { get;}

        public BakingTechnique Technique { get;}

        public int Grams
        {
            get
            {
                return this.grams;
            }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(GlobalConstants.weightExcMsg);
                }

                this.grams = value;
            }
        }

        public double CalculateDoughCalories()
        {
            double flourModifier = 0;

            switch (this.Flour.Name.ToLower())
            {
                case "white":
                    flourModifier = white;
                    break;

                case "wholegrain":
                    flourModifier = wholegrain;
                    break;
            }

            double techniqueModifier = 0;

            switch (this.Technique.Name.ToLower())
            {
                case "crispy":
                    techniqueModifier = crispy;
                    break;

                case "chewy":
                    techniqueModifier = chewy;
                    break;

                case "homemade":
                    techniqueModifier = homemade;
                    break;
            }

            return baseCaloriesPerGram * this.grams * flourModifier * techniqueModifier;
        }
    }
}
