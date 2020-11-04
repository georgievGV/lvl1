using System;

using PizzaCalories.Common;

namespace PizzaCalories.Models
{
    public class Flour
    {
        private string name;

        public Flour(string name)
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
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException(GlobalConstants.flourTechniqueExcMsg);
                }

                this.name = value;
            }
        }
    }
}
