using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
    {
    public class Asset
        {
        public static char[] border { get; set; } = { '\u2554', '\u2557', '\u255A', '\u255D', '\u2551', '\u2550' };
        public static char snakeHead { get; set; } = '@';
        public static char snakeBody { get; set; } = 'O';
        public static char food { get; set; } = '+';
        public static char death { get; set; } = 'X';
        public static int growthRate { get; set; } = 1;
        }
    }
