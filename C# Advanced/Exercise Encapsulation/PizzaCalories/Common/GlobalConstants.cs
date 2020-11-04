using System;

namespace PizzaCalories.Common
{
    public static class GlobalConstants
    {
        public const string flourTechniqueExcMsg = "Invalid type of dough.";
        public const string weightExcMsg = "Dough weight should be in the range [1..200].";
        public const string toppingExcMsg = "Cannot place {0} on top of your pizza.";
        public const string toppingWeightExcMsg = "{0} weight should be in the range [1..50].";
        public const string numberOfToppingsExcMsg = "Number of toppings should be in range [0..10].";
        public const string pizzaNameExcMsg = "Pizza name should be between 1 and 15 symbols.";

    }
}
