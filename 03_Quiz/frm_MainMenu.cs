using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03_Quiz
{
    public partial class frm_MainMenu : Form
    {
        PlayerInformation newPlayer;
        PlayerCollection collectPlayer;
        public frm_MainMenu()
        {
            InitializeComponent();
            newPlayer = new PlayerInformation();
        }
        public frm_MainMenu(ref PlayerInformation tempNewPlayer)
        {
            InitializeComponent();
            newPlayer = tempNewPlayer;
            Program.LoadObject(ref collectPlayer);
        }

        private void frm_MainMenu_Load(object sender, EventArgs e)
        {
            //Setting the username and highscore in the top left corner
            lbl_user.Text = newPlayer.Username;
            lbl_user.Visible = true;
            lbl_highscore.Text = Convert.ToString(collectPlayer.PlayersHighScore(newPlayer.Username));
            newPlayer.Score = 0;
        }
    }
}
