using System;
using System.Text;

namespace SoftUniParking
{
    public class Car
    {
        public Car(string make, string model, int horsPower, string registrationNumber)
        {
            Make = make;
            Model = model;
            HorsPower = horsPower;
            RegistrationNumber = registrationNumber;
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public int HorsPower { get; set; }

        public string RegistrationNumber { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Make: {Make}");
            result.AppendLine($"Model: {Model}");
            result.AppendLine($"HorsePower: {HorsPower}");
            result.AppendLine($"RegistrationNumber: {RegistrationNumber}");

            return result.ToString().TrimEnd();
        }
    }
}
