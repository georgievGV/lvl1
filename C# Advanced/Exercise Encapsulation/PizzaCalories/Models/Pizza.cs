using System;
using System.Collections.Generic;
using System.Text;
using PizzaCalories.Common;

namespace PizzaCalories.Models
{
    public class Pizza
    {
        private List<Topping> toppings;
        private string name;
        private double totalToppingCalories;

        public Pizza()
        {
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException(GlobalConstants.pizzaNameExcMsg);
                }
                this.name = value;
            }
        }

        public Dough Dough { get; set; }

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count >= 10)
            {
                throw new ArgumentException(GlobalConstants.numberOfToppingsExcMsg);
            }

            this.toppings.Add(topping);
            totalToppingCalories += topping.CalculateToppingCalories();
        }

        private double CalculateTotalCalories()
        {
            double doughCalories = this.Dough.CalculateDoughCalories();

            return totalToppingCalories + doughCalories;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.CalculateTotalCalories():f2} Calories.";
        }
    }
}
