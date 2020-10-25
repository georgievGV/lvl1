using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> cars;

        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            this.cars = new List<Car>();
        }

        public string Type { get; set; }

        public int Capacity { get; set; }

        public int Count { get { return this.cars.Count; } }

        public void Add(Car car)
        {
            if (Count < Capacity)
            {
                this.cars.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Car removedCar = this.cars.FirstOrDefault(x => x.Manufacturer == manufacturer
            && x.Model == model);
            if (removedCar == null)
            {
                return false;
            }
            else
            {
                this.cars.Remove(removedCar);
                return true;
            }
        }

        public Car GetLatestCar()
        {
            if (this.cars.Count == 0)
            {
                return null;
            }
            else
            {
                List<Car> orderedByYear = this.cars.OrderByDescending(x => x.Year).ToList();
                Car latestOne = orderedByYear[0];
                return latestOne;
            }
        }

        public Car GetCar(string manufacturer, string model)
        {
            Car wantedCar = this.cars.FirstOrDefault(x => x.Manufacturer == manufacturer
            && x.Model == model);
            return wantedCar;
        }

        public string GetStatistics()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"The cars are parked in {Type}:");
            foreach (var car in this.cars)
            {
                result.AppendLine(car.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
