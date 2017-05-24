using System;
using System.Drawing;
using System.Windows.Forms;

namespace WK_SIMULATOR
{
    public partial class Mainview : Form
    {  
        public Mainview()
        {
            InitializeComponent();
            choose_Background();
        }
        // Choose a random background 
        private void choose_Background()
        {
            Image[] Backgroundlist = new Image[3]{ Properties.Resources.main_background1, Properties.Resources.main_background2, Properties.Resources.main_background3 };
            Random random = new Random();
            int index = random.Next(0, 3);
            this.BackgroundImage = Backgroundlist[index];
        }
        private void bt_Start_Click(object sender, EventArgs e)
        {
            View.PouleView Pouleview = new View.PouleView();
            Pouleview.Show();
            this.Hide();        
        }
        private void bt_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #region Mouse events
        // This 4 events handles the image change when hovering or leaving a button
        private void bt_Start_MouseEnter(object sender, EventArgs e)
        {
            bt_Start.BackgroundImage = Properties.Resources.start_button_enter;
        }

        private void bt_Start_MouseLeave(object sender, EventArgs e)
        {
            bt_Start.BackgroundImage = Properties.Resources.start_button_leave;
        }

        private void bt_Close_MouseEnter(object sender, EventArgs e)
        {
            bt_Close.BackgroundImage = Properties.Resources.close_button_enter;
        }

        private void bt_Close_MouseLeave(object sender, EventArgs e)
        {
            bt_Close.BackgroundImage = Properties.Resources.close_button_leave;
        }
        #endregion
        
    }
}
