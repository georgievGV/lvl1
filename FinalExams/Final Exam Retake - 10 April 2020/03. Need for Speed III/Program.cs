using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Need_for_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] info = input.Split("|");
                string car = info[0];
                int mileage = int.Parse(info[1]);
                int fuel = int.Parse(info[2]);
                if (fuel > 75)
                {
                    fuel = 75;
                }

                Car currentCar = new Car(mileage, fuel);
                if (!cars.ContainsKey(car))
                {
                    cars.Add(car, currentCar);
                }
            }
            string command = Console.ReadLine();

            while (command != "Stop")
            {
                string[] commands = command.Split(" : ");

                switch (commands[0])
                {
                    case "Drive":
                        if (cars.ContainsKey(commands[1]))
                        {
                            if (cars[commands[1]].Fuel < int.Parse(commands[3]))
                            {
                                Console.WriteLine("Not enough fuel to make that ride");
                            }
                            else
                            {
                                cars[commands[1]].Mileage += int.Parse(commands[2]);
                                cars[commands[1]].Fuel -= int.Parse(commands[3]);
                                Console.WriteLine($"{commands[1]} driven for {int.Parse(commands[2])} " +
                                    $"kilometers. {int.Parse(commands[3])} liters of fuel consumed.");
                            }

                            if (cars[commands[1]].Mileage >= 100000)
                            {
                                cars.Remove(commands[1]);
                                Console.WriteLine($"Time to sell the {commands[1]}!");
                            }
                        }

                        break;

                    case "Refuel":

                        if (cars.ContainsKey(commands[1]))
                        {
                            int initialFuel = cars[commands[1]].Fuel;
                            int fuelRefueled = 0;
                            cars[commands[1]].Fuel += int.Parse(commands[2]);
                            if (cars[commands[1]].Fuel > 75)
                            {
                                cars[commands[1]].Fuel = 75;
                                fuelRefueled = 75 - initialFuel;
                            }
                            else
                            {
                                fuelRefueled = int.Parse(commands[2]);
                            }

                            Console.WriteLine($"{commands[1]} refueled with {fuelRefueled} liters");
                        }

                        break;

                    case "Revert":

                        if (cars.ContainsKey(commands[1]))
                        {
                            cars[commands[1]].Mileage -= int.Parse(commands[2]);

                            if (cars[commands[1]].Mileage < 10000)
                            {
                                cars[commands[1]].Mileage = 10000;
                            }
                            else
                            {
                                Console.WriteLine($"{commands[1]} mileage decreased by " +
                                    $"{int.Parse(commands[2])} kilometers");
                            }
                        }
                        break;
                }

                command = Console.ReadLine();
            }

            cars = cars.OrderByDescending(x => x.Value.Mileage)
                .ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var item in cars)
            {
                Console.WriteLine($"{item.Key} -> Mileage: {item.Value.Mileage} kms, Fuel in the tank: {item.Value.Fuel} lt.");
            }
        }
    }

    class Car
    {
        public int Mileage { get; set; }
        public int Fuel { get; set; }

        public Car(int mileage, int fuel)
        {
            Mileage = mileage;
            Fuel = fuel;
        }
    }


}
