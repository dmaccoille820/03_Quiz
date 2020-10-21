using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03_Quiz
{
    [Serializable]
   public  class PlayerCollection
    {
        private List<PlayerInformation> playerlist = new List<PlayerInformation>();
        private int playerCount;
        public PlayerCollection()
        {
            playerCount = 0;
        }
        public int PlayerCount
        {
            get { return playerCount; }
        }
        public void AddPlayer(ref PlayerInformation newplayer)
        {
            //Adds a player to the list
            playerlist.Add(newplayer);
        }
        public int FindIndex(string username)
        {
            //Returns players index number 
            PlayerInformation p = null;
            bool found = false;
            int i = playerCount - 1;

            while (i >= 0 && found == false)
            {
                p = playerlist[i];

                if (p.Username == username)
                {
                    found = true;
                }
                else
                {
                    i = i - 1;
                }
            }
            return i;
        }
        public PlayerInformation GetPlayer(string username)
        {
            //Finding a player based on their username
            PlayerInformation thisPlayer;
            thisPlayer = playerlist.Find(player => player.Username == username);
            return thisPlayer;
        }
        public int PlayersHighScore(string username)
        {
            //Finding a users highscore based on their username
            PlayerInformation thisPlayer;
            thisPlayer = playerlist.Find(player => player.Username == username);
            return thisPlayer.Score;

        }
        public void sortList()
        {
            // Array.Sort(playerlist);
            playerlist.Sort();
        }
        public void displayHighscores(ref ListBox thisList)
        {
            //Displaying the user data in the listbox
            foreach (PlayerInformation c in playerlist)
            {
                if (c.Score > 0)
                    thisList.Items.Add(c);
            }
        }


    }
}
