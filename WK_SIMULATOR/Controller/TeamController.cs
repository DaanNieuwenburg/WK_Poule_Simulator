using System;
using WK_SIMULATOR.Model;

namespace WK_SIMULATOR.Controller
{
    public class TeamController
    {
        /// <summary>
        /// Split every player in the list over their country
        /// </summary>
        /// <param name="poule"></param>
        public static void Divide_Players_ByTeam(Poule poule)
        {
            for (int i = 0; i < poule.Playerlist.Count; i++)
            {
                Player player = poule.Playerlist[i];
                foreach(Team team in poule.Teamslist)
                {
                    // Check which team the player belongs to
                    if(player.Teamname == team.Teamname)
                    {
                        // Add the player to team's playerlist
                        team.Players.Add(player);
                        Console.WriteLine("Added: " + player.Name + " To: " + team.Teamname);
                    }
                }
            }
        }
    }
}
