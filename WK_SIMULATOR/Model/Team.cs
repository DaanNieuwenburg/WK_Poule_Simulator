using System.Collections.Generic;
using System.Drawing;

namespace WK_SIMULATOR.Model
{
    public class Team
    {
        public string Teamname { get; set; }                        // The name of the team
        public int Power { get; set; }                              // How strong the team is
        public Image Flag { get; set; }                             // Image of the team's Flag
        public int Goaldifference { get; set; }                     // Total goaldifference 
        public double ScoreChangeperMin { get; set; }               // Chance(%) per minute for a team to score
        public int TotalScore { get; set; }                         // Score based on Win, Tie or Lose
        public int Goals_For { get; set; } = 0;
        public int Goals_Against { get; set; } = 0;
        public int Total_Wins { get; set; } = 0;                    // Total Wins
        public List<Player> Players { get; set; } = new List<Player>(); // Players of the team
    }
}
