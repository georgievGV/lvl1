using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string tires = Console.ReadLine();
            List<double[]> allTires = new List<double[]>();
            while (tires != "No more tires")
            {
                double[] tireInfo = tires.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                allTires.Add(tireInfo);

                tires = Console.ReadLine();
            }

            string engines = Console.ReadLine();
            List<double[]> allEngines = new List<double[]>();

            while (engines != "Engines done")
            {
                double[] engineInfo = engines.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                allEngines.Add(engineInfo);

                engines = Console.ReadLine();
            }

            string car = Console.ReadLine();
            List<Car> garage = new List<Car>();

            while (car != "Show special")
            {
                string[] carInfo = car.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity = double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]);
                int engineIndex = int.Parse(carInfo[5]);
                int tiresIndex = int.Parse(carInfo[6]);
                Engine currEngine = new Engine((int)allEngines[engineIndex][0], allEngines[engineIndex][1]);
                Tire[] currTires = new Tire[]
                {
                    new Tire((int)allTires[tiresIndex][0], allTires[tiresIndex][1]),
                    new Tire((int)allTires[tiresIndex][2], allTires[tiresIndex][3]),
                    new Tire((int)allTires[tiresIndex][4], allTires[tiresIndex][5]),
                    new Tire((int)allTires[tiresIndex][6], allTires[tiresIndex][7]),
                };
                Car currCar = new Car(make, model, year, fuelQuantity, fuelConsumption, currEngine, currTires);
                garage.Add(currCar);

                car = Console.ReadLine();
            }

            List<Car> specialCars = garage.Where(x => x.Year >= 2017).Where(x => x.Engine.HorsePower > 330)
                .Where(x => x.Tires.Sum(x => x.Pressure) >= 9 && x.Tires.Sum(x => x.Pressure) <= 10).ToList();
            double fuelQuantityLeft = 0;

            foreach (var thisCar in specialCars)
            {
                fuelQuantityLeft = thisCar.FuelQuantity - (thisCar.FuelConsumption / 5);
                Console.WriteLine($"Make: {thisCar.Make}\nModel: {thisCar.Model}\nYear: {thisCar.Year}" +
                    $"\nHorsPowers: {thisCar.Engine.HorsePower}\nFuelQuantity: {fuelQuantityLeft}");
            }
        }
    }
}
