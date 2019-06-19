using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pacman
{
    /// <summary>
    /// Klasa gracza dziedzicząca po klasie postaci
    /// </summary>
    public class ClassPlayer : ClassForm
    {
        /// <summary>
        /// Zebrane punkty
        /// </summary>
        public int Points { get; set; }
        /// <summary>
        /// Życia gracza
        /// </summary>
        public int Lifes { get; set; }
        /// <summary>
        /// Kierunek ruchu gracza
        /// </summary>
        public int MotionDirection { get; set; }
        /// <summary>
        /// Stary kierunek ruchu gracza
        /// </summary>
        public int OldMotionDirection { get; set; }
        /// <summary>
        /// Stara współrzędna x
        /// </summary>
        public int OldCoordinateX { get; set; }
        /// <summary>
        /// Stara współrzędna y
        /// </summary>
        public int OldCoordinateY { get; set; }
        /// <summary>
        /// Lista odwiedzonych współrzędnych x
        /// </summary>
        public List<int> VisitedCoordinateX = new List<int>();
        /// <summary>
        /// Lista odwiedzonych współrzędnych y
        /// </summary>
        public List<int> VisitedCoordinateY = new List<int>();
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="l"></param>
        /// <param name="p"></param>
        /// <param name="n"></param>
        public ClassPlayer(int x, int y, int l, int p)
        {
            CoordinateX = x;
            CoordinateY = y;
            Lifes = l;
            Points = p;
            Name = "Player";
            MotionDirection = 0;
        }
    }
}
