using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> parkingLot;

        private int capacity;

        public Parking(int capacity)
        {
            this.capacity = capacity;

            this.parkingLot = new List<Car>();
        }

        public int Count
        {
            get
            {
                return parkingLot.Count;
            }
        }

        public string AddCar(Car car)
        {
            if (parkingLot.Exists(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (parkingLot.Count == this.capacity)
            {
                return "Parking is full!";
            }

            parkingLot.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";

        }

        public string RemoveCar(string registrationNumber)
        {
            Car car = parkingLot.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
            if (car == null)
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                parkingLot.Remove(car);
                return $"Successfully removed {car.RegistrationNumber}";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            return parkingLot.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var registrationNumber in registrationNumbers)
            {
                Car car = parkingLot.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
                parkingLot.Remove(car);
            }
        }
    }
}
