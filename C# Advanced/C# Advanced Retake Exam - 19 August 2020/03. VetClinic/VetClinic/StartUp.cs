using System;

namespace VetClinic
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Clinic clinic = new Clinic(5);
            Pet dog = new Pet("Ellias", 5, "Tim");
            Pet cat = new Pet("Bella", 2, "Mia");
            Pet bunny = new Pet("Zak", 4, "Jon");
            Pet anotherDog = new Pet("Pesho", 7, "Ivan");

            clinic.Add(dog);
            clinic.Add(cat);
            clinic.Add(bunny);
            clinic.Add(anotherDog);
            Console.WriteLine(clinic.GetOldestPet());
            Console.WriteLine(clinic.Remove("Bellaa"));
            Console.WriteLine(clinic.GetPet("Bella", "Mia"));
            Console.WriteLine(clinic.Count);

            Console.WriteLine(clinic.GetStatistics());
        }
    }
}
