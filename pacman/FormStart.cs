using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pacman
{
    public partial class FormStart : Form
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        public FormStart()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Rozpoczącie gry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            //Nowa gra w trybie "easy"
            if (buttonEasy.BackColor == Color.Green && textBoxNick.Text != string.Empty)
            {
                int i = 200;
                FormGame formGame = new FormGame(textBoxNick.Text,i);
                this.Enabled = false;
                formGame.ShowDialog();
            }
            //Nowa gra w trybie "medium"
            if(buttonMedium.BackColor == Color.Green && textBoxNick.Text != string.Empty)
            {
                int i = 100;
                FormGame formGame = new FormGame(textBoxNick.Text,i);
                this.Enabled = false;
                formGame.ShowDialog();
            }
            //Nowa gra w trybie "hard"
            if(buttonHard.BackColor == Color.Green && textBoxNick.Text != string.Empty)
            {
                int i = 75;
                FormGame formGame = new FormGame(textBoxNick.Text,i);
                this.Enabled = false;
                formGame.ShowDialog();
            }
            //Okno mówiące o wystąpionym błędzie
            else
            {
                MessageBox.Show("Należy wybrać poziom trudności oraz podać nick gracza!");
            }
        }
        /// <summary>
        /// Wybranie poziomu trudności "easy"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEasy_Click(object sender, EventArgs e)
        {
            buttonHard.BackColor = Color.Red;
            buttonMedium.BackColor = Color.Red;
            buttonEasy.BackColor = Color.Green;
        }
        /// <summary>
        /// Wybranie poziomu trudności "medium"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMedium_Click(object sender, EventArgs e)
        {
            buttonHard.BackColor = Color.Red;
            buttonMedium.BackColor = Color.Green;
            buttonEasy.BackColor = Color.Red;
        }
        /// <summary>
        /// Wybranie poziomu trudności "hard"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonHard_Click(object sender, EventArgs e)
        {
            buttonHard.BackColor = Color.Green;
            buttonMedium.BackColor = Color.Red;
            buttonEasy.BackColor = Color.Red;
        }
        /// <summary>
        /// Funkcja wywyływana podczas ładowania okna
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormStart_Load(object sender, EventArgs e)
        {

        }
    }
}
