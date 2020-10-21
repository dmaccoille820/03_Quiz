using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Quiz
{
    [Serializable]
    public class PlayerInformation : IComparable<PlayerInformation>
    {
        private string username;
        private string password;
        private int score;
        public int Score { get;  set; }
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        int IComparable<PlayerInformation>.CompareTo(PlayerInformation p)
        {
            if (this.Score < p.Score)
                return 1;
            else if (this.Score > p.Score)
                return -1;
            else
                return 0;
        }
        public PlayerInformation()
        {
            username = "";
            password = "";
            score = 0;
        }
        public PlayerInformation(string _username, string _password, int _score)
        {
            username = _username;
            password = _password;
            score = _score;
        }
        public override string ToString()
        {
            return Convert.ToString(score) + "  " + Username;
        }

    }
}
