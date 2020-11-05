using System;

using FootballTeamGenerator.Common;

namespace FootballTeamGenerator.Models
{
    public class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get
            {
                return this.endurance;
            }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException
                        (string.Format(GlobalConstants.invalidStatsInputMsg, nameof(Endurance)));
                }
                this.endurance = value;
            }
        }

        public int Sprint
        {
            get
            {
                return this.sprint;
            }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException
                        (string.Format(GlobalConstants.invalidStatsInputMsg, nameof(Sprint)));
                }
                this.sprint = value;
            }
        }

        public int Dribble
        {
            get
            {
                return this.dribble;
            }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException
                        (string.Format(GlobalConstants.invalidStatsInputMsg, nameof(Dribble)));
                }
                this.dribble = value;
            }
        }

        public int Passing
        {
            get
            {
                return this.passing;
            }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException
                        (string.Format(GlobalConstants.invalidStatsInputMsg, nameof(Passing)));
                }
                this.passing = value;
            }
        }

        public int Shooting
        {
            get
            {
                return this.shooting;
            }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException
                        (string.Format(GlobalConstants.invalidStatsInputMsg, nameof(Shooting)));
                }
                this.shooting = value;
            }
        }
    }
}
