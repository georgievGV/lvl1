using System;
using System.Collections.Generic;
using System.Linq;
using FootballTeamGenerator.Common;

namespace FootballTeamGenerator.Models
{
    public class Team
    {
        private readonly List<Player> players;
        private string name;

        public Team()
        {
            players = new List<Player>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.invalidNameInputMsg);
                }
                this.name = value;
            }
        }

        public int GetRating()
        {
            double total = 0;
            foreach (var player in players)
            {
                total += player.GetPlayerSkillLevel();
            }

            if (players.Count == 0)
            {
                return 0;
            }
            return (int)Math.Round(total / players.Count);
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            if (!players.Exists(x=>x.Name == name))
            {
                throw new ArgumentException
                    (string.Format(GlobalConstants.missingPlayerMsg, name, this.Name));
            }

            Player player = players.First(x => x.Name == name);
            players.Remove(player);
        }
    }
}
