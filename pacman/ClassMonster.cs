using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pacman
{
    /// <summary>
    /// Klasa potwora dziedzicząca po klasie postaci
    /// </summary>
    class ClassMonster : ClassForm
    {
        /// <summary>
        /// Stara współrzędna x
        /// </summary>
        public int OldCoordinateX { get; set; }
        /// <summary>
        /// Stara współrzędna y
        /// </summary>
        public int OldCoordinateY { get; set; }
        /// <summary>
        /// Kierunek ruchu gracza
        /// </summary>
        public int MotionDirection { get; set; }
        /// <summary>
        /// Wygląd potwora na mapie
        /// </summary>
        public char Character { get; set; }
        /// <summary>
        /// Wyświetlana ikona potworka
        /// </summary>
        public string Picture { get; set; }
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="k"></param>
        public ClassMonster(int x, int y,int k)
        {
            CoordinateX = x;
            CoordinateY = y;
            MotionDirection = k;
            Character = '!';
        }
    }
}
