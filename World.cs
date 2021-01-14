using System;
using System.Collections.Generic;
using System.Text;

namespace inspo_maze
{
    class World
    {
        public string[,] Grid { get; set; }
        public string[,] GridSolution { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public string[,] GeneralFrame { get; set; }

        //public List<string> UserInputs { get; set; } = new List<string>();

        public World(string[,] grid)
        {
            Grid = grid;
            Rows = Grid.GetLength(0);
            Columns = Grid.GetLength(1);
        }

        public void Draw()
        {
            
            //for (int y = 0; y < GeneralFrame.GetLength(0); y++)
            //{
            //    for (int x = 0; x < GeneralFrame.GetLength(1); x++)
            //    {
            //        string element = GeneralFrame[y, x];
            //        Console.SetCursorPosition(x, y);
            //        Console.Write(element);

            //    }

            //}

            //Console.SetWindowSize(Columns, Rows);
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Columns; x++)
                {
                    
                    string element = Grid[y, x];
                    Console.SetCursorPosition(x, y);
                    if (element != "0")
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        Console.Write($"{element}");
                        Console.ResetColor();
                    }
                    //else if (element != comparisonElement) //need to color userinputs differently
                    //{
                    //    Console.ForegroundColor = ConsoleColor.Yellow;
                    //    Console.BackgroundColor = ConsoleColor.Magenta;
                    //    Console.Write($"{element}");
                    //    Console.ResetColor();
                    //}
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.Write($" ");
                        Console.ResetColor();
                    }
                }
            }
        
        }

        //public void DrawLayout(string[,] generalGrid)
        //{
        //    //Console.SetWindowSize(Columns, Rows);
        //    for (int y = 0; y < generalGrid.GetLength(0); y++)
        //    {
        //        for (int x = 0; x < generalGrid.GetLength(1); x++)
        //        {
        //            string element = generalGrid[y, x];
        //            Console.SetCursorPosition(x, y);
        //            Console.Write(element);

        //        }

        //    }
        //}

        //public string GetElement(int x, int y)
        //{
        //    return Grid[x, y];
        //}

        public bool IsPositionEmpty(int x, int y)
        {
            if (x < 4 || y < 1 || x >= Columns-4 || y >= Rows-8) //establishing that the cursor positions exist, if not the person cannot go there/put the input there
            {
                //set the cursor before where we want the error message
                Console.WriteLine("You are out of bounds of the game!");
                System.Threading.Thread.Sleep(300);
                return false;
            }

            return true;  //player should only be able to fill the values with zero
        }
    }
}
