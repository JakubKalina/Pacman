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
    public partial class FormNewGame : Form
    {
        /// <summary>
        /// Wyświetlana wiadomość
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Konstruktor
        /// </summary>
        public FormNewGame(string t)
        {
            InitializeComponent();
            Message = t;
        }
        /// <summary>
        /// Funkcja wywoływana przy ładowaniu okna
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormNewGame_Load(object sender, EventArgs e)
        {
            //Jeżeli gracz przegrał
            if (Message == "Przegrana")
            {
                labelNewGameMessage.Text = Message;
                labelNewGameMessage.ForeColor = Color.Red;
            }
            //Jeżeli gracz wygrał
            if (Message == "Wygrana")
            {
                labelNewGameMessage.Text = Message;
                labelNewGameMessage.ForeColor = Color.Green;
            }
        }

        /// <summary>
        /// Wybranie przycisku nie (zakończenie działania programu)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNewGameNo_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Wybranie przycisku tak (rozpoczęcie nowej gry)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNewGameYes_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
