using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private List<Rabbit> data;

        public Cage(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Rabbit>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count
        {
            get
            {
                return data.Count;
            }
        }

        public void Add(Rabbit rabbit)
        {
            if (this.Count < this.Capacity)
            {
                data.Add(rabbit);
            }
        }

        public bool RemoveRabbit(string name)
        {
            if (data.Exists(x => x.Name == name))
            {
                Rabbit unwanted = data.FirstOrDefault(x => x.Name == name);
                data.Remove(unwanted);
                return true;
            }

            return false;
        }

        public void RemoveSpecies(string species)
        {
            data.RemoveAll(x => x.Species == species);
        }

        public Rabbit SellRabbit(string name)
        {
            Rabbit rabbitToSell = data.FirstOrDefault(x => x.Name == name);
            rabbitToSell.Available = false;

            return rabbitToSell;
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            List<Rabbit> rabbitsToSell = data.FindAll(x => x.Species == species);
            foreach (Rabbit rabbit in rabbitsToSell)
            {
                rabbit.Available = false;
            }

            return rabbitsToSell.ToArray();
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Rabbits available at {Name}:");
            foreach (Rabbit rabbit in data)
            {
                if (rabbit.Available == true)
                {
                    result.AppendLine(rabbit.ToString());
                }
            }
            return result.ToString().TrimEnd();
        }

    }
}
