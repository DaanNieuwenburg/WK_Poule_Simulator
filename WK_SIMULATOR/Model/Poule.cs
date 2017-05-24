using System.Collections.Generic;

namespace WK_SIMULATOR.Model
{
    public class Poule
    {
        public List<Player> Playerlist { get; set; }                    // List of all players in the poule
        public List<Team> Teamslist { get; set; } = new List<Team>();   // List of all teams in the poule
        public List<Match> Matchlist { get; set; } = new List<Match>(); // List of all matches in the poule
        public void CreateTeams()
        {
            // Add all teams to the list
            Teamslist.Add(new Team { Teamname = "Nederland", Flag = Properties.Resources.Flag_Netherlands });
            Teamslist.Add(new Team { Teamname = "Duitsland", Flag = Properties.Resources.Flag_Germany });
            Teamslist.Add(new Team { Teamname = "Verenigde Staten", Flag = Properties.Resources.Flag_US });
            Teamslist.Add(new Team { Teamname = "Spanje", Flag = Properties.Resources.Flag_Spain });
            Teamslist.Add(new Team { Teamname = "Brazil", Flag = Properties.Resources.Flag_Brazil });
        }
    }
}
