using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> pets;

        public Clinic(int capacity)
        {
            Capacity = capacity;
            this.pets = new List<Pet>();
        }

        public int Capacity { get; set; }

        public int Count { get { return this.pets.Count; } }

        public void Add(Pet pet)
        {
            if (Count < Capacity)
            {
                this.pets.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            if (this.pets.Exists(x => x.Name == name))
            {
                Pet removed = this.pets.FirstOrDefault(x => x.Name == name);
                this.pets.Remove(removed);
                return true;
            }

            return false;
        }

        public Pet GetPet(string name, string owner)
        {
            Pet wanted = this.pets.FirstOrDefault(x => x.Name == name && x.Owner == owner);
            return wanted;
        }

        public Pet GetOldestPet()
        {
            List<Pet> orderedByAge = this.pets.OrderByDescending(x => x.Age).ToList();
            Pet oldestOne = orderedByAge[0];
            return oldestOne;
        }

        public string GetStatistics()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("The clinic has the following patients:");
            foreach (var pet in pets)
            {
                result.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
