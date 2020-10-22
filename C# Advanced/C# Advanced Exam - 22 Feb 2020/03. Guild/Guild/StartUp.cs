using System.Linq;

namespace Guild
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Guild guild = new Guild("Weekend Raiders", 20);
            Player player = new Player("Mark", "Rogue");
            System.Console.WriteLine(player);

            guild.AddPlayer(player);
            System.Console.WriteLine(guild.Count);

            System.Console.WriteLine(guild.RemovePlayer("Gosho"));

            Player firstPlayer = new Player("Pep", "Warrior");
            Player secondPlayer = new Player("Lizzy", "Priest");
            Player thirdPlayer = new Player("Mike", "Rogue");
            Player fourthPlayer = new Player("Marlin", "Mage");

            secondPlayer.Description = "Best healer EU";

            guild.AddPlayer(firstPlayer);
            guild.AddPlayer(secondPlayer);
            guild.AddPlayer(thirdPlayer);
            guild.AddPlayer(fourthPlayer);

            guild.PromotePlayer("Lizzy");
            System.Console.WriteLine(secondPlayer.Rank);

            Player[] kickedPlayers = guild.KickPlayersByClass("Rogue");

            System.Console.WriteLine(string.Join(" ", kickedPlayers.Select(x=>x.Name)));
            System.Console.WriteLine(guild.Count);
            System.Console.WriteLine(guild.Report());


        }
    }
}
