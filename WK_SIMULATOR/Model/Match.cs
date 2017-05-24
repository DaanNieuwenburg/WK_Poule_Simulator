using System;

namespace WK_SIMULATOR.Model
{
    public class Match
    {
        public Team Team_Home { get; set; }             // Home team
        public Team Team_Out { get; set; }              // Out team
        public int Points_Team_Home { get; set; }       // Amount of Goals team Home made
        public int Points_Team_Out { get; set; }        // Amount of Goals team Out made
        public int Match_Goaldiff_Home { get; set; }    // Goaldifference of team Home
        public int Match_Goaldiff_Out { get; set; }     // Goaldifference of team Out

        public Match(Team Home, Team Out)
        {
            Controller.MatchController matchcontroller = new Controller.MatchController();
            Team_Home = Home;
            Team_Out = Out;
            Console.WriteLine("new match created - H:" + Home.Teamname + " O:" + Out.Teamname);
            
            // Simulate a match and receive the outcome as a tuple
            Tuple<int, int> Result = matchcontroller.Simulate_Match(this);
            Points_Team_Home = Result.Item1;
            Points_Team_Out = Result.Item2;            
        }
    }
}
