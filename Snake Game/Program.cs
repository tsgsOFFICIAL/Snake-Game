using System;
using System.IO;
using System.Text;
using System.Reflection;
using System.Diagnostics;
using System.Threading;

namespace Snake_Game
    {
    class Program
        {
        const string developer = "tsgsOFFICIAL";

        static void Main(string[] args)
            {
            Console.Title = $"Snake Game - Made by {developer}";
            Console.OutputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.White;
            LoadSettings();
            MainMenu();
            }
        
        /// <summary>
        /// Display the Main menu
        /// </summary>
        static void MainMenu()
            {
            Console.Clear();
            Console.WriteLine("Main Menu\n");
            Console.WriteLine("Press 'N' to start a new game");
            Console.WriteLine("Press 'C' to see controls");
            Console.WriteLine("Press 'G' to see and/or change graphics");
            Console.WriteLine("Press 'R' to reset all settings, this cannot be undone!");
            Console.WriteLine("Press 'Q' to quit");

            bool keepGoing = false;
            ConsoleKeyInfo key;
            do
                {
                key = Console.ReadKey(true);
                switch (key.KeyChar.ToString().ToUpper())
                    {
                    case "N":
                        keepGoing = true;
                        Game.Start();
                        break;
                    case "C":
                        keepGoing = true;
                        ControlsMenu();
                        break;
                    case "G":
                        keepGoing = true;
                        GraphicsMenu();
                        break;
                    case "R":
                        keepGoing = true;
                        try
                            {
                            File.Delete(Path.GetTempPath() + "snakeSettings.tsgs");
                            }
                        catch (Exception)
                            { }
                        Process.Start(Assembly.GetExecutingAssembly().Location.Substring(0, Assembly.GetExecutingAssembly().Location.LastIndexOf('.')) + ".exe");
                        Environment.Exit(0);
                        break;
                    case "Q":
                        Environment.Exit(0);
                        break;
                    }
                }
            while (keepGoing != true);
            }

        /// <summary>
        /// Display the Controls menu, here the user can also change his or her controls
        /// </summary>
        static void ControlsMenu()
            {
            Console.Clear();
            Console.WriteLine("Controls Menu\n");
            Console.WriteLine("Left   = '{0}' (L)", Control.moveLeft);
            Console.WriteLine("Right  = '{0}' (R)", Control.moveRight);
            Console.WriteLine("Up     = '{0}' (U)", Control.moveUp);
            Console.WriteLine("Down   = '{0}' (D)\n", Control.moveDown);
            Console.WriteLine("Pause  = '{0}' (P)\n", Control.pause);
            Console.WriteLine("Return = {ENTER}");

            bool keepGoing = false;
            ConsoleKeyInfo key;
            do
                {
                key = Console.ReadKey(true);
                switch (key.Key)
                    {
                    case ConsoleKey.L:
                        keepGoing = true;
                        Console.Write("\nChange left: ");
                        key = Console.ReadKey(true);
                        if (ValidateSetings(key.KeyChar))
                            {
                            Control.moveLeft = Console.ReadKey(false).KeyChar;
                            }
                        else
                            {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nERROR, You can't have 2 duplicates!");
                            Thread.Sleep(1250);
                            Console.ForegroundColor = ConsoleColor.White;
                            }
                        break;
                    case ConsoleKey.R:
                        keepGoing = true;
                        Console.Write("\nChange right: ");
                        key = Console.ReadKey(true);
                        if (ValidateSetings(key.KeyChar))
                            {
                            Control.moveRight = Console.ReadKey(false).KeyChar;
                            }
                        else
                            {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nERROR, You can't have 2 duplicates!");
                            Thread.Sleep(1250);
                            Console.ForegroundColor = ConsoleColor.White;
                            }
                        break;
                    case ConsoleKey.U:
                        keepGoing = true;
                        Console.Write("\nChange up: ");
                        key = Console.ReadKey(true);
                        if (ValidateSetings(key.KeyChar))
                            {
                            Control.moveUp = Console.ReadKey(false).KeyChar;
                            }
                        else
                            {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nERROR, You can't have 2 duplicates!");
                            Thread.Sleep(1250);
                            Console.ForegroundColor = ConsoleColor.White;
                            }
                        break;
                    case ConsoleKey.D:
                        keepGoing = true;
                        Console.Write("\nChange down: ");
                        key = Console.ReadKey(true);
                        if (ValidateSetings(key.KeyChar))
                            {
                            Control.moveDown = Console.ReadKey(false).KeyChar;
                            }
                        else
                            {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nERROR, You can't have 2 duplicates!");
                            Thread.Sleep(1250);
                            Console.ForegroundColor = ConsoleColor.White;
                            }
                        break;
                    case ConsoleKey.P:
                        keepGoing = true;
                        Console.Write("\nChange pause: ");
                        key = Console.ReadKey(true);
                        if (ValidateSetings(key.KeyChar))
                            {
                            Control.pause = Console.ReadKey(false).KeyChar;
                            }
                        else
                            {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nERROR, You can't have 2 duplicates!");
                            Thread.Sleep(1250);
                            Console.ForegroundColor = ConsoleColor.White;
                            }
                        break;
                    case ConsoleKey.Enter:
                        SaveSettings();
                        MainMenu();
                        break;
                    }
                }
            while (keepGoing != true);
            SaveSettings();
            ControlsMenu();
            }

        /// <summary>
        /// Display the Graphics menu, here the user can see and change most of the graphics, except for the Border
        /// </summary>
        static void GraphicsMenu()
            {
            Console.Clear();
            Console.WriteLine("Graphics Menu\n");
            Console.WriteLine("Border       = {0} {1} {2} {3} {4} {5}", Asset.Border[0], Asset.Border[1], Asset.Border[2], Asset.Border[3], Asset.Border[4], Asset.Border[5]);
            Console.WriteLine("Empty space  = ");
            Console.WriteLine("Snake Head   = '{0}'         (H)", Asset.SnakeHead);
            Console.WriteLine("Snake Body   = '{0}'         (B)", Asset.SnakeBody);
            Console.Write("Food         = '");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("{0}", Asset.Food);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("'         (F)");

            Console.Write("Death        = '");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("{0}", Asset.Death);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("'         (D)\n");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Growth Rate  = {0}           (G)\n", Asset.GrowthRate);
            Console.WriteLine("Return = {ENTER}");

            bool keepGoing = false;
            ConsoleKeyInfo key;
            do
                {
                key = Console.ReadKey(true);
                switch (key.Key)
                    {
                    case ConsoleKey.H:
                        keepGoing = true;
                        Console.Write("\nChange head: ");
                        key = Console.ReadKey(true);
                        if (ValidateSetings(key.KeyChar))
                            {
                            Asset.SnakeHead = Console.ReadKey(false).KeyChar;
                            }
                        else
                            {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nERROR, You can't have 2 duplicates!");
                            Thread.Sleep(1250);
                            Console.ForegroundColor = ConsoleColor.White;
                            }
                        break;
                    case ConsoleKey.B:
                        keepGoing = true;
                        Console.Write("\nChange body: ");
                        key = Console.ReadKey(true);
                        if (ValidateSetings(key.KeyChar))
                            {
                            Asset.SnakeBody = Console.ReadKey(false).KeyChar;
                            }
                        else
                            {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nERROR, You can't have 2 duplicates!");
                            Thread.Sleep(1250);
                            Console.ForegroundColor = ConsoleColor.White;
                            }
                        break;
                    case ConsoleKey.F:
                        keepGoing = true;
                        Console.Write("\nChange Food: ");
                        key = Console.ReadKey(true);
                        if (ValidateSetings(key.KeyChar))
                            {
                            Asset.Food = Console.ReadKey(false).KeyChar;
                            }
                        else
                            {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nERROR, You can't have 2 duplicates!");
                            Thread.Sleep(1250);
                            Console.ForegroundColor = ConsoleColor.White;
                            }
                        break;
                    case ConsoleKey.D:
                        keepGoing = true;
                        Console.Write("\nChange Death: ");
                        key = Console.ReadKey(true);
                        if (ValidateSetings(key.KeyChar))
                            {
                            Asset.Death = Console.ReadKey(false).KeyChar;
                            }
                        else
                            {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nERROR, You can't have 2 duplicates!");
                            Thread.Sleep(1250);
                            Console.ForegroundColor = ConsoleColor.White;
                            }
                        break;
                    case ConsoleKey.G:
                        keepGoing = true;
                        Console.Write("\nChange growth: ");
                        key = Console.ReadKey(true);
                        if (ValidateSetings(key.KeyChar))
                            {
                            try
                                {
                                Asset.GrowthRate = Convert.ToInt32(Console.ReadLine());
                                }
                            catch (Exception)
                                { }
                            }
                        else
                            {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nERROR, You can't have 2 duplicates!");
                            Thread.Sleep(1250);
                            Console.ForegroundColor = ConsoleColor.White;
                            }
                        break;
                    case ConsoleKey.Enter:
                        SaveSettings();
                        MainMenu();
                        break;
                    }
                }
            while (keepGoing != true);
            SaveSettings();
            GraphicsMenu();
            }

        /// <summary>
        /// LoadSettings() will attempt to load settings from %temp%/snakeSettings.tsgs
        /// </summary>
        static void LoadSettings()
            {
            string[] _setting = null;
            char[] setting = new char[10];
            if (File.Exists(Path.GetTempPath() + "snakeSettings.tsgs"))
                {
                try
                    {
                    _setting = File.ReadAllLines(Path.GetTempPath() + "snakeSettings.tsgs");
                    }
                catch (Exception)
                    { }
                }
            else
                {
                Console.WriteLine("No settings found, loading original settings");
                Thread.Sleep(1250);
                MainMenu();
                }

            if (_setting.Length == 10)
                {
                for (int i = 0; i < _setting.Length - 1; i++)
                    {
                    setting[i] = Convert.ToChar(_setting[i].Trim());
                    }

                Control.moveLeft = setting[0];
                Control.moveRight = setting[1];
                Control.moveUp = setting[2];
                Control.moveDown = setting[3];
                Control.pause = setting[4];
                Asset.SnakeHead = setting[5];
                Asset.SnakeBody = setting[6];
                Asset.Food = setting[7];
                Asset.Death = setting[8];
                Asset.GrowthRate = Convert.ToInt32(_setting[9]);
                }
            }

        /// <summary>
        /// SaveSettings() will attempt to save the user defined settings under %temp%/snakeSettings.tsgs
        /// </summary>
        static void SaveSettings()
            {
            string[] setting = new string[10];
            setting[0] = $"{Control.moveLeft}";
            setting[1] = $"{Control.moveRight}";
            setting[2] = $"{Control.moveUp}";
            setting[3] = $"{Control.moveDown}";
            setting[4] = $"{Control.pause}";
            setting[5] = $"{Asset.SnakeHead}";
            setting[6] = $"{Asset.SnakeBody}";
            setting[7] = $"{Asset.Food}";
            setting[8] = $"{Asset.Death}";
            setting[9] = $"{Asset.GrowthRate}";
            try
                {
                StreamWriter writer = new StreamWriter(Path.GetTempPath() + "snakeSettings.tsgs");
                for (int i = 0; i < setting.Length - 1; i++)
                    {
                    writer.WriteLine(setting[i]);
                    }
                writer.Write(setting[9]);
                writer.Close();
                }
            catch (Exception)
                { }
            }

        /// <summary>
        /// Validate if the settings are valid, you can't have multiple controls on the same key for example!
        /// </summary>
        /// <returns>True if no duplicates are found</returns>
        static bool ValidateSetings(char changed)
            {
            string[] setting = new string[9];
            setting[0] = $"{Control.moveLeft}";
            setting[1] = $"{Control.moveRight}";
            setting[2] = $"{Control.moveUp}";
            setting[3] = $"{Control.moveDown}";
            setting[4] = $"{Control.pause}";
            setting[5] = $"{Asset.SnakeHead}";
            setting[6] = $"{Asset.SnakeBody}";
            setting[7] = $"{Asset.Food}";
            setting[8] = $"{Asset.Death}";

            for (int i = 0; i < setting.Length; i++)
                {
                if (setting[i] == changed.ToString())
                    {
                    return false;
                    }
                }

            return true;
            }
        }
    }
