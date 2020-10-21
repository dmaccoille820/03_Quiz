using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03_Quiz
{
    public partial class frm_Login : Form
    {

        PlayerCollection collectPlayer;
        PlayerInformation newPlayer;
        
        public frm_Login()
        {
            InitializeComponent();
            try
            {
                Program.LoadObject(ref collectPlayer);
            }
            catch
            {
                collectPlayer = new PlayerCollection();
            }

            newPlayer = new PlayerInformation();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlayerInformation exsistingPlayer = collectPlayer.GetPlayer(txt_username.Text);
            lbl_passwordError.Visible = false;
            lbl_usernameError.Visible = false;
            if (string.IsNullOrWhiteSpace(this.txt_username.Text))
            {
                lbl_usernameError.Text = "This field is required";
                lbl_usernameError.Visible = true;
            }
            else if (string.IsNullOrWhiteSpace(this.txt_password.Text))
            {
                lbl_passwordError.Text = "This field is required";
                lbl_passwordError.Visible = true;
            }

            else if (exsistingPlayer == null)
            {
                lbl_usernameError.Text = "This username does not exist";
                lbl_usernameError.Visible = true;
            }
            else if (exsistingPlayer.Password != txt_password.Text)
            {
                lbl_passwordError.Text = ("Incorrect password... Try again");
                lbl_passwordError.Visible = true;
                txt_password.Text = "";
            }
            else
            {
                
                //move to the next form
                Form nextForm = new frm_MainMenu(ref exsistingPlayer);
                this.Hide();
                nextForm.Show();
            }

        }
        private void btn_showPassword_MouseHover(object sender, EventArgs e)
        {
            // Setting the password text so it is visable
            txt_password.PasswordChar = '\0';
        }

        private void btn_showPassword_MouseLeave(object sender, EventArgs e)
        {
            // Setting the password text so it stars out password
            txt_password.PasswordChar = '*';
        }

        private void btn_showPassword_Click(object sender, EventArgs e)
        {
            // Setting the password text so it is visable
            txt_password.PasswordChar = '\0';
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            PlayerInformation exsistingPlayer = collectPlayer.GetPlayer(txt_username.Text);
            lbl_passwordError.Visible = false;
            lbl_usernameError.Visible = false;

            //Validating a new player
            if (string.IsNullOrWhiteSpace(this.txt_username.Text))
            {
                lbl_usernameError.Text = "This field is required";
                lbl_usernameError.Visible = true;
            }

            else if (string.IsNullOrWhiteSpace(this.txt_password.Text))
            {
                lbl_passwordError.Text = "This field is required";
                lbl_passwordError.Visible = true;
            }
            else if (exsistingPlayer != null)
            {
                lbl_usernameError.Text = "Sorry this username has already been taken";
                lbl_usernameError.Visible = true;
            }
            else if (txt_username.TextLength < 4 || txt_username.TextLength > 12)
            {
                lbl_usernameError.Text = "Usernames must be between 4-12 characters";
                lbl_usernameError.Visible = true;
            }
            else if (txt_password.TextLength < 4)
            {
                lbl_passwordError.Text = "Password is too short... Try again";
                lbl_passwordError.Visible = true;
            }
            else
            {
                //Registering the user
                newPlayer.Username = txt_username.Text;
                newPlayer.Password = txt_password.Text;

                collectPlayer.AddPlayer(ref newPlayer);
                Program.SaveObject(collectPlayer);

                //move to the next form
                
                Form nextForm = new frm_MainMenu(ref newPlayer);
                this.Hide();
                nextForm.Show();
               
            }
        }
    }    
}
