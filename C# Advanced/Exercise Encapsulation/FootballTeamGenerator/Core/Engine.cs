using System;
using System.Collections.Generic;
using System.Linq;
using FootballTeamGenerator.Models;

using FootballTeamGenerator.Common;

namespace FootballTeamGenerator.Core
{
    public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            string command = Console.ReadLine();
            List<Team> teams = new List<Team>();

            while (command != "END")
            {
                try
                {
                    string[] info = command.Split(';', StringSplitOptions.RemoveEmptyEntries);

                    if (info[0] == "Team")
                    {
                        Team team = new Team();

                        if (info.Length == 1)
                        {
                            team.Name = null;
                        }

                        team.Name = info[1];
                        teams.Add(team);
                    }

                    else if (info[0] == "Add")
                    {
                        string teamName = info[1];

                        if (teams.Exists(x => x.Name == info[1]))
                        {
                            Player currentPlayer = ParsePlayer(info);
                            Team currentTeam = teams.First(x => x.Name == teamName);
                            currentTeam.AddPlayer(currentPlayer);
                        }
                        else
                        {
                            throw new ArgumentException
                                (string.Format(GlobalConstants.missingTeamMsg, teamName));
                        }
                    }

                    else if (info[0] == "Remove")
                    {
                        string teamName = info[1];

                        if (teams.Exists(x => x.Name == info[1]))
                        {
                            string playerName = info[2];
                            Team currentTeam = teams.First(x => x.Name == teamName);
                            currentTeam.RemovePlayer(playerName);
                        }
                        else
                        {
                            throw new ArgumentException
                                (string.Format(GlobalConstants.missingTeamMsg, teamName));
                        }
                    }

                    else if (info[0] == "Rating")
                    {
                        string teamName = info[1];

                        if (teams.Exists(x => x.Name == info[1]))
                        {
                            Team currentTeam = teams.First(x => x.Name == teamName);
                            Console.WriteLine($"{currentTeam.Name} - {currentTeam.GetRating()}");
                        }
                        else
                        {
                            throw new ArgumentException
                                (string.Format(GlobalConstants.missingTeamMsg, teamName));
                        }
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

                command = Console.ReadLine();
            }



        }

        private Player ParsePlayer(string[] info)
        {
            Stats stats = new Stats(int.Parse(info[3]), int.Parse(info[4]),
                                            int.Parse(info[5]), int.Parse(info[6]), int.Parse(info[7]));
            Player player = new Player(info[2], stats);

            return player;
        }
    }
}
