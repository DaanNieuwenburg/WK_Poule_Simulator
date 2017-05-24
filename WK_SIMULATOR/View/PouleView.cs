using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WK_SIMULATOR.Model;

namespace WK_SIMULATOR.View
{

    public partial class PouleView : Form
    {
        public Poule current_Poule { get; set; } = new Poule();
        private Model.Team Team_A { get; set; }       // Team 1/4
        private Model.Team Team_B { get; set; }       // Team 2/4
        private Model.Team Team_C { get; set; }       // Team 3/4
        private Model.Team Team_D { get; set; }       // Team 4/4
        private List<Team> Poule_Teams;
        private int MatchesPlayed { get; set; } = 0;    // Count number of already played matches
        private ToolTip tooltip { get; set; } = new ToolTip();
        public PouleView()
        {
            InitializeComponent();
            // Use JsonReader to read the players from the json file
            JsonReader reader = new JsonReader();
            current_Poule.Playerlist = reader.Read_Players();
            current_Poule.Teamslist = new List<Team>();
            
            // Create the teams
            current_Poule.CreateTeams();
            // Divide Players by Country 
            Controller.TeamController.Divide_Players_ByTeam(current_Poule);

            // Pick a (non repeat) random number to choose the teams so that the matches are always random
            int[] randomnumbers = new int[4];            
            randomnumbers = Enumerable.Range(0, current_Poule.Teamslist.Count).OrderBy(g => Guid.NewGuid()).Take(4).ToArray();          
            Team_A = current_Poule.Teamslist[randomnumbers[0]];
            Team_B = current_Poule.Teamslist[randomnumbers[1]];
            Team_C = current_Poule.Teamslist[randomnumbers[2]];
            Team_D = current_Poule.Teamslist[randomnumbers[3]];

            //Check Picturebox tags to identify the team
            foreach (PictureBox picturebox in Controls.OfType<PictureBox>())
            {
                if (picturebox.Tag.ToString().Contains("TA"))
                    picturebox.Image = Team_A.Flag;
                else if (picturebox.Tag.ToString().Contains("TB"))
                    picturebox.Image = Team_B.Flag;
                else if (picturebox.Tag.ToString().Contains("TC"))
                    picturebox.Image = Team_C.Flag;
                else if (picturebox.Tag.ToString().Contains("TD"))
                    picturebox.Image = Team_D.Flag;
            }
            // Calculate teampower for each team
            for (int i = 0; i < current_Poule.Teamslist.Count; i++)
            {
                current_Poule.Teamslist[i].Power = Controller.CalculateController.Calculate_TeamPower(current_Poule.Teamslist[i]);
            }

            Poule_Teams = new List<Team>() { Team_A, Team_B, Team_C, Team_D };
        }
        private void Set_Score(int Homescore, int Outscore, Object buttontag)
        {
            foreach (Label label in Controls.OfType<Label>())
            {
                if(label.Tag != null)
                {
                    // Check which match the score is from
                    if (label.Tag.ToString().Contains(buttontag.ToString()[4]) && label.Tag.ToString().Contains(buttontag.ToString()[5]))
                    {
                        // Check if the label is Home or Out
                        if (label.Tag.ToString()[2] == 'H')
                        {
                            label.Text = Homescore.ToString();
                            label.Visible = true;
                        }
                        else
                        {
                            label.Text = Outscore.ToString();
                            label.Visible = true;
                        }
                    }
                }
            }
        }
        private void Check_PouleRank()
        {
            // Sort rank on: 1. Total points 2. Goaldifference  3. Goals For
            Poule_Teams = Poule_Teams.OrderByDescending(x => x.TotalScore).ThenByDescending(y => y.Goaldifference).ThenBy(z => z.Goals_For).ToList();
            #region Handles Tie Results
            // Check for Tie results 
            for (int i = 0; i < Poule_Teams.Count; i++)
            {
                Team team = Poule_Teams[i];
                if (i > 0)
                {
                    // Check if there is a tie result 
                    if(Poule_Teams[i-1].TotalScore == team.TotalScore && Poule_Teams[i-1].Goaldifference == team.Goaldifference && Poule_Teams[i-1].Goals_For == team.Goals_For)
                    {
                        Team[] mutualteams = new Team[2] { team, Poule_Teams[i - 1] };
                        // This loop and first if statement checks which match was mutual
                        foreach(Match mutualmatch in current_Poule.Matchlist)
                        {
                            if(mutualteams.Contains(mutualmatch.Team_Home) && mutualteams.Contains(mutualmatch.Team_Out))
                            {
                                // Check which team has most points in mutual match
                                if (mutualmatch.Points_Team_Home > mutualmatch.Points_Team_Out)
                                {
                                    Poule_Teams[i - 1] = mutualmatch.Team_Home;
                                    Poule_Teams[i] = mutualmatch.Team_Out;
                                }
                                else if(mutualmatch.Points_Team_Home < mutualmatch.Points_Team_Out)
                                {
                                    Poule_Teams[i] = mutualmatch.Team_Home;
                                    Poule_Teams[i-1] = mutualmatch.Team_Out;
                                }
                                // when amount of points are the same, check mutual goaldifference
                                else
                                {
                                    // Check which team has the best goaldifference
                                    if (mutualmatch.Match_Goaldiff_Home > mutualmatch.Match_Goaldiff_Out)
                                    {
                                        Poule_Teams[i - 1] = mutualmatch.Team_Home;
                                        Poule_Teams[i] = mutualmatch.Team_Out;
                                    }
                                    else if (mutualmatch.Match_Goaldiff_Home < mutualmatch.Match_Goaldiff_Out)
                                    {
                                        Poule_Teams[i] = mutualmatch.Team_Home;
                                        Poule_Teams[i-1] = mutualmatch.Team_Out;
                                    }
                                    // when both goaldifferences are tied, Out goals are doubled
                                    else
                                    {
                                        if (mutualmatch.Points_Team_Home > (mutualmatch.Points_Team_Out*2))
                                        {
                                            Poule_Teams[i - 1] = mutualmatch.Team_Home;
                                            Poule_Teams[i] = mutualmatch.Team_Out;
                                        }
                                        else if (mutualmatch.Points_Team_Home < (mutualmatch.Points_Team_Out*2))
                                        {
                                            Poule_Teams[i] = mutualmatch.Team_Home;
                                            Poule_Teams[i - 1] = mutualmatch.Team_Out;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            #endregion

            for (int i = 0; i < 2; i++)
            {
                if (i < 1)
                {
                    pb_KO1.Image = Poule_Teams[0].Flag;                        // Flag
                    lb_PointsA.Text = "P: " + Poule_Teams[0].TotalScore;       // Points team has earned
                    lb_WinsA.Text = "W: " + Poule_Teams[0].Total_Wins;         // Total wins
                    lb_GDA.Text = "DS: " + Poule_Teams[0].Goaldifference;      // Goal difference
                    lb_FA.Text = "V: " + Poule_Teams[0].Goals_For;             // Total Goals For
                    lb_AA.Text = "T: " + Poule_Teams[0].Goals_Against;         // Total Goals against
                }
                else
                {
                    pb_KO2.Image = Poule_Teams[1].Flag;                        // Flag
                    lb_PointsB.Text = "P: " + Poule_Teams[1].TotalScore;       // Points team has earned
                    lb_WinsB.Text = "W: " + Poule_Teams[1].Total_Wins;         // Total wins
                    lb_GDB.Text = "DS: " + Poule_Teams[1].Goaldifference;      // Goal difference
                    lb_FB.Text = "V: " + Poule_Teams[1].Goals_For;             // Total Goals For
                    lb_AB.Text = "T: " + Poule_Teams[1].Goals_Against;         // Total Goals against
                } 
            }
            #region Make elements visible
            // Makes elements visible
            foreach(Control element in Controls)
            {
                if(element.Tag != null)
                {
                    if (element.Tag.ToString().Contains("KO"))
                        element.Visible = true;
                }
            }
            #endregion
        }
        private void StartButton_Click(object sender, EventArgs e)
        {
            Team teamHome = new Team();
            Team teamOut = new Team();
            var ButtonTag = ((Button)sender).Tag;
            ((Button)sender).Visible = false;
            MatchesPlayed++;

            // Check the Home team
            if (ButtonTag.ToString()[2] == 'A')
                teamHome = Team_A;
            else if (ButtonTag.ToString()[2] == 'B')
                teamHome = Team_B;
            else if (ButtonTag.ToString()[2] == 'C')
                teamHome = Team_C;
            else
                teamHome = Team_D;

            // Check the Out team
            if (ButtonTag.ToString()[3] == 'A')
                teamOut = Team_A;
            else if (ButtonTag.ToString()[3] == 'B')
                teamOut = Team_B;
            else if (ButtonTag.ToString()[3] == 'C')
                teamOut = Team_C;
            else
                teamOut = Team_D;

            // Start a match, write score to view, and check how many matches are played
            Match match = new Match(teamHome, teamOut);
            // Add match to list of played matches
            current_Poule.Matchlist.Add(match);
            // Write score to labels
            Set_Score(match.Points_Team_Home, match.Points_Team_Out, ButtonTag);
            // Check amount of played matches
            if (MatchesPlayed == 6)
                Check_PouleRank();
        }
        private void bt_Restart_Click(object sender, EventArgs e)
        {
            View.PouleView Pouleview = new View.PouleView();
            Pouleview.Show();
            this.Close();
        }

        private void bt_Restart_MouseHover(object sender, EventArgs e)
        {
            tooltip.Show("Start new poule", bt_Restart);
        }
        private void Picturebox_Click(object sender, EventArgs e)
        {
            // Create a messagebox with team information when a flag has been clicked
            var PicboxTag = ((PictureBox)sender).Tag;
            if (PicboxTag.ToString().Contains("TA"))
                MessageBox.Show("Land: " + Team_A.Teamname + Environment.NewLine + "Kracht: " + Team_A.Power + Environment.NewLine + "Doelpunten voor: " + Team_A.Goals_For + Environment.NewLine + "Doelpunten tegen: " + Team_A.Goals_Against + Environment.NewLine + "Totaal Punten: " + Team_A.TotalScore + Environment.NewLine + "Totaal Doelsaldo: " + Team_A.Goaldifference); // show team A messagebox
            else if (PicboxTag.ToString().Contains("TB"))
                MessageBox.Show("Land: " + Team_B.Teamname + Environment.NewLine + "Kracht: " + Team_B.Power + Environment.NewLine + "Doelpunten voor: " + Team_B.Goals_For + Environment.NewLine + "Doelpunten tegen: " + Team_B.Goals_Against + Environment.NewLine + "Totaal Punten: " + Team_B.TotalScore + Environment.NewLine + "Totaal Doelsaldo: " + Team_B.Goaldifference); // show team B messagebox
            else if (PicboxTag.ToString().Contains("TC"))
                MessageBox.Show("Land: " + Team_C.Teamname + Environment.NewLine + "Kracht: " + Team_C.Power + Environment.NewLine + "Doelpunten voor: " + Team_C.Goals_For + Environment.NewLine + "Doelpunten tegen: " + Team_C.Goals_Against + Environment.NewLine + "Totaal Punten: " + Team_C.TotalScore + Environment.NewLine + "Totaal Doelsaldo: " + Team_C.Goaldifference); // show team C messagebox
            else
                MessageBox.Show("Land: " + Team_D.Teamname + Environment.NewLine + "Kracht: " + Team_D.Power + Environment.NewLine + "Doelpunten voor: " + Team_D.Goals_For + Environment.NewLine + "Doelpunten tegen: " + Team_D.Goals_Against + Environment.NewLine + "Totaal Punten: " + Team_D.TotalScore + Environment.NewLine + "Totaal Doelsaldo: " + Team_D.Goaldifference); // show team D messagebox
        }
    }
}
