using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = engineInfo[0];
                int power = int.Parse(engineInfo[1]);
                Engine engine = new Engine(model, power);

                if (engineInfo.Length == 3)
                {
                    bool isDisplacement = true;
                    for (int j = 0; j < engineInfo[2].Length; j++)
                    {
                        if (!char.IsDigit(engineInfo[2][j]))
                        {
                            isDisplacement = false;
                            break;
                        }
                    }

                    if (isDisplacement)
                    {
                        string displacement = engineInfo[2];
                        engine.Displacement = displacement;
                    }
                    else
                    {
                        string efficiency = engineInfo[2];
                        engine.Efficiency = efficiency;
                    }
                }

                else if (engineInfo.Length > 3)
                {
                    string displacement = engineInfo[2];
                    engine.Displacement = displacement;
                    string efficiency = engineInfo[3];
                    engine.Efficiency = efficiency;
                }

                engines.Add(engine);
            }

            int m = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < m; i++)
            {
                string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = carInfo[0];
                string engine = carInfo[1];
                Engine current = engines.FirstOrDefault(x => x.Model == engine);
                Car car = new Car(model, current);

                if (carInfo.Length == 3)
                {
                    bool isWeight = true;
                    for (int j = 0; j < carInfo[2].Length; j++)
                    {
                        if (!char.IsDigit(carInfo[2][j]))
                        {
                            isWeight = false;
                            break;
                        }
                    }

                    if (isWeight)
                    {
                        string weight = carInfo[2];
                        car.Weight = weight;
                    }
                    else
                    {
                        string color = carInfo[2];
                        car.Color = color;
                    }
                }
                else if (carInfo.Length > 3)
                {
                    string weight = carInfo[2];
                    car.Weight = weight;
                    string color = carInfo[3];
                    car.Color = color;
                }

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString()); ;
            }
        }
    }
}
