using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pacman
{
    public partial class FormGame : Form
    {
        /// <summary>
        /// Czas pomiędzy ruchami postaci
        /// </summary>
        public int Time { get; set; }
        /// <summary>
        /// Liczba zdobytych punktów
        /// </summary>
        public int Points { get; set; }
        /// <summary>
        /// Liczba żyć gracza
        /// </summary>
        public int Lifes { get; set; }
        /// <summary>
        /// Nick gracza
        /// </summary>
        public string Nick { get; set; }
        /// <summary>
        /// Zdeklarowanie tablicy obiektów klasy "PictureBox"
        /// </summary>
        public PictureBox[] tile;

        /// <summary>
        /// Kontruktor z parametrami
        /// </summary>
        public FormGame(string nick, int i)
        {
            InitializeComponent();
            Nick = nick;
            Points = 0;
            Lifes = 0;
            Time = i;
        }
        /// <summary>
        /// Konstruktor
        /// </summary>
        public FormGame()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Funkcja wywoływana przy ładowaniu okna
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormGame_Load(object sender, EventArgs e)
        {
            //Wyświetlenie Nicku, liczby punktów oraz żyć gracza
            textBoxNick.Text = Nick;
            textBoxPoints.Text = Points.ToString();
            textBoxPoints.Refresh();
            textBoxLifes.Text = Lifes.ToString();
            textBoxLifes.Refresh();

            //Nowy obiekt meganegra gry
            ClassGameMenager game = new ClassGameMenager(this);
            //Deklaracja tablicy przechowującej mapę gry
            tile = new PictureBox[784];
           
            //Odczyt przycisków z klawiatury
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(game.ReadKey);

            //Załadowanie mapy
            game.MapLoad();
            MapDisplay(game.Map);
            
            //Deklaracja nowego wątku
            void NewThread()
            {
                game.PacmanSpawn(Nick);
            }
            //Utworzenie nowego wątku
            Thread thread = new Thread(NewThread);

            //Rozpoczęcie wątku
            thread.Start();
        }
        /// <summary>
        /// Zaktualizowanie danych dotyczących ilości punktów i żyć gracza zaczerpniętych z innego wątku
        /// </summary>
        /// <param name="pacman"></param>
        public void UpdateData(ClassPlayer pacman)
        {
            if(this.InvokeRequired)
            {
                this.Invoke(new Action<ClassPlayer>(UpdateData), pacman);
            }
            else
            {
                Points = pacman.Points;
                Lifes = pacman.Lifes;
                textBoxPoints.Text = Points.ToString();
                textBoxPoints.Refresh();
                textBoxLifes.Text = Lifes.ToString();
                textBoxLifes.Refresh();
            }           
        }
        /// <summary>
        /// Odświeżenie mapy na żądanie
        /// </summary>
        public void UpdateMap()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(UpdateMap));
                }
                else
                {
                    this.timer1_Tick(null, null);
                }
            }
            catch { }
        }
        /// <summary>
        /// Nowa gra
        /// </summary>
        public void BeginNewGame()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(BeginNewGame));
                }
                else
                {
                    this.Close();                    
                }
            }
            catch { }
        }

        /// <summary>
        /// Załadowanie mapy
        /// </summary>
        public void MapDisplay(char[,] map)
        {

            for (int i = 0; i < 28; i++)
            {
                for (int j = 0; j < 28; j++)
                {
                    if (map[i, j] == '3')//ściany planszy
                    {
                        tile[i * 28 + j] = new PictureBox();
                        tile[i * 28 + j].BackColor = Color.DarkBlue;
                        tile[i * 28 + j].BorderStyle = BorderStyle.None;
                        tile[i * 28 + j].Size = new System.Drawing.Size(25, 25);
                        tile[i * 28 + j].Margin = new Padding(0);
                        tableLayoutPanelMap.Controls.Add(tile[i * 28 + j], j, i);
                    }
                    if (map[i, j] == 'b')//pola na które można wejść ('b' - brama)
                    {
                        tile[i * 28 + j] = new PictureBox();
                        tile[i * 28 + j].BackColor = Color.Black;
                        tile[i * 28 + j].BorderStyle = BorderStyle.None;
                        tile[i * 28 + j].Size = new System.Drawing.Size(25, 25);
                        tile[i * 28 + j].Margin = new Padding(0);
                        tableLayoutPanelMap.Controls.Add(tile[i * 28 + j], j, i);
                    }
                    if (map[i, j] == 'o')//pola na które można wejść ('o' - wolne pole)
                    {
                        tile[i * 28 + j] = new PictureBox();
                        tile[i * 28 + j].BackColor = Color.Black;
                        tile[i * 28 + j].BackgroundImage = pictureBoxSmallCandy.Image;
                        tile[i * 28 + j].BackgroundImageLayout = ImageLayout.Stretch;
                        tile[i * 28 + j].BorderStyle = BorderStyle.None;
                        tile[i * 28 + j].Size = new System.Drawing.Size(25, 25);
                        tile[i * 28 + j].Margin = new Padding(0);
                        tableLayoutPanelMap.Controls.Add(tile[i * 28 + j], j, i);
                    }
                    if (map[i, j] == 'd')//pola na które można wejść ('d' - pole dużego cukierka)
                    {
                        tile[i * 28 + j] = new PictureBox();
                        tile[i * 28 + j].BackColor = Color.Black;
                        tile[i * 28 + j].BackgroundImage = pictureBoxBigCandy.Image;
                        tile[i * 28 + j].BackgroundImageLayout = ImageLayout.Stretch;
                        tile[i * 28 + j].BorderStyle = BorderStyle.None;
                        tile[i * 28 + j].Size = new System.Drawing.Size(25, 25);
                        tile[i * 28 + j].Margin = new Padding(0);
                        tableLayoutPanelMap.Controls.Add(tile[i * 28 + j], j, i);
                    }
                        if (map[i, j] == '!')//duch
                    {
                        tile[i * 28 + j] = new PictureBox();
                        tile[i * 28 + j].BackColor = Color.Black;
                        tile[i * 28 + j].BorderStyle = BorderStyle.None;
                        tile[i * 28 + j].Size = new System.Drawing.Size(25, 25);
                        tile[i * 28 + j].Margin = new Padding(0);
                        tableLayoutPanelMap.Controls.Add(tile[i * 28 + j], j, i);
                    }
                    if (map[i, j] == '@')//gracz
                    {
                        tile[i * 28 + j] = new PictureBox();
                        tile[i * 28 + j].Tag = i.ToString()+j.ToString();
                        tile[i * 28 + j].BackColor = Color.Black;
                        tile[i * 28 + j].BorderStyle = BorderStyle.None;
                        tile[i * 28 + j].Size = new System.Drawing.Size(25, 25);
                        tile[i * 28 + j].Margin = new Padding(0);
                        tableLayoutPanelMap.Controls.Add(tile[i * 28 + j], j, i);                    
                    }
                }
            }
        }
        /// <summary>
        /// Timer odpowiedzialny za odświeżanie wyświetlanych informacji
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void timer1_Tick(object sender, EventArgs e)
        {
            textBoxPoints.Text = Points.ToString();
            textBoxLifes.Text = Lifes.ToString();
            textBoxPoints.Refresh();
            textBoxLifes.Refresh();
            tableLayoutPanelMap.Refresh();
        }
        /// <summary>
        /// Zamknięcie okna gry czyli zamknięcie całego programu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
