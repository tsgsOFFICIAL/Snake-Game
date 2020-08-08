using System;
using System.Text;

namespace Snake_Game
    {
    public class Game
        {
        public static short Rows { get; } = 30 - 2;
        public static short Cols { get; } = 60 - 2;
        public static char[,] Display { get; set; } = new char[Rows, Cols];
        /// <summary>
        /// Start the game
        /// </summary>
        public static void Start()
            {
            Console.Clear();
            GameSetup();
            MainLoop();
            }

        /// <summary>
        /// Set up the game, load the borders, spawn in the snake etc.
        /// </summary>
        private static void GameSetup()
            {
            //SIDES
            for (int i = 0; i <= Display.GetUpperBound(0); i++)
                {
                for (int j = 0; j <= Display.GetUpperBound(1); j++)
                    {
                    Display[i, j] = ' '; //Empty space
                    }
                Display[i, 0] = Asset.Border[4]; //Vertical pipe, left side
                Display[i, Display.GetUpperBound(1)] = Asset.Border[4]; //Vertical pipe, right side
                }

            //TOP
            Display[0, 0] = Asset.Border[0]; //Top left
            for (int i = 1; i <= Display.GetUpperBound(1); i++)
                {
                Display[0, i] = Asset.Border[5]; //Horizontal pipe
                }
            Display[0, Display.GetUpperBound(1)] = Asset.Border[1]; //Top right

            //BOTTOM
            Display[Display.GetUpperBound(0), 0] = Asset.Border[2]; //Bottom left
            for (int i = 1; i <= Display.GetUpperBound(1); i++)
                {
                Display[Display.GetUpperBound(0), i] = Asset.Border[5]; //Horizontal pipe
                }
            Display[Display.GetUpperBound(0), Display.GetUpperBound(1)] = Asset.Border[3]; //Bottom right
            }

        /// <summary>
        /// Main loop of the game, essentially the entire game runs here
        /// </summary>
        private static void MainLoop()
            {
            for (int i = 0; i <= Display.GetUpperBound(0); i++)
                {
                for (int j = 0; j <= Display.GetUpperBound(1); j++)
                    {
                    Console.Write(Display[i, j]);
                    }
                Console.WriteLine();
                }
            Console.ReadKey();
            }
        }
    }
