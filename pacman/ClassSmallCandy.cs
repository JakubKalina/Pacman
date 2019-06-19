using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pacman
{
    /// <summary>
    /// Klasa małych cukierków dziedzicząca po klasie postać
    /// </summary>
    class ClassSmallCandy : ClassForm
    {
        /// <summary>
        /// Wygląd cukierka
        /// </summary>
        public char Character { get; set; }
        /// <summary>
        /// Konstruktor
        /// </summary>
        public ClassSmallCandy(int x, int y)
        {
            CoordinateX = x;
            CoordinateY = y;
            Character = '*';
        }
    }

}
