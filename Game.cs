using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace inspo_maze
{
    class Game
    {
        private World MyWorld;
        private Player CurrentPlayer;
        public List<string> UserInputs { get; set; } = new List<string>();
        public List<int> Hints = new List<int>();

        public void Start()
        {
            Console.Title = "THE BEST SUDOKU EVER!";

            //DisplayIntro();
            string[,] grid = LevelParser.ParseFileToArray("Level1.txt");
            MyWorld = new World(grid);
            MyWorld.GridSolution = LevelParser.ParseFileToArray("Level1Solution.txt");
            //MyWorld.GeneralFrame = LevelParser.ParseFileToArray("Frame.txt");
            CurrentPlayer = new Player(5, 2);
            
            RunGameLoop(grid, MyWorld.GridSolution, Hints, MyWorld.GeneralFrame);
            Console.ReadKey(true);
        }

        private void DisplayIntro()
        {
            for (int i = 0; i < 2; i++) //sudoku intro visualisation movement
            {
                PrintSudokuHorizontal();
                System.Threading.Thread.Sleep(300);
                Console.Clear();
                PrintSudoku();
                System.Threading.Thread.Sleep(300);
                Console.Clear();
            }
            InfoAboutGame();
            Console.WriteLine();
        }

        private void DisplayOutro()
        {

        }
        private void DrawFrame(string[,] grid)
        {
            Console.Clear();
            MyWorld.Draw();
            CurrentPlayer.Draw(grid);
        }
    
        private void HandlePlayerInput(string [,] grid, string[,] gridSolution, List<int> Hints)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            ConsoleKey key = keyInfo.Key;
            int number = 1;
            if (key == ConsoleKey.H)
            {
                Hints.Add(number);
            }
            
            switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        if (MyWorld.IsPositionEmpty(CurrentPlayer.X - 4, CurrentPlayer.Y))
                        {
                            CurrentPlayer.X -= 4;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (MyWorld.IsPositionEmpty(CurrentPlayer.X, CurrentPlayer.Y - 2))
                        {
                            CurrentPlayer.Y -= 2;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (MyWorld.IsPositionEmpty(CurrentPlayer.X + 4, CurrentPlayer.Y))
                        {
                            CurrentPlayer.X += 4;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (MyWorld.IsPositionEmpty(CurrentPlayer.X, CurrentPlayer.Y + 2))
                        {
                            CurrentPlayer.Y += 2;
                        }
                        break;

                    case ConsoleKey.Tab:
                        {
                            int x = CurrentPlayer.X;
                            int y = CurrentPlayer.Y;
                            string answer = gridSolution[CurrentPlayer.Y, CurrentPlayer.X];

                            if (grid[y, x] == "0")
                            {
                                Console.SetCursorPosition(x, y);
                                string input = Console.ReadLine();
                                if (input == answer)
                                {
                                Console.SetCursorPosition(55, 24);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Success!");
                                Console.ResetColor();
                                System.Threading.Thread.Sleep(400);
                                grid[y, x] = input;
                                UserInputs.Add(input);
                                }
                                else
                                {
                                Console.SetCursorPosition(53, 24);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Wrong number!");
                                Console.ResetColor();
                                System.Threading.Thread.Sleep(400);
                                }

                            }  
                        }
                        break;
                    case ConsoleKey.H:

                    if (grid[CurrentPlayer.Y, CurrentPlayer.X] == "0")
                    {
                        if (Hints.Sum(x => x) <= 3)
                        {
                            Console.WriteLine("This is your hint!");
                            grid[CurrentPlayer.Y, CurrentPlayer.X] = gridSolution[CurrentPlayer.Y, CurrentPlayer.X];
                            System.Threading.Thread.Sleep(400);
                        }
                        else
                        {
                            Console.WriteLine("Sorry you are out of hints!");
                        }
                    }
                    else
                    {
                            Console.SetCursorPosition(CurrentPlayer.Y, CurrentPlayer.X);
                            Console.WriteLine("Can't give a hint!");
                            System.Threading.Thread.Sleep(400);
                           
                    }
                        break;
                //case ConsoleKey.Escape
                //go to end
                //break;
                case ConsoleKey.R:

                   

                    break;
                    default:
                        break;
            }
        }
        
        private void RunGameLoop(string[,] grid, string[,] gridSolution, List<int> Hints, string[,] generalGrid)
        {
            while (true)
            {
                //Draw everything
                DrawFrame(grid);
                //Check player input
              
                HandlePlayerInput(grid, gridSolution, Hints);
                //Check if the player has reached the exit and end the game if so
                //string elementAtPlayerPos = MyWorld.GetElement(CurrentPlayer.X, CurrentPlayer.Y);
                Console.SetCursorPosition(0, 0);
                
                int counter = 0;
                for (int y = 0; y < grid.GetLength(0); y++)
                {
                    for (int x = 0; x < grid.GetLength(1); x++)
                    {
                        if (grid[y,x] == gridSolution[y,x])
                        {
                            counter++;
                        }
                        if (counter == grid.GetLength(0) * grid.GetLength(1))
                        {
                            System.Threading.Thread.Sleep(2000);
                            Console.Clear();
                            YouWonvisualisation();
                            break;
                        }

                    }
                }


            }
        }
        static void PrintSudoku()
        {
            Console.ForegroundColor = ConsoleColor.Magenta; //HERE STARTS NAME SUDOKU VERTICALY
            Console.SetCursorPosition(2, 5);
            Console.WriteLine("OOOOO          O   O");
            Console.SetCursorPosition(1, 6);
            Console.WriteLine("OOOOOOO        OO   OO");
            Console.SetCursorPosition(1, 7);
            Console.WriteLine("OOO  OO        OO   OO");
            Console.SetCursorPosition(2, 8);
            Console.WriteLine("OOO           OO   OO");
            Console.SetCursorPosition(3, 9);
            Console.WriteLine("OOO          OO   OO");
            Console.SetCursorPosition(4, 10);
            Console.WriteLine("OOO         OO   OO");
            Console.SetCursorPosition(1, 11);
            Console.WriteLine("OO  OOO        OO   OO");
            Console.SetCursorPosition(1, 12);
            Console.WriteLine("OOOOOOO         OO OO");
            Console.SetCursorPosition(2, 13);
            Console.WriteLine("OOOOO           OOO");
            Console.SetCursorPosition(16, 14);
            Console.WriteLine("O     OOOOO");
            Console.SetCursorPosition(16, 15);
            Console.WriteLine("OO   OOO OOO");
            Console.SetCursorPosition(16, 16);
            Console.WriteLine("OO   OO   OO");
            Console.SetCursorPosition(16, 17);
            Console.WriteLine("OO   OO   OO");
            Console.SetCursorPosition(12, 18);
            Console.WriteLine("OOOOOO   OO   OO");
            Console.SetCursorPosition(11, 19);
            Console.WriteLine("OOO OOO   OO   OO");
            Console.SetCursorPosition(11, 20);
            Console.WriteLine("OO   OO   OO   OO");
            Console.SetCursorPosition(11, 21);
            Console.WriteLine("OOO OOO   OOO OOO");
            Console.SetCursorPosition(12, 22);
            Console.WriteLine("OOOOO     OOOOO");
            Console.SetCursorPosition(22, 23);
            Console.WriteLine("O   OO    O   O");
            Console.SetCursorPosition(21, 24);
            Console.WriteLine("OO  OO    OO   OO");
            Console.SetCursorPosition(21, 25);
            Console.WriteLine("OO OO     OO   OO");
            Console.SetCursorPosition(21, 26);
            Console.WriteLine("OOOO      OO   OO");
            Console.SetCursorPosition(21, 27);
            Console.WriteLine("OOOO      OO   OO");
            Console.SetCursorPosition(21, 28);
            Console.WriteLine("OO OO     OO   OO");
            Console.SetCursorPosition(21, 29);
            Console.WriteLine("OO  OO    OO   OO");
            Console.SetCursorPosition(21, 30);
            Console.WriteLine("OO   OO    OO OO");
            Console.SetCursorPosition(22, 31);
            Console.WriteLine("O   O      OOO");
            //HERE STARTS THE SMALL SUDOKU SQUARE CODE
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(40, 10);
            Console.WriteLine(" ______________");
            Console.SetCursorPosition(40, 11);
            Console.WriteLine("| 2  |    |  1 |");
            Console.SetCursorPosition(40, 12);
            Console.WriteLine("|    |  4 |    |");
            Console.SetCursorPosition(40, 13);
            Console.WriteLine("|____|____|____|");
            Console.SetCursorPosition(40, 14);
            Console.WriteLine("|    |    |  9 |");
            Console.SetCursorPosition(40, 15);
            Console.WriteLine("|    |  6 |    |");
            Console.SetCursorPosition(40, 16);
            Console.WriteLine("|____|____|____|");
            Console.SetCursorPosition(40, 17);
            Console.WriteLine("| 8  |    |  7 |");
            Console.SetCursorPosition(40, 18);
            Console.WriteLine("|    |    |    |");
            Console.SetCursorPosition(40, 19);
            Console.WriteLine("|____|____|____|");
            Console.ResetColor();

        } //visuazlization for game intro
        static void PrintSudokuHorizontal()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(2, 2);
            Console.WriteLine("OOOOO    O   O        O    OOOOO    O   OO   O   O");
            Console.SetCursorPosition(1, 3);
            Console.WriteLine("OOOOOOO  OO   OO       OO  OOO OOO  OO  OO   OO   OO");
            Console.SetCursorPosition(1, 4);
            Console.WriteLine("OOO  OO  OO   OO       OO  OO   OO  OO OO    OO   OO");
            Console.SetCursorPosition(2, 5);
            Console.WriteLine("OOO     OO   OO       OO  OO   OO  OOOO     OO   OO");
            Console.SetCursorPosition(3, 6);
            Console.WriteLine("OOO    OO   OO   OOOOOO  OO   OO  OOOO     OO   OO");
            Console.SetCursorPosition(4, 7);
            Console.WriteLine("OOO   OO   OO  OOO OOO  OO   OO  OO OO    OO   OO");
            Console.SetCursorPosition(1, 8);
            Console.WriteLine("OO  OOO  OO   OO  OO   OO  OO   OO  OO  OO   OO   OO");
            Console.SetCursorPosition(1, 9);
            Console.WriteLine("OOOOOOO   OO OO   OOO OOO  OOO OOO  OO   OO   OO OO");
            Console.SetCursorPosition(2, 10);
            Console.WriteLine("OOOOO     OOO     OOOOO    OOOOO    O   OO    OOO");

        } //visuazlization for game intro

        static void InfoAboutGame()
        {
            Console.Clear(); //after each movement clear screen and then show again
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.SetCursorPosition(25, 2);
            Console.WriteLine("GAME  'SUDOKU'");
            Console.SetCursorPosition(5, 4);
            Console.WriteLine("What is Sudoku?");
            Console.SetCursorPosition(8, 6);
            Console.WriteLine("A sudoku puzzle is a grid of 9 X 9 cells, that has been subdivided into nine subgrids of 3 X 3 cells.");
            Console.SetCursorPosition(8, 8);
            Console.WriteLine("The objective of sudoku is to enter a digit from 1 through 9 in each cell, in such a way that:");
            Console.SetCursorPosition(11, 9);
            Console.WriteLine(" * Each horizontal row contains each digit exactly once");
            Console.SetCursorPosition(11, 10);
            Console.WriteLine(" * Each vertical column contains each digit exactly once");
            Console.SetCursorPosition(11, 11);
            Console.WriteLine(" * Each subgrid contains each digit exactly once");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press:");
            Console.WriteLine("1 - to start new game");
            Console.WriteLine();
            Console.WriteLine("2 - to see leaderboard");
            Console.WriteLine();
            Console.WriteLine("3 - to exit game");
            Console.WriteLine();
            string chosedmenuitem = Console.ReadLine();

            switch (chosedmenuitem)
            {
                case "1":
                    choseLevel();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Leaderboard coming soon...");
                    BackToMenu();
                    break;
                case "3":
                    exit();
                    break;
            }






        }
        static void choseLevel() //should add path from each level, to startgame
        {
            Console.Clear();
            PrintSudokuHorizontal();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Please choose one of below mentioned levels:");
            Console.WriteLine("Press '1' for EASY Sudoku");
            Console.WriteLine("Press '2' for MEDIUM Sudoku");
            Console.WriteLine("Press '3' for HARD Sudoku");
            Console.WriteLine();
            Console.WriteLine("To go back to menu press 'N'.");
            string levelchose = Console.ReadLine();
            switch (levelchose)
            {
                case "1":
                    Console.WriteLine("You chose easy");
                    
                    break;
                case "2":
                    Console.WriteLine("You chose medium"); //add method here
                    break;
                case "3":
                    Console.WriteLine("You chose hard"); //add method here
                    break;
                case "N":
                    InfoAboutGame();
                    break;
                case "n":
                    InfoAboutGame();
                    break;

            }
            Console.ResetColor();
        }

        //public string[,] LevelChoice()
        //{
        //    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        //    ConsoleKey key = keyInfo.Key;
        //    switch (key)
        //    {
        //        case ConsoleKey.NumPad1:
        //            return LevelParser.ParseFileToArray("Level1.txt");
        //            break;

        //        default:
        //            break;
        //    }
        //    return null;


        //}
        static void exit()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Nooooooo.....don`t go away!");
            Console.WriteLine("We hope you changed your mind.");
            Console.WriteLine("Press 'Y' to exit or 'N' to go back to menu and enjoy game!");
            string exityesno = Console.ReadLine();

            switch (exityesno)
            {
                case "y":
                    Environment.Exit(0);
                    break;
                case "Y":
                    Environment.Exit(0);
                    break;
                case "n":
                    InfoAboutGame();
                    break;
                case "N":
                    InfoAboutGame();
                    break;
            }
            System.Threading.Thread.Sleep(1000000);
        }
        static void BackToMenu()
        {
            Console.WriteLine("Press 'N' to go back to menu and enjoy game!");
            string backtomenu = Console.ReadLine();
            switch (backtomenu)
            {
                case "N":
                    InfoAboutGame();
                    break;
                case "n":
                    InfoAboutGame();
                    break;

            }
        }
        static void YouWonvisualisation()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(2, 1);
            Console.WriteLine("O   O    OOOOO    O   O       O   O    OOOOO    O OOO");
            Console.SetCursorPosition(1, 2);
            Console.WriteLine("OO   OO  OOO OOO  OO   OO     OO O OO  OOO OOO  OOOOOOO");
            Console.SetCursorPosition(1, 3);
            Console.WriteLine("OO   OO  OO   OO  OO   OO     OO O OO  OO   OO  OO  OOO");
            Console.SetCursorPosition(2, 4);
            Console.WriteLine("OO OOO  OO   OO  OO   OO     OO O OO  OO   OO  OO   OO");
            Console.SetCursorPosition(3, 5);
            Console.WriteLine("OOOOO  OO   OO  OO   OO     OO O OO  OO   OO  OO   OO");
            Console.SetCursorPosition(1, 6);
            Console.WriteLine("O    OO  OO   OO  OO   OO     OO O OO  OO   OO  OO   OO");
            Console.SetCursorPosition(1, 7);
            Console.WriteLine("OOO OOO  OOO OOO  OOO OOO     OOOOOOO  OOO OOO  OO   OO");
            Console.SetCursorPosition(2, 8);
            Console.WriteLine("OOOOO    OOOOO    OOOOO       OO OO    OOOOO    O   O");

        }
    }
}
