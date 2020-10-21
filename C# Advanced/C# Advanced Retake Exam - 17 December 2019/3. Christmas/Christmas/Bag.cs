using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Christmas
{
    public class Bag
    {
        private List<Present> list;

        public Bag(string color, int capacity)
        {
            Color = color;
            Capacity = capacity;
            list = new List<Present>();
        }

        public string Color { get; set; }

        public int Capacity { get; set; }

        public int Count
        {
            get
            {
                return list.Count;
            }
        }

        public void Add(Present present)
        {
            if (this.Count < this.Capacity )
            {
                list.Add(present);
            }
        }

        public bool Remove(string name)
        {
            if (list.Exists(x => x.Name == name))
            {
                Present removedPresent = list.FirstOrDefault(x => x.Name == name);
                list.Remove(removedPresent);
                return true;
            }

            return false;
        }

        public Present GetHeaviestPresent()
        {
            List<Present> orderedByWeight = list.OrderByDescending(x => x.Weight).ToList();
            Present heaviestOne = orderedByWeight[0];
            return heaviestOne;
        }

        public Present GetPresent(string name)
        {
            Present wanted = list.FirstOrDefault(x => x.Name == name);
            return wanted;

        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{this.Color} bag contains:");
            foreach (var present in list)
            {
                result.AppendLine(present.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
