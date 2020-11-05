using System;

using FootballTeamGenerator.Common;

namespace FootballTeamGenerator.Models
{
    public class Player
    {
        private string name;
        private Stats stats;

        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.stats = stats;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.invalidNameInputMsg);
                }
                this.name = value;
            }
        }

        public Stats Stats
        {
            get
            {
                return this.stats;
            }
        }

        public double GetPlayerSkillLevel()
        {
            double skillLevel = (this.stats.Endurance + this.stats.Sprint + this.stats.Dribble
                + this.stats.Passing + this.stats.Shooting) / (double)5;
            return skillLevel;
        }
    }
}
