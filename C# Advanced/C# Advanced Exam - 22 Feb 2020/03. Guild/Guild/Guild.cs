using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> list;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.list = new List<Player>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count
        {
            get
            {
                return this.list.Count;
            }
        }

        public void AddPlayer(Player player)
        {
            if (Count < Capacity)
            {
                this.list.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            if (this.list.Exists(x => x.Name == name))
            {
                Player removedOne = this.list.FirstOrDefault(x => x.Name == name);
                this.list.Remove(removedOne);
                return true;
            }

            return false;
        }

        public void PromotePlayer(string name)
        {
            Player theOne = this.list.FirstOrDefault(x => x.Name == name);
            if (theOne != null && theOne.Rank != "Member")
            {
                theOne.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            Player theOne = this.list.FirstOrDefault(x => x.Name == name);
            if (theOne != null && theOne.Rank != "Trial")
            {
                theOne.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string name)
        {
            Player[] kickedPlayers = this.list.Where(x => x.Class == name).ToArray();
            for (int i = 0; i < kickedPlayers.Length; i++)
            {
                for (int j = 0; j < this.list.Count; j++)
                {
                    if (kickedPlayers[i] == this.list[j])
                    {
                        this.list.RemoveAt(j);
                    }
                }
            }

            return kickedPlayers;
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Players in the guild: {Name}");
            foreach (var player in this.list)
            {
                result.AppendLine(player.ToString());
            }

            return result.ToString().TrimEnd();
        }

    }
}
