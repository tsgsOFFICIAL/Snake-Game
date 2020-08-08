using System;
using System.Collections.Generic;
using System.Threading;

namespace Snake_Game
    {
    public class Game
        {
        public static short Rows { get; } = 30 - 2; //Amount of rows
        public static short Cols { get; } = 60 - 2; //Amount of cols in each row
        public static char[,] Display { get; set; } = new char[Rows, Cols]; //Display / Grid to play on
        public static int[] SnakeHeadPos { get; set; } = new int[2]; //X, Y for the snake head
        public static List<int> SnakeBodyPosX { get; set; } = new List<int>();
        public static List<int> SnakeBodyPosY { get; set; } = new List<int>();
        public static char Facing { get; set; } = 'E'; //North, South, East and West
        public static int FoodCount { get; set; } = 0;
        public static int SnakeLength { get; set; } = 5;
        /// <summary>
        /// Start the game
        /// </summary>
        public static void Start()
            {
            Console.Clear();
            GameSetup();
            UpdateDisplay();
            Console.WriteLine("Press any key to start!");
            Console.ReadKey(true);
            Console.Clear();
            MainLoop();
            Console.ReadKey();
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

            //Spawn snake
            Display[Display.GetUpperBound(0) / 2, Display.GetUpperBound(1) / 2] = Asset.SnakeHead;
            SnakeHeadPos[0] = Display.GetUpperBound(1) / 2;
            SnakeHeadPos[1] = Display.GetUpperBound(0) / 2;
            for (int i = 1; i <= SnakeLength; i++)
                {
                Display[Display.GetUpperBound(0) / 2, Display.GetUpperBound(1) / 2 - i] = Asset.SnakeBody;
                SnakeBodyPosX.Add(Display.GetUpperBound(0) / 2);
                SnakeBodyPosY.Add(Display.GetUpperBound(1) / 2 - i);
                }
            }

        /// <summary>
        /// Main loop of the game, essentially the entire game runs here
        /// </summary>
        private static void MainLoop()
            {
            UpdateDisplay();
            ConsoleKeyInfo keyInfo;
            while (!Console.KeyAvailable)
                {
                Move();
                UpdateDisplay();
                }
            keyInfo = Console.ReadKey(true);
            Move(keyInfo.KeyChar);
            }

        /// <summary>
        /// Updating the display since 2020 ;)
        /// </summary>
        private static void UpdateDisplay()
            {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i <= Display.GetUpperBound(0); i++)
                {
                for (int j = 0; j <= Display.GetUpperBound(1); j++)
                    {
                    Console.Write(Display[i, j]);
                    }
                Console.WriteLine();
                }
            }

        /// <summary>
        /// Move the snake in the direction it is facing
        /// </summary>
        private static void Move()
            {
            switch (Facing)
                {
                case 'N':
                    if (Display[SnakeHeadPos[1] - 1, SnakeHeadPos[0]] == Asset.Border[0] || Display[SnakeHeadPos[1] - 1, SnakeHeadPos[0]] == Asset.Border[1] || Display[SnakeHeadPos[1] - 1, SnakeHeadPos[0]] == Asset.Border[2] || Display[SnakeHeadPos[1] - 1, SnakeHeadPos[0]] == Asset.Border[3] || Display[SnakeHeadPos[1] - 1, SnakeHeadPos[0]] == Asset.Border[4] || Display[SnakeHeadPos[1] - 1, SnakeHeadPos[0]] == Asset.Border[5] || Display[SnakeHeadPos[1] - 1, SnakeHeadPos[0]] == Asset.SnakeBody)
                        {
                        Lose();
                        }
                    else if (Display[SnakeHeadPos[1] - 1, SnakeHeadPos[0]] == Asset.Food)
                        {
                        FoodCount--;
                        SnakeLength++;
                        }
                    Display[SnakeHeadPos[1], SnakeHeadPos[0]] = ' ';
                    SnakeHeadPos[1]--;
                    Display[SnakeHeadPos[1], SnakeHeadPos[0]] = Asset.SnakeHead;
                    break;
                case 'S':

                    break;
                case 'E':

                    break;
                case 'W':

                    break;
                }
            Thread.Sleep(200);
            }

        /// <summary>
        /// Move the snake in a specified direction, if possible
        /// </summary>
        /// <param name="direction">The direction is specifien by the players keypresses</param>
        private static void Move(char direction)
            {
            if (direction == Control.MoveLeft)
                {

                }
            else if (direction == Control.MoveRight)
                {

                }
            else if (direction == Control.MoveUp)
                {

                }
            else if (direction == Control.MoveDown)
                {

                }
            }

        public static void Lose()
            {
            Console.SetCursorPosition(0, Display.GetUpperBound(1) + 2);
            Console.WriteLine("You died");
            Console.ReadKey(true);
            
            }
        }
    }
