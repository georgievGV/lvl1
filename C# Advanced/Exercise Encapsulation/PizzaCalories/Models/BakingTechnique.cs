using System;

using PizzaCalories.Common;

namespace PizzaCalories.Models
{
    public class BakingTechnique
    {
        private string name;

        public BakingTechnique(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" 
                    && value.ToLower() != "homemade")
                {
                    throw new ArgumentException(GlobalConstants.flourTechniqueExcMsg);
                }

                this.name = value;
            }
        }
    }
}
