using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pacman
{
    /// <summary>
    /// Klasa dużych cukierków dziedzicząca po klasie postać
    /// </summary>
    class ClassBigCandy : ClassForm
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public ClassBigCandy(int x, int y)
        {
            CoordinateX = x;
            CoordinateY = y;
        }
    }
}
