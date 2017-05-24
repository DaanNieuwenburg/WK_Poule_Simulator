using System;
using WK_SIMULATOR.Model;

namespace WK_SIMULATOR.Controller
{ 
    public class CalculateController
    {
        /// <returns>Return teampower</returns>
        public static int Calculate_TeamPower(Model.Team team)
        {
            int totalSkills = 0;
            foreach (Player player in team.Players)
            {
                totalSkills += player.SkillLvl;
            }
            // formula to calculate the teamskills
            int teamPower = Convert.ToInt32(totalSkills / 11);         // 55 points max / 11 = 5 points
            return teamPower;
        }
        /// <summary>
        /// Add each players skills to the teams goalchance per minute.
        /// </summary>
        /// <param name="match"></param>
        public static void Add_PlayerSkills_to_Team(Match match)
        {
            // loop through both teams  0 = Home  1 = Out
            for (int x = 0; x < 2; x++) 
            {
                Team tempTeam = new Team();
                if (x == 0)
                    tempTeam = match.Team_Home;
                else
                    tempTeam = match.Team_Out;
                for (int y = 0; y < tempTeam.Players.Count; y++)
                {
                    Player player = tempTeam.Players[y];
                    double playerchance = player.SkillLvl / 100;    // convert to percentage 
                    // if player is a keeper or defender --> scorechance(%) per minute is decreasing for opponent team
                    if (player.Position == 'K' || player.Position == 'D')
                    {
                        if (x == 0)
                            match.Team_Out.ScoreChangeperMin -= playerchance;
                        else
                            match.Team_Home.ScoreChangeperMin -= playerchance;
                    }
                    else // if the player is an attacker or mid --> scorechance(%) per minute is increasing for it's own team
                    {
                        if (x == 0)
                            match.Team_Home.ScoreChangeperMin += playerchance;
                        else
                            match.Team_Out.ScoreChangeperMin += playerchance;
                    }
                }
            }
        }
        public static void Calculate_Score(Tuple<int,int> Score, Match match)
        {
            // Winner gets 3 points, Loser gets 0 points, Tie = both teams get 1 point
            // Home wins
            if (Score.Item1 > Score.Item2)
            {
                match.Team_Home.Total_Wins += 1;
                match.Team_Home.TotalScore += 3;
            }
            // Out wins
            else if(Score.Item1 < Score.Item2)
            {
                match.Team_Out.Total_Wins += 1;
                match.Team_Out.TotalScore += 3;
            }
            // Tie
            else if(Score.Item1 == Score.Item2)
            {
                match.Team_Home.TotalScore += 1;
                match.Team_Out.TotalScore += 1;
            }
        }
        
    }
}
