using System;
using WK_SIMULATOR.Model;

namespace WK_SIMULATOR.Controller
{
    public class MatchController
    {
        /// <summary>
        /// Simulates the match
        /// </summary>
        /// <param name="match"></param>
        /// <returns>Returns the MatchResult</returns>
        public Tuple<int,int> Simulate_Match(Model.Match match)
        {
            // Calculate both team their skills
            int homeskills = CalculateController.Calculate_TeamPower(match.Team_Home);
            int outskills = CalculateController.Calculate_TeamPower(match.Team_Out);

            Random r = new Random();
            int Homepoints = 0;
            int Outpoints = 0;

            //Calculate change of goal per minute
            match.Team_Home.ScoreChangeperMin = match.Team_Home.Power / 2;
            match.Team_Out.ScoreChangeperMin = match.Team_Out.Power / 2;

            // Add individual player skills to increase or decrease goalchance
            CalculateController.Add_PlayerSkills_to_Team(match);

            // simulates the match
            for (int i = 0; i < 2; i++)     // loop through both teams
            {
                Team tempteam = new Team();
                if (i == 0)
                    tempteam = match.Team_Home;
                else
                    tempteam = match.Team_Out;
                for (int j = 0; j < 91; j++)    // loop through 90 match minutes
                {
                    int a = r.Next(0, 100);
                    if (a < tempteam.ScoreChangeperMin) // a is a random number from 0 to 100. If a falls within the range of the score (a < score), there is a goal, otherwise not
                    {
                        tempteam.Goals_For += 1;
                        if (i == 0)
                            Homepoints += 1;
                        else
                            Outpoints += 1;
                    }
                }
            }

            // Count the goal difference 
            match.Team_Home.Goaldifference += Homepoints - Outpoints;
            match.Team_Out.Goaldifference += Outpoints - Homepoints;
            match.Match_Goaldiff_Home = Homepoints - Outpoints;
            match.Match_Goaldiff_Out = Outpoints - Homepoints;

            // set goals Against for both teams
            match.Team_Home.Goals_Against += Outpoints;
            match.Team_Out.Goals_Against += Homepoints;
            
            // Return the match result
            Tuple<int, int> MatchResult = Tuple.Create(Homepoints, Outpoints);
            CalculateController.Calculate_Score(MatchResult, match);
            return MatchResult;
        }
        
    }
}
