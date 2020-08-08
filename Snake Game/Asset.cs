using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
    {
    public class Asset
        {
        /// <summary>
        /// index0 is the top left, index1 is the top right, index2 is the bottom left, index3 is the bottom right, index4 is the vertical pipes and index5 is the horizontal pipes
        /// </summary>
        public static char[] Border { get; set; } = { '\u2554'/*Top left*/, '\u2557'/*Top right*/, '\u255A'/*Bottom left*/, '\u255D'/*Bottom right*/, '\u2551'/*Vertical pipe*/, '\u2550'/*Horizontal pipe*/ };
        public static char SnakeHead { get; set; } = '@';
        public static char SnakeBody { get; set; } = 'O';
        public static char Food { get; set; } = '+';
        public static char Death { get; set; } = 'X';
        public static int GrowthRate { get; set; } = 1;
        }
    }
