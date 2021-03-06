﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace inspo_maze
{
    class World
    {
        public string[,] Grid { get; set; }
        public string[,] GridUnchanged { get; set; }
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
            int counter = 0;
            GeneralFrame = LevelParser.ParseFileToArray("Frame.txt");
            Console.SetWindowSize(GeneralFrame.GetLength(1), GeneralFrame.GetLength(0));

            for (int y = 0; y < GeneralFrame.GetLength(0); y++)
            {
                for (int x = 0; x < GeneralFrame.GetLength(1); x++)
                {

                    string element = GeneralFrame[y, x];
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($"{element}");
                    Console.ResetColor();
                }
            }

            GridUnchanged = LevelParser.ParseFileToArray("TextFile1.txt"); //šito droši vien vajag pie līmeņiem izdarīt
            //Console.SetWindowSize(Columns, Rows);
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Columns; x++)
                {

                    //if (Grid[y, x] == "1")
                    //{
                    //    Console.SetCursorPosition(0, 0);
                    //    Console.WriteLine(counter++);
                    //    if (counter == 9)
                    //    {
                    //        Console.SetCursorPosition(0, 0);
                    //        Console.WriteLine("No more ones!");
                    //    }
                    //}

                    //if (Grid[y, x] == "2")
                    //{
                    //    Console.SetCursorPosition(0, 0);
                    //    counter++;

                    //    if (counter == 9)
                    //    {
                    //        Console.SetCursorPosition(0, 0);
                    //        Console.WriteLine("No more twos!");
                    //        break;
                    //    }
                    //}

                    string initialElement = GridUnchanged[y, x];
                    string element = Grid[y, x];
                    Console.SetCursorPosition(x, y);
    
                    if (element != initialElement) //need to color userinputs differently
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"{element}");
                        Console.ResetColor();
                    }
                    else if (element != "0")
                    {
                        if ((y ==3 || y == 5 || y == 9 || y == 11 || y == 15 || y == 17) && (x > 3 && x < 39) && x != 15 && x != 27)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.BackgroundColor = ConsoleColor.Magenta;
                            Console.Write($"{element}");
                            Console.ResetColor();
                        }
                        else if (((y == 1 || y == 7 || y == 13 || y == 19) && (x > 1 && x < 41)) || ((y > 1 && y < 19) && (x == 15 || x == 27 || x == 2 || x == 3 || x == 39 || x == 40)))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.BackgroundColor = ConsoleColor.Magenta;
                            Console.Write($"{element}");
                            Console.ResetColor();
                        }
                        else 
                        { 
                         Console.ForegroundColor = ConsoleColor.Cyan;
                         Console.BackgroundColor = ConsoleColor.Magenta;
                         Console.Write($"{element}");
                            Console.ResetColor();
                        
                        }
                       
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.Write($" ");
                        Console.ResetColor();
                    }
                   
                }
            }
        }

        public void CountNumbers(string element, string[,] grid, int y, int x)
        {
            int counter = 1;
            if (grid[y, x] == element)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(counter++);
                if (counter == 9)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("No more {element}!");
                }
            }

        }

        //public string GetElement(int x, int y)
        //{
        //    return Grid[x, y];
        //}

        public bool IsPositionEmpty(int x, int y)
        {
            if (x < 4 || y < 1 || x >= Columns-2 || y >= Rows-2) //establishing that the cursor positions exist, if not the person cannot go there/put the input there
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
