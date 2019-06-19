using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pacman
{
    /// <summary>
    /// Klasa postać
    /// </summary>
    abstract public class ClassForm
    {
        /// <summary>
        /// Nazwa
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Współrzędna x
        /// </summary>
        public int CoordinateX { get; set; }
        /// <summary>
        /// Współrzędna y
        /// </summary>
        public int CoordinateY { get; set; }

    }
}
