using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
    {
    public class Asset
        {
        public static char[] border { get; set; } = { '\u2554'/*Top left*/, '\u2557'/*Top right*/, '\u255A'/*Bottom left*/, '\u255D'/*Bottom right*/, '\u2551'/*Vertical pipe*/, '\u2550'/*Horizontal pipe*/ };
        public static char snakeHead { get; set; } = '@';
        public static char snakeBody { get; set; } = 'O';
        public static char food { get; set; } = '+';
        public static char death { get; set; } = 'X';
        public static int growthRate { get; set; } = 1;
        }
    }
