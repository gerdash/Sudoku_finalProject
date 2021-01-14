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
        //add grid as a property - new class for grids
        public List<string> UserInputs { get; set; } = new List<string>();
        public List<int> Hints = new List<int>();
        public void Start()
        {
            Console.Title = "THE BEST SUDOKU EVER!";
            string[,] grid = LevelParser.ParseFileToArray("Level1.txt");
            MyWorld = new World(grid);
            MyWorld.GridSolution = LevelParser.ParseFileToArray("Level1Solution.txt");
            MyWorld.GeneralFrame = LevelParser.ParseFileToArray("GeneralFrame.txt");
            CurrentPlayer = new Player(8, 6);
            RunGameLoop(grid, MyWorld.GridSolution, Hints, MyWorld.GeneralFrame);
            Console.ReadKey(true);
        }

        private void DisplayIntro()
        {

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
                            while (grid[y, x] == "0")
                            {
                                Console.SetCursorPosition(x, y);
                                string input = Console.ReadLine();
                                if (input == answer)
                                {
                                    Console.SetCursorPosition(x, y);
                                    Console.WriteLine("Success!");
                                    System.Threading.Thread.Sleep(400);
                                    grid[y, x] = input;
                                    UserInputs.Add(input);
                            }
                                else
                                {
                                    Console.SetCursorPosition(x, y);
                                    Console.WriteLine("Your input was incorrect!");
                                    System.Threading.Thread.Sleep(400);
                                    break;
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
                
                int counter = 0;
                for (int y = 0; y < grid.GetLength(0); y++)
                {
                    for (int x = 0; x < grid.GetLength(1); x++)
                    {
                        if (grid[y,x] == gridSolution[y,x])
                        {
                          
                            counter++;
                        }

                    }

                    if (counter == grid.GetLength(0)*grid.GetLength(1))
                    {
                        System.Threading.Thread.Sleep(2000);
                        Console.Clear();
                        Console.WriteLine("You've won!");
                        break;
                    }

                }

             

            }
        }
    }
}
