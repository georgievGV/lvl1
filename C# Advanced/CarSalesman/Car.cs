using System;

namespace CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public string Weight { get; set; } = "n/a";

        public string Color { get; set; } = "n/a";

        public override string ToString()
        {
            return $"{Model}:\n  {Engine.Model}:\n    Power: {Engine.Power}\n    Displacement: {Engine.Displacement}\n    Efficiency: {Engine.Efficiency}" +
                $"\n  Weight: {Weight}\n  Color: {Color}";
        }
    }
}
