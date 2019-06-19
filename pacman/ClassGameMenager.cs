using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace pacman
{
    /// <summary>
    /// Klasa zarządzająca grą
    /// </summary>
    class ClassGameMenager : FormGame
    {
        ///// <summary>
        ///// Kierunek ruchu w górę
        ///// </summary>
        const int moveUp = 1;
        ///// <summary>
        ///// Kierunek ruchu w dół
        ///// </summary>
        const int moveDown = 3;
        ///// <summary>
        ///// Kierunek ruchu w lewo
        ///// </summary>
        const int moveLeft = 4;
        ///// <summary>
        ///// Kierunek ruchi w prawo
        ///// </summary>
        const int moveRight = 2;

        /// <summary>
        /// Licznik czasu możliwości zjadania duchów
        /// </summary>
        public int EatMonsterTimer { get; set; }
        /// <summary>
        /// Wysokośc mapy
        /// </summary>
        public new int Height { get; set; }
        /// <summary>
        /// Szerokość mapy
        /// </summary>
        public new int Width { get; set; }
        /// <summary>
        /// Klawisz
        /// </summary>
        public Keys Key { get; set; }
        /// <summary>
        /// Wczytana mapa gry
        /// </summary>
        public char[,] Map { get; set; }
        /// <summary>
        /// Obiekt formy gry
        /// </summary>
        public FormGame formGame;
        /// <summary>
        /// Lista małych cukierków
        /// </summary>
        List<ClassSmallCandy> ListSmallCandy = new List<ClassSmallCandy>();
        /// <summary>
        /// Lista dużych cukierków
        /// </summary>
        List<ClassBigCandy> ListBigCandy = new List<ClassBigCandy>();

        /// <summary>
        /// Konstruktor
        /// </summary>
        public ClassGameMenager(FormGame form)
        {
            Time = 100;
            Height = 28;
            Width = 28;
            formGame = form;
            Map = new char[28, 28];
        }

        /// <summary>
        /// Funkcja przeszukująca listę małych cukierków
        /// </summary>
        /// <returns></returns>
        public bool SearchOfListSmallCandy(int x, int y)
            {
                bool exists = ListSmallCandy.Any(a => a.CoordinateX == x && a.CoordinateY == y);
                if (exists == true) return true;
                else return false;
            }
        /// <summary>
        /// Funkcja przeszukująca listę dużych cukierków
        /// </summary>
        /// <returns></returns>
        public bool SearchOfListBigCandy(int x, int y)
            {
                bool exists = ListBigCandy.Any(a => a.CoordinateX == x && a.CoordinateY == y);
                if (exists == true) return true;
                else return false;
            }
        /// <summary>
        /// Funkcja usuwająca obiekt małego cukierka z listy
        /// </summary>
        public void EraseListSmallCandy(int x, int y)
            {
            try
            {
                var smallCandy = ListSmallCandy.Single(a => a.CoordinateX == x && a.CoordinateY == y);
                ListSmallCandy.Remove(smallCandy);
            }
            catch
            { }
            }
        /// <summary>
        /// Funkcja usuwająca obiekt dużego cukierka z listy
        /// </summary>
        public void EraseListBigCandy(int x, int y)
            {
            try
            {
                var bigcandy = ListBigCandy.Single(a => a.CoordinateX == x && a.CoordinateY == y);
                ListBigCandy.Remove(bigcandy);
            }
            catch
            { }
            }
        /// <summary>
        /// Funkcja sprawdzająca możliwość ruchu na dane pole o przekazanych współrzędnych
        /// </summary>
        /// <param name="map"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool CheckMap(int x, int y)
            {
                try
                {
                    if (Map[y, x] == 'o' || Map[y, x] == 'b' || Map[y, x] == 'd' || Map[y, x] == '@' || Map[y,x] == '!') return true;
                    else return false;
                }
                catch
                {
                    return false;
                }
            }
        /// <summary>
        /// Funkcja sprawdzająca spotkanie potwora z pacmanem
        /// </summary>
        /// <param name="Monster"></param>
        /// <param name="Player"></param>
        /// <returns></returns>
        public bool PacmanMonsterMeet (ClassMonster Monster, ClassPlayer Player)
            {
                if ((Player.CoordinateX == Monster.CoordinateX) && (Player.CoordinateY == Monster.CoordinateY)) return true;
                else return false;
            }
        /// <summary>
        /// Funkcja zwracająca liczbę pseudolosową z zadanego przedziału
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public int Draw(int min,int max)
            {
            Random random = new Random();
            return random.Next(min, max);
            }
        /// <summary>
        /// Funkcja zarządzająca ruchami potworów
        /// </summary>
        /// <param name="monster"></param>
        /// <param name="map"></param>
        public void MonsterMove(ClassMonster monster)
        {
            //Zmienna przechowująca przemieszczenie potwora
            int movement = 1;
            //Ruch w górę
            if(monster.MotionDirection == moveUp)
            {
                //Jeśli istnieje możliwość przesunięcia w górę
                if(CheckMap(monster.CoordinateX,monster.CoordinateY - movement))
                {
                    if(SearchOfListSmallCandy(monster.CoordinateX,monster.CoordinateY) == true)
                    {
                        Map[monster.CoordinateY, monster.CoordinateX] = 'o';
                    }
                    if(SearchOfListBigCandy(monster.CoordinateX,monster.CoordinateY) == true)
                    {
                        Map[monster.CoordinateY, monster.CoordinateX] = 'd';
                    }
                    else
                    {
                        Map[monster.CoordinateY, monster.CoordinateX] = 'o';
                    }

                    if((monster.CoordinateX == 12 || monster.CoordinateX == 13 || monster.CoordinateX == 14 || monster.CoordinateX == 15 ) && monster.CoordinateY == 13)
                    {
                        Map[monster.CoordinateY, monster.CoordinateX] = 'b';
                    }
                    else
                    {
                        Map[monster.CoordinateY, monster.CoordinateX] = 'o';
                    }
                        monster.OldCoordinateX = monster.CoordinateX;
                    monster.OldCoordinateY = monster.CoordinateY;
                    //Zmiana współrzędnych potwora
                    monster.CoordinateY = monster.CoordinateY - movement;
                    //Zaznaczenie potwora na mapie
                    Map[monster.CoordinateY, monster.CoordinateX] = monster.Character;
                }
                else//W przeciwnym razie zmiana kierunku ruchu
                {
                    monster.MotionDirection += Draw(1, 3);
                    if (monster.MotionDirection > 4) monster.MotionDirection -= 4;
                    System.Threading.Thread.Sleep(10);
                }
                return;
            }
            //Ruch w dół
            if(monster.MotionDirection == moveDown)
            {
                //Jeśli istnieje możliwość przesunięcia w dół
                if (CheckMap(monster.CoordinateX, monster.CoordinateY + movement)  && Map[monster.CoordinateY + movement,monster.CoordinateX] != 'b')
                {
                    if (SearchOfListSmallCandy(monster.CoordinateX, monster.CoordinateY) == true)
                    {
                        Map[monster.CoordinateY, monster.CoordinateX] = 'o';
                    }
                    if (SearchOfListBigCandy(monster.CoordinateX, monster.CoordinateY) == true)
                    {
                        Map[monster.CoordinateY, monster.CoordinateX] = 'd';
                    }
                    else
                    {
                        Map[monster.CoordinateY, monster.CoordinateX] = 'o';
                    }
                    monster.OldCoordinateX = monster.CoordinateX;
                    monster.OldCoordinateY = monster.CoordinateY;
                    //Zmiana współrzędnych potwora
                    monster.CoordinateY = monster.CoordinateY + movement;
                    //Zaznaczenie potwora na mapie
                    Map[monster.CoordinateY, monster.CoordinateX] = monster.Character;
                }
                else//W przeciwnym razie zmiana kierunku ruchu
                {
                    monster.MotionDirection += Draw(1, 3);
                    if (monster.MotionDirection > 4) monster.MotionDirection -= 4;
                    System.Threading.Thread.Sleep(10);
                }
                return;
            }
            //Ruch w lewo
            if(monster.MotionDirection == moveLeft)
            {
                //Jeśli istnieje możliwość przesunięcia w lewo
                if (CheckMap(monster.CoordinateX - movement, monster.CoordinateY))
                {
                    if (SearchOfListSmallCandy(monster.CoordinateX, monster.CoordinateY) == true)
                    {
                        Map[monster.CoordinateY, monster.CoordinateX] = 'o';
                    }
                    if (SearchOfListBigCandy(monster.CoordinateX, monster.CoordinateY) == true)
                    {
                        Map[monster.CoordinateY, monster.CoordinateX] = 'd';
                    }
                    else
                    {
                        Map[monster.CoordinateY, monster.CoordinateX] = 'o';
                    }
                    monster.OldCoordinateX = monster.CoordinateX;
                    monster.OldCoordinateY = monster.CoordinateY;
                    //Zmiana współrzędnych potwora
                    monster.CoordinateX = monster.CoordinateX - movement;
                    //Zaznaczenie potwora na mapie
                    Map[monster.CoordinateY, monster.CoordinateX] = monster.Character;
                }
                else//W przeciwnym razie zmiana kierunku ruchu
                {
                    monster.MotionDirection += Draw(1, 3);
                    if (monster.MotionDirection > 4) monster.MotionDirection -= 4;
                    System.Threading.Thread.Sleep(10);
                }
                return;
            }
            //Ruch w prawo
            if (monster.MotionDirection == moveRight)
            {
                //Jeśli istnieje możliwość przesunięcia w prawo
                if (CheckMap(monster.CoordinateX + movement, monster.CoordinateY))
                {
                    if (SearchOfListSmallCandy(monster.CoordinateX, monster.CoordinateY) == true)
                    {
                        Map[monster.CoordinateY, monster.CoordinateX] = 'o';
                    }
                    if (SearchOfListBigCandy(monster.CoordinateX, monster.CoordinateY) == true)
                    {
                        Map[monster.CoordinateY, monster.CoordinateX] = 'd';
                    }
                    else
                    {
                        Map[monster.CoordinateY, monster.CoordinateX] = 'o';
                    }
                    monster.OldCoordinateX = monster.CoordinateX;
                    monster.OldCoordinateY = monster.CoordinateY;
                    //Zmiana współrzędnych potwora
                    monster.CoordinateX = monster.CoordinateX + movement;
                    //Zaznaczenie potwora na mapie
                    Map[monster.CoordinateY, monster.CoordinateX] = monster.Character;
                }
                else//W przeciwnym razie zmiana kierunku ruchu
                {
                     monster.MotionDirection += Draw(1, 3);
                    if (monster.MotionDirection > 4) monster.MotionDirection -= 4;
                    System.Threading.Thread.Sleep(10);
                }
                return;
            }
            return;
        }
        /// <summary>
        /// Czytanie klawisza wciśniętego przez gracza
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ReadKey(object sender, KeyEventArgs e)
        {
            Keys input = e.KeyCode;
            Key = input;
        }
        /// <summary>
        /// Ustawienie odpowiedniego kierunku ruchu pacmana w zależności od wciśniętego klawisza
        /// </summary>
        /// <param name="pacman"></param>
        public void PlayerAction(ref ClassPlayer pacman)
        {
            switch (Key)
            {
                case Keys.Up:
                    pacman.MotionDirection = moveUp;
                    break;
                case Keys.Down:
                    pacman.MotionDirection = moveDown;
                    break;
                case Keys.Left:
                    pacman.MotionDirection = moveLeft;
                    break;
                case Keys.Right:
                    pacman.MotionDirection = moveRight;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Funkcja zarządzająca ruchami pacmana
        /// </summary>
        public void PacmanMove(ClassPlayer pacman)
        {
            //Zmienna przechowująca przemieszczenie pacmana
            int movement = 1;
            //Zapamiętanie starego kierunku ruchu
            pacman.OldMotionDirection = pacman.MotionDirection;
            //Wczytanie zadanego kierunku ruchu pacmana z klawiatury
            PlayerAction(ref pacman);


            //Specjalny przypadek ruch / krańce mapy / przejście pomiędzy stronami mapy
            if ((pacman.CoordinateX == 0) && (pacman.CoordinateY == 14) && (pacman.MotionDirection == moveLeft))
            {
                EraseListSmallCandy(pacman.CoordinateX, pacman.CoordinateY);
                EraseListBigCandy(pacman.CoordinateX, pacman.CoordinateY);
                Map[pacman.CoordinateY, pacman.CoordinateX] = 'o';
                pacman.OldCoordinateX = pacman.CoordinateX;
                pacman.OldCoordinateY = pacman.CoordinateY;
                pacman.CoordinateX = 27;
                pacman.VisitedCoordinateX.Add(pacman.CoordinateX);
                pacman.VisitedCoordinateY.Add(pacman.CoordinateY);
                return;
            }
            if ((pacman.CoordinateX == 27) && (pacman.CoordinateY == 14) && (pacman.MotionDirection == moveRight))
            {
                EraseListSmallCandy(pacman.CoordinateX, pacman.CoordinateY);
                EraseListBigCandy(pacman.CoordinateX, pacman.CoordinateY);
                Map[pacman.CoordinateY, pacman.CoordinateX] = 'o';
                pacman.OldCoordinateX = pacman.CoordinateX;
                pacman.OldCoordinateY = pacman.CoordinateY;
                pacman.CoordinateX = 0;
                pacman.VisitedCoordinateX.Add(pacman.CoordinateX);
                pacman.VisitedCoordinateY.Add(pacman.CoordinateY);
                return;
            }

            //Jeśli wybrano kierunek w góre ale ruch ten jest niemożliwy
            if (pacman.MotionDirection == moveUp)
            {
                if(CheckMap(pacman.CoordinateX,pacman.CoordinateY - movement) == false)
                {
                    pacman.MotionDirection = pacman.OldMotionDirection;
                }
            }
            //Jeśli wybrano kierunek w dół ale ruch ten jest niemożliwy
            if (pacman.MotionDirection == moveDown)
            {
                if (CheckMap(pacman.CoordinateX, pacman.CoordinateY + movement) == false || Map[pacman.CoordinateY + movement , pacman.CoordinateX] == 'b')
                {
                    pacman.MotionDirection = pacman.OldMotionDirection;
                }
            }
            //Jeśli wybrano kierunek w lewo ale ruch ten jest niemożliwy
            if (pacman.MotionDirection == moveLeft)
            {
                if (CheckMap(pacman.CoordinateX - movement, pacman.CoordinateY) == false)
                {
                    pacman.MotionDirection = pacman.OldMotionDirection;
                }
            }
            //Jeśli wybrano kierunek w prawo ale ruch ten jest niemożliwy
            if (pacman.MotionDirection == moveRight)
            {
                if (CheckMap(pacman.CoordinateX + movement, pacman.CoordinateY) == false)
                {
                    pacman.MotionDirection = pacman.OldMotionDirection;
                }
            }

            //Ruch w górę
            if (pacman.MotionDirection == moveUp)
            {
                if(CheckMap(pacman.CoordinateX,pacman.CoordinateY - movement) == true)
                {
                    Map[pacman.CoordinateY, pacman.CoordinateX] = 'o';
                    Map[pacman.CoordinateY - movement, pacman.CoordinateX] = '@';
                    pacman.OldCoordinateX = pacman.CoordinateX;
                    pacman.OldCoordinateY = pacman.CoordinateY;
                    pacman.CoordinateY -= movement;
                    pacman.VisitedCoordinateY.Add(pacman.CoordinateY);
                    pacman.VisitedCoordinateX.Add(pacman.CoordinateX);
                }
                return;
            }
            //Ruch w dół
            if(pacman.MotionDirection == moveDown)
            {
                if (CheckMap(pacman.CoordinateX, pacman.CoordinateY + movement) == true && Map[pacman.CoordinateY + movement,pacman.CoordinateX] != 'b')
                {
                    Map[pacman.CoordinateY, pacman.CoordinateX] = 'o';
                    Map[pacman.CoordinateY + movement, pacman.CoordinateX] = '@';
                    pacman.OldCoordinateX = pacman.CoordinateX;
                    pacman.OldCoordinateY = pacman.CoordinateY;
                    pacman.CoordinateY += movement;
                    pacman.VisitedCoordinateY.Add(pacman.CoordinateY);
                    pacman.VisitedCoordinateX.Add(pacman.CoordinateX);
                }
                return;
            }
            //Ruch w lewo
            if(pacman.MotionDirection == moveLeft)
            {
                if (CheckMap(pacman.CoordinateX - movement, pacman.CoordinateY) == true)
                {
                    Map[pacman.CoordinateY, pacman.CoordinateX] = 'o';
                    Map[pacman.CoordinateY, pacman.CoordinateX - movement] = '@';
                    pacman.OldCoordinateX = pacman.CoordinateX;
                    pacman.OldCoordinateY = pacman.CoordinateY;
                    pacman.CoordinateX -= movement;
                    pacman.VisitedCoordinateY.Add(pacman.CoordinateY);
                    pacman.VisitedCoordinateX.Add(pacman.CoordinateX);
                }
                return;
            }
            //Ruch w prawo
            if(pacman.MotionDirection == moveRight)
            {
                if (CheckMap(pacman.CoordinateX + movement, pacman.CoordinateY) == true)
                {
                    Map[pacman.CoordinateY, pacman.CoordinateX] = 'o';
                    Map[pacman.CoordinateY, pacman.CoordinateX + movement] = '@';
                    pacman.OldCoordinateX = pacman.CoordinateX;
                    pacman.OldCoordinateY = pacman.CoordinateY;
                    pacman.CoordinateX += movement;
                    pacman.VisitedCoordinateY.Add(pacman.CoordinateY);
                    pacman.VisitedCoordinateX.Add(pacman.CoordinateX);
                }
                return;
            }
        }
        /// <summary>
        /// Funkcja sprawdzająca czy pacman spotkał się z potworem
        /// </summary>
        /// <param name="pacman"></param>
        /// <param name="monster"></param>
        /// <returns></returns>
        public bool PacmanMonsterMeeting(ClassPlayer pacman, ClassMonster monster)
        {
            if ((pacman.CoordinateX == monster.CoordinateX) && (pacman.CoordinateY == monster.CoordinateY))
            {
                pacman.Points += 100;

                monster.CoordinateX = 12;
                monster.CoordinateY = 14;
                monster.MotionDirection = 1;

                return true;
            }
            else return false;
        }
        /// <summary>
        /// Czyszczenie odpowiednich pól oraz ustawianie potworków oraz pacmana w ich miejsca startowe (spawnu)
        /// </summary>
        /// <param name="pacman"></param>
        /// <param name="monster1"></param>
        /// <param name="monster2"></param>
        /// <param name="monster3"></param>
        /// <param name="monster4"></param>
        /// <returns></returns>
        public bool PacmanDeath(ClassPlayer pacman, ClassMonster monster1, ClassMonster monster2, ClassMonster monster3, ClassMonster monster4)
        {
            if ((PacmanMonsterMeet(monster1, pacman) == true && EatMonsterTimer == 0) || (PacmanMonsterMeet(monster2, pacman) == true && EatMonsterTimer == 0) || (PacmanMonsterMeet(monster3, pacman) == true && EatMonsterTimer == 0) || (PacmanMonsterMeet(monster4, pacman) == true && EatMonsterTimer == 0))
            {
                //Obecne współrzędne
                ////Dla pacmana
                formGame.tile[pacman.CoordinateY * 28 + pacman.CoordinateX].BackgroundImage = null;
                //Dla monster1
                if (SearchOfListSmallCandy(monster1.CoordinateX, monster1.CoordinateY) == true) formGame.tile[monster1.CoordinateY * 28 + monster1.CoordinateX].BackgroundImage = formGame.pictureBoxSmallCandy.Image;
                else if (SearchOfListBigCandy(monster1.CoordinateX, monster1.CoordinateY) == true) formGame.tile[monster1.CoordinateY * 28 + monster1.CoordinateX].BackgroundImage = formGame.pictureBoxBigCandy.Image;
                else formGame.tile[monster1.CoordinateY * 28 + monster1.CoordinateX].BackgroundImage = null;
                //Dla monster2
                if (SearchOfListSmallCandy(monster2.CoordinateX, monster2.CoordinateY) == true) formGame.tile[monster2.CoordinateY * 28 + monster2.CoordinateX].BackgroundImage = formGame.pictureBoxSmallCandy.Image;
                else if (SearchOfListBigCandy(monster2.CoordinateX, monster2.CoordinateY) == true) formGame.tile[monster2.CoordinateY * 28 + monster2.CoordinateX].BackgroundImage = formGame.pictureBoxBigCandy.Image;
                else formGame.tile[monster2.CoordinateY * 28 + monster2.CoordinateX].BackgroundImage = null;
                //Dla monster3
                if (SearchOfListSmallCandy(monster3.CoordinateX, monster3.CoordinateY) == true) formGame.tile[monster3.CoordinateY * 28 + monster3.CoordinateX].BackgroundImage = formGame.pictureBoxSmallCandy.Image;
                else if (SearchOfListBigCandy(monster3.CoordinateX, monster3.CoordinateY) == true) formGame.tile[monster3.CoordinateY * 28 + monster3.CoordinateX].BackgroundImage = formGame.pictureBoxBigCandy.Image;
                else formGame.tile[monster3.CoordinateY * 28 + monster3.CoordinateX].BackgroundImage = null;
                //Dla monster4
                if (SearchOfListSmallCandy(monster4.CoordinateX, monster4.CoordinateY) == true) formGame.tile[monster4.CoordinateY * 28 + monster4.CoordinateX].BackgroundImage = formGame.pictureBoxSmallCandy.Image;
                else if (SearchOfListBigCandy(monster4.CoordinateX, monster4.CoordinateY) == true) formGame.tile[monster4.CoordinateY * 28 + monster4.CoordinateX].BackgroundImage = formGame.pictureBoxBigCandy.Image;
                else formGame.tile[monster4.CoordinateY * 28 + monster4.CoordinateX].BackgroundImage = null;

                //Stare współrzędne
                ////Dla pacmana
                formGame.tile[pacman.OldCoordinateY * 28 + pacman.OldCoordinateX].BackgroundImage = null;
                //Dla monster1
                if (SearchOfListSmallCandy(monster1.OldCoordinateX, monster1.OldCoordinateY) == true) formGame.tile[monster1.OldCoordinateY * 28 + monster1.OldCoordinateX].BackgroundImage = formGame.pictureBoxSmallCandy.Image;
                else if (SearchOfListBigCandy(monster1.OldCoordinateX, monster1.OldCoordinateY) == true) formGame.tile[monster1.OldCoordinateY * 28 + monster1.OldCoordinateX].BackgroundImage = formGame.pictureBoxBigCandy.Image;
                else formGame.tile[monster1.OldCoordinateY * 28 + monster1.OldCoordinateX].BackgroundImage = null;
                //Dla monster2
                if (SearchOfListSmallCandy(monster2.OldCoordinateX, monster2.OldCoordinateY) == true) formGame.tile[monster2.OldCoordinateY * 28 + monster2.OldCoordinateX].BackgroundImage = formGame.pictureBoxSmallCandy.Image;
                else if (SearchOfListBigCandy(monster2.OldCoordinateX, monster2.OldCoordinateY) == true) formGame.tile[monster2.OldCoordinateY * 28 + monster2.OldCoordinateX].BackgroundImage = formGame.pictureBoxBigCandy.Image;
                else formGame.tile[monster2.OldCoordinateY * 28 + monster2.OldCoordinateX].BackgroundImage = null;
                //Dla monster3
                if (SearchOfListSmallCandy(monster3.OldCoordinateX, monster3.OldCoordinateY) == true) formGame.tile[monster3.OldCoordinateY * 28 + monster3.OldCoordinateX].BackgroundImage = formGame.pictureBoxSmallCandy.Image;
                else if (SearchOfListBigCandy(monster3.OldCoordinateX, monster3.OldCoordinateY) == true) formGame.tile[monster3.OldCoordinateY * 28 + monster3.OldCoordinateX].BackgroundImage = formGame.pictureBoxBigCandy.Image;
                else formGame.tile[monster3.OldCoordinateY * 28 + monster3.OldCoordinateX].BackgroundImage = null;
                //Dla monster4
                if (SearchOfListSmallCandy(monster4.OldCoordinateX, monster4.OldCoordinateY) == true) formGame.tile[monster4.OldCoordinateY * 28 + monster4.OldCoordinateX].BackgroundImage = formGame.pictureBoxSmallCandy.Image;
                else if (SearchOfListBigCandy(monster4.OldCoordinateX, monster4.OldCoordinateY) == true) formGame.tile[monster4.OldCoordinateY * 28 + monster4.OldCoordinateX].BackgroundImage = formGame.pictureBoxBigCandy.Image;
                else formGame.tile[monster4.OldCoordinateY * 28 + monster4.OldCoordinateX].BackgroundImage = null;

                if (pacman.MotionDirection == 1)
                {
                    formGame.tile[pacman.CoordinateY * 28 + pacman.CoordinateX - 28].BackgroundImage = null;
                }
                if (pacman.MotionDirection == 2)
                {
                    formGame.tile[pacman.CoordinateY * 28 + pacman.CoordinateX + 28].BackgroundImage = null;
                }
                if (pacman.MotionDirection == 3)
                {
                    formGame.tile[pacman.CoordinateY * 28 + pacman.CoordinateX - 1].BackgroundImage = null;
                    formGame.tile[pacman.CoordinateY * 28 + pacman.CoordinateX + 1].BackgroundImage = null;
                }
                if (pacman.MotionDirection == 4)
                {
                    formGame.tile[pacman.CoordinateY * 28 + pacman.CoordinateX - 1].BackgroundImage = null;
                    formGame.tile[pacman.CoordinateY * 28 + pacman.CoordinateX + 1].BackgroundImage = null;
                }

                //Ustawienie wartości początkowych współrzędnych 
                pacman.Lifes -= 1;
                Map[pacman.CoordinateY, pacman.CoordinateX] = 'o';
                Map[monster1.CoordinateY, monster1.CoordinateX] = 'o';
                Map[monster2.CoordinateY, monster2.CoordinateX] = 'o';
                Map[monster3.CoordinateY, monster3.CoordinateX] = 'o';
                Map[monster4.CoordinateY, monster4.CoordinateX] = 'o';

                pacman.CoordinateX = 13;
                pacman.CoordinateY = 22;
                pacman.MotionDirection = 0;

                monster1.CoordinateX = 12;
                monster1.CoordinateY = 14;
                monster1.MotionDirection = 1;

                monster2.CoordinateX = 13;
                monster2.CoordinateY = 14;
                monster2.MotionDirection = 1;

                monster3.CoordinateX = 14;
                monster3.CoordinateY = 14;
                monster3.MotionDirection = 1;

                monster4.CoordinateX = 15;
                monster4.CoordinateY = 14;
                monster4.MotionDirection = 1;

                Map[pacman.CoordinateY, pacman.CoordinateX] = '@';
                Map[monster1.CoordinateY, monster1.CoordinateX] = '!';
                Map[monster2.CoordinateY, monster2.CoordinateX] = '!';
                Map[monster3.CoordinateY, monster3.CoordinateX] = '!';
                Map[monster4.CoordinateY, monster4.CoordinateX] = '!';

                //Wyświetlenie potworów i pacmana w ich miejscach startowych (spawnu)
                formGame.tile[monster1.CoordinateY * 28 + monster1.CoordinateX].BackgroundImage = formGame.pictureBoxBlinky.Image;
                formGame.tile[monster1.CoordinateY * 28 + monster1.CoordinateX].BackgroundImageLayout = ImageLayout.Stretch;
                formGame.tile[monster2.CoordinateY * 28 + monster2.CoordinateX].BackgroundImage = formGame.pictureBoxClyde.Image;
                formGame.tile[monster2.CoordinateY * 28 + monster2.CoordinateX].BackgroundImageLayout = ImageLayout.Stretch;
                formGame.tile[monster3.CoordinateY * 28 + monster3.CoordinateX].BackgroundImage = formGame.pictureBoxInky.Image;
                formGame.tile[monster3.CoordinateY * 28 + monster3.CoordinateX].BackgroundImageLayout = ImageLayout.Stretch;
                formGame.tile[monster4.CoordinateY * 28 + monster4.CoordinateX].BackgroundImage = formGame.pictureBoxPinky.Image;
                formGame.tile[monster4.CoordinateY * 28 + monster4.CoordinateX].BackgroundImageLayout = ImageLayout.Stretch;
                formGame.tile[pacman.CoordinateY * 28 + pacman.CoordinateX].BackgroundImage = formGame.pictureBoxPacmanUp.Image;
                formGame.tile[pacman.CoordinateY * 28 + pacman.CoordinateX].BackgroundImageLayout = ImageLayout.Stretch;
                formGame.tile[pacman.OldCoordinateY * 28 + pacman.OldCoordinateX].BackgroundImage = formGame.pictureBoxPacmanUp.Image;
                formGame.tile[pacman.OldCoordinateY * 28 + pacman.OldCoordinateX].BackgroundImageLayout = ImageLayout.Stretch;
                //Uaktualnienie mapy gry na żądanie
                formGame.UpdateMap();

                return true;
            }
            else return false;
        }
        /// <summary>
        /// Możliwość zjadania potworków
        /// </summary>
        /// <param name="pacman"></param>
        /// <param name="monster1"></param>
        /// <param name="monster2"></param>
        /// <param name="monster3"></param>
        /// <param name="monster4"></param>
        public void EatMonsterOpportunity(ClassPlayer pacman, ClassMonster monster1, ClassMonster monster2, ClassMonster monster3, ClassMonster monster4)
        {
            if (EatMonsterTimer != 0)
            {
                EatMonsterTimer -= Time;
                PacmanMonsterMeeting(pacman, monster1);
                PacmanMonsterMeeting(pacman, monster2);
                PacmanMonsterMeeting(pacman, monster3);
                PacmanMonsterMeeting(pacman, monster4);
            }
        }
        /// <summary>
        /// Uruchomienie nowej gry
        /// </summary>
        /// <param name="pacman"></param>
        /// <param name="monster1"></param>
        /// <param name="monster2"></param>
        /// <param name="monster3"></param>
        /// <param name="monster4"></param>
        public void NewGame(ClassPlayer pacman, ClassMonster monster1, ClassMonster monster2, ClassMonster monster3, ClassMonster monster4)
        {
            //Wyczyszczenie list
            pacman.VisitedCoordinateX.Clear();
            pacman.VisitedCoordinateY.Clear();
            ListSmallCandy.Clear();
            ListBigCandy.Clear();
        }
        /// <summary>
        /// Zarządzanie ruchami pacmana oraz potworów
        /// </summary>
        /// <param name="monster1"></param>
        /// <param name="monster2"></param>
        /// <param name="monster3"></param>
        /// <param name="monster4"></param>
        /// <param name="pacman"></param>
        public void MoveManagement(ClassMonster monster1, ClassMonster monster2, ClassMonster monster3, ClassMonster monster4, ClassPlayer pacman)
        {
           while(true)
            {
                //Sprawdzenie zderzeń
                if (PacmanDeath(pacman, monster1, monster2, monster3, monster4)) continue;
                EatMonsterOpportunity(pacman, monster1, monster2, monster3, monster4);
                //Ruch potworów
                MonsterMove(monster1);
                MonsterMove(monster2);
                MonsterMove(monster3);
                MonsterMove(monster4);
                //Sprawdzenie zderzeń
                if (PacmanDeath(pacman, monster1, monster2, monster3, monster4)) continue;
                EatMonsterOpportunity(pacman, monster1, monster2, monster3, monster4);
                //Ruch pacmana
                PacmanMove(pacman);

                //Przeszukanie listy małych cukierków
                if(SearchOfListSmallCandy(pacman.CoordinateX,pacman.CoordinateY))
                {
                    EraseListSmallCandy(pacman.CoordinateX, pacman.CoordinateY);
                    pacman.Points += 1;
                }
                //Przeszukanie listy dużych cukierków
                if(SearchOfListBigCandy(pacman.CoordinateX,pacman.CoordinateY))
                {
                    EatMonsterTimer = 0;
                    EraseListBigCandy(pacman.CoordinateX, pacman.CoordinateY);
                    EatMonsterTimer = Time * 140;
                }
                //Sprawdzenie zderzeń
                if (PacmanDeath(pacman, monster1, monster2, monster3, monster4)) continue;
                EatMonsterOpportunity(pacman, monster1, monster2, monster3, monster4);

                //Przypadek gdy wszystkie cukierki zostały zebrane
                if(ListSmallCandy.Count() == 0)
                {
                    FormNewGame formNewGame = new FormNewGame("Wygrana");
                    formNewGame.ShowDialog();
                    formGame.BeginNewGame();
                    NewGame(pacman, monster1, monster2, monster3, monster4);
                    break;
                }
                //Przypadek gdzy wszystkie życia zostały wykożystane
                if(pacman.Lifes == 0)
                {
                    FormNewGame formNewGame = new FormNewGame("Przegrana");
                    formNewGame.ShowDialog();
                    formGame.BeginNewGame();
                    NewGame(pacman, monster1, monster2, monster3, monster4);
                    break;
                }
                
              //Wyświetlenie potwora na nowym polu oraz wyczyszczenie starego pola

                //Dla monster1
                if (EatMonsterTimer != 0)
                    {
                        formGame.tile[monster1.CoordinateY * 28 + monster1.CoordinateX].BackgroundImage = formGame.pictureBoxMonster.Image;
                        formGame.tile[monster1.CoordinateY * 28 + monster1.CoordinateX].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else
                    {
                        formGame.tile[monster1.CoordinateY * 28 + monster1.CoordinateX].BackgroundImage = formGame.pictureBoxBlinky.Image;
                        formGame.tile[monster1.CoordinateY * 28 + monster1.CoordinateX].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    if (SearchOfListSmallCandy(monster1.OldCoordinateX, monster1.OldCoordinateY) == true)
                    {
                        formGame.tile[monster1.OldCoordinateY * 28 + monster1.OldCoordinateX].BackgroundImage = formGame.pictureBoxSmallCandy.Image;
                        formGame.tile[monster1.OldCoordinateY * 28 + monster1.OldCoordinateX].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (SearchOfListBigCandy(monster1.OldCoordinateX, monster1.OldCoordinateY) == true)
                    {
                        formGame.tile[monster1.OldCoordinateY * 28 + monster1.OldCoordinateX].BackgroundImage = formGame.pictureBoxBigCandy.Image;
                        formGame.tile[monster1.OldCoordinateY * 28 + monster1.OldCoordinateX].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else
                    {
                        formGame.tile[monster1.OldCoordinateY * 28 + monster1.OldCoordinateX].BackgroundImage = null;
                        formGame.tile[monster1.OldCoordinateY * 28 + monster1.OldCoordinateX].BackColor = Color.Black;
                    }

                    //Dla monster2
                    if (EatMonsterTimer != 0)
                    {
                        formGame.tile[monster2.CoordinateY * 28 + monster2.CoordinateX].BackgroundImage = formGame.pictureBoxMonster.Image;
                        formGame.tile[monster2.CoordinateY * 28 + monster2.CoordinateX].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else
                    {
                        formGame.tile[monster2.CoordinateY * 28 + monster2.CoordinateX].BackgroundImage = formGame.pictureBoxClyde.Image;
                        formGame.tile[monster2.CoordinateY * 28 + monster2.CoordinateX].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    if (SearchOfListSmallCandy(monster2.OldCoordinateX, monster2.OldCoordinateY) == true)
                    {
                        formGame.tile[monster2.OldCoordinateY * 28 + monster2.OldCoordinateX].BackgroundImage = formGame.pictureBoxSmallCandy.Image;
                        formGame.tile[monster2.OldCoordinateY * 28 + monster2.OldCoordinateX].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (SearchOfListBigCandy(monster2.OldCoordinateX, monster2.OldCoordinateY) == true)
                    {
                        formGame.tile[monster2.OldCoordinateY * 28 + monster2.OldCoordinateX].BackgroundImage = formGame.pictureBoxBigCandy.Image;
                        formGame.tile[monster2.OldCoordinateY * 28 + monster2.OldCoordinateX].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else
                    {
                        formGame.tile[monster2.OldCoordinateY * 28 + monster2.OldCoordinateX].BackgroundImage = null;
                        formGame.tile[monster2.OldCoordinateY * 28 + monster2.OldCoordinateX].BackColor = Color.Black;
                    }

                    //Dla monster3
                    if (EatMonsterTimer != 0)
                    {
                        formGame.tile[monster3.CoordinateY * 28 + monster3.CoordinateX].BackgroundImage = formGame.pictureBoxMonster.Image;
                        formGame.tile[monster3.CoordinateY * 28 + monster3.CoordinateX].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else
                    {
                        formGame.tile[monster3.CoordinateY * 28 + monster3.CoordinateX].BackgroundImage = formGame.pictureBoxInky.Image;
                        formGame.tile[monster3.CoordinateY * 28 + monster3.CoordinateX].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    if (SearchOfListSmallCandy(monster3.OldCoordinateX, monster3.OldCoordinateY) == true)
                    {
                        formGame.tile[monster3.OldCoordinateY * 28 + monster3.OldCoordinateX].BackgroundImage = formGame.pictureBoxSmallCandy.Image;
                        formGame.tile[monster3.OldCoordinateY * 28 + monster3.OldCoordinateX].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (SearchOfListBigCandy(monster3.OldCoordinateX, monster3.OldCoordinateY) == true)
                    {
                        formGame.tile[monster3.OldCoordinateY * 28 + monster3.OldCoordinateX].BackgroundImage = formGame.pictureBoxBigCandy.Image;
                        formGame.tile[monster3.OldCoordinateY * 28 + monster3.OldCoordinateX].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else
                    {
                        formGame.tile[monster3.OldCoordinateY * 28 + monster3.OldCoordinateX].BackgroundImage = null;
                        formGame.tile[monster3.OldCoordinateY * 28 + monster3.OldCoordinateX].BackColor = Color.Black;
                    }

                    //Dla monster4
                    if (EatMonsterTimer != 0)
                    {
                        formGame.tile[monster4.CoordinateY * 28 + monster4.CoordinateX].BackgroundImage = formGame.pictureBoxMonster.Image;
                        formGame.tile[monster4.CoordinateY * 28 + monster4.CoordinateX].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else
                    {
                        formGame.tile[monster4.CoordinateY * 28 + monster4.CoordinateX].BackgroundImage = formGame.pictureBoxPinky.Image;
                        formGame.tile[monster4.CoordinateY * 28 + monster4.CoordinateX].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    if (SearchOfListSmallCandy(monster4.OldCoordinateX, monster4.OldCoordinateY) == true)
                    {
                        formGame.tile[monster4.OldCoordinateY * 28 + monster4.OldCoordinateX].BackgroundImage = formGame.pictureBoxSmallCandy.Image;
                        formGame.tile[monster4.OldCoordinateY * 28 + monster4.OldCoordinateX].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else if (SearchOfListBigCandy(monster4.OldCoordinateX, monster4.OldCoordinateY) == true)
                    {
                        formGame.tile[monster4.OldCoordinateY * 28 + monster4.OldCoordinateX].BackgroundImage = formGame.pictureBoxBigCandy.Image;
                        formGame.tile[monster4.OldCoordinateY * 28 + monster4.OldCoordinateX].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else
                    {
                        formGame.tile[monster4.OldCoordinateY * 28 + monster4.OldCoordinateX].BackgroundImage = null;
                        formGame.tile[monster4.OldCoordinateY * 28 + monster4.OldCoordinateX].BackColor = Color.Black;
                    }
                
                //Wyświetlenie pacmana na nowym polu
                if(pacman.MotionDirection == moveUp)
                {
                    formGame.tile[pacman.CoordinateY * 28 + pacman.CoordinateX].BackgroundImage = formGame.pictureBoxPacmanUp.Image;
                }
                if(pacman.MotionDirection == moveDown)
                {
                    formGame.tile[pacman.CoordinateY * 28 + pacman.CoordinateX].BackgroundImage = formGame.pictureBoxPacmanDown.Image;
                }
                if(pacman.MotionDirection == moveLeft)
                {
                    formGame.tile[pacman.CoordinateY * 28 + pacman.CoordinateX].BackgroundImage = formGame.pictureBoxPacmanLeft.Image;
                }
                if(pacman.MotionDirection == moveRight)
                {
                    formGame.tile[pacman.CoordinateY * 28 + pacman.CoordinateX].BackgroundImage = formGame.pictureBoxPacmanRight.Image;
                }
                formGame.tile[pacman.CoordinateY * 28 + pacman.CoordinateX].BackgroundImageLayout = ImageLayout.Stretch;
                //wyczyszczenie starego pola pacmana
                formGame.tile[pacman.OldCoordinateY * 28 + pacman.OldCoordinateX].BackgroundImage = null;

                formGame.UpdateData(pacman);

                System.Threading.Thread.Sleep(formGame.Time);
            }
        }
        /// <summary>
        /// Funkcja zajmująca się spawnowaniem potworów
        /// </summary>
        /// <param name="pacman"></param>
        public void MonsterSpawn(ClassPlayer pacman)
        {
            //Utworzenie nowych potworów
            ClassMonster monster1 = new ClassMonster(12, 14, 1);
            ClassMonster monster2 = new ClassMonster(13, 14, 1);
            ClassMonster monster3 = new ClassMonster(14, 14, 1);
            ClassMonster monster4 = new ClassMonster(15, 14, 1);

            Map[monster1.CoordinateY, monster1.CoordinateX] = monster1.Character;
            Map[monster2.CoordinateY, monster2.CoordinateX] = monster2.Character;
            Map[monster3.CoordinateY, monster3.CoordinateX] = monster3.Character;
            Map[monster4.CoordinateY, monster4.CoordinateX] = monster4.Character;

            //Przekazanie potworów do funkcji zarządzającej ruchami
            MoveManagement(monster1, monster2, monster3, monster4, pacman);
        }
        /// <summary>
        /// Funkcja zajmująca się spawnowaniem małych cukierków
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        public void SmallCandySpawn(ref int y,ref int x)
        {
            if(Map[y,x] == 'o')
            {
                ClassSmallCandy smallCandy = new ClassSmallCandy(x, y);
                ListSmallCandy.Add(smallCandy);
            }
        }
        /// <summary>
        /// Funkcja zajmująca się spawnowaniem dużych cukierków
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        public void BigCandySpawn(ref int y, ref int x)
        {
            if(Map[y,x] == 'd')
            {
                ClassBigCandy bigCandy = new ClassBigCandy(x, y);
                ListBigCandy.Add(bigCandy);
            }
        }
        /// <summary>
        /// Funkcja wczytująca mapę gry
        /// </summary>
        public void MapLoad()
        {
            try
            {
                //Strumień pliku txt
                StreamReader file = new StreamReader("mapa.txt");
                string line;
                int j = 0;
                //Odczyt mapy z pliku
                while ((line = file.ReadLine()) != null)
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        Map[j, i] = line[i];
                        SmallCandySpawn(ref j,ref i);
                        BigCandySpawn(ref j, ref i);
                    }
                    j++;
                }
            }
            catch//Okno wyświetlające komunikat o błędzie odczytu
            {
                MessageBox.Show("Wystąpił błąd podczas wczytywania mapy.");
            }
        }
        /// <summary>
        /// Funkcja spawnująca pacmana
        /// </summary>
        /// <param name="map"></param>
        public void PacmanSpawn(string nick)
        {
            EatMonsterTimer = 0;
            ClassPlayer pacman = new ClassPlayer(13, 22, 3, 0);
            pacman.Name = nick;
            Map[pacman.CoordinateY, pacman.CoordinateX] = '@';
            formGame.tile[pacman.CoordinateY * 28 + pacman.CoordinateX].BackgroundImage = formGame.pictureBoxPacmanUp.Image;
            MonsterSpawn(pacman);
        }
        /// <summary>
        /// Funkcja inizjalizująca okno
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ClassGameMenager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(782, 753);
            this.KeyPreview = true;
            this.Name = "ClassGameMenager";
            this.Load += new System.EventHandler(this.ClassGameMenager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        /// <summary>
        /// Funkcja wywyływana przy ładowaniu okna
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClassGameMenager_Load(object sender, EventArgs e)
        {

        }
    }

}

