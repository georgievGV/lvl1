using System;

namespace FootballTeamGenerator.Common
{
    public static class GlobalConstants
    {
        public const string invalidNameInputMsg = "A name should not be empty.";
        public const string invalidStatsInputMsg = "{0} should be between 0 and 100.";
        public const string missingPlayerMsg = "Player {0} is not in {1} team.";
        public const string missingTeamMsg = "Team {0} does not exist.";
    }
}
