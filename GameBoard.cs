using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectSudoku
{
    class GameBoard
    {
        public int[,] Puzzle { get; set; } = new int[9, 9]; //solve how to store multiple of these/In levels - probably not one class one level, but Lists of arrays FOR levels
        public int[,] Solution { get; set; } = new int[9, 9];
        public List <Players> Participants { get; set; } = new List <Players>();
        public List <Players> Winners { get; set; } = new List <Players>();  

        //ASK Jānis how complicated it would be to do scratch numbers
        public void MakingMoves()
        {
            //define keys to move, new game, exit, hint
            //all the checks for input number and what happens after
            //hints --> separate class in Puzzle? each puzzle has specific hints or automatic ones? Logic hints or number hints? could do HINTS AND LIFELINES
            //check solution
            //progress
            
        }

        public void PrintGameBoard(int[,] puzzle)
        {
            //Extra: placement in the centre of the console
            //Replace zeros with gaps or empty spaces?? Maybe? Is that making things too complicated or is it actually easy? 
            Console.WriteLine("+-----------+-----------+-----------+");

            for (int row = 0; row < puzzle.GetLength(0); ++row)
            {
                for (int col = 0; col < puzzle.GetLength(1); col++) //there probably is a way to do this shorter + fix the color scheme to match intro
                {
                    if (col == 0)
                    {
                        Console.Write("|  ");
                    }

                    if (puzzle[row, col] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write($"{puzzle[row, col]}  ");

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"{puzzle[row, col]}  ");

                    }

                    if ((col + 1) % 3 == 0)
                    {
                        Console.ResetColor();
                        Console.Write("|  ");
                        continue;
                    }


                    Console.ResetColor();
                }
                Console.WriteLine();
                if ((row + 1) % 3 == 0)

                {
                    Console.WriteLine("+-----------+-----------+-----------+");
                    continue;
                }

            }

        }
        private static bool GameFinished(int[,] puzzle, int[,] solution) //kind of works but probably needs edits
        {
            for (int i = 0; i < puzzle.GetLength(0); i++)
            {
                for (int j = 0; j < puzzle.GetLength(1); j++)
                {
                    if (puzzle[i, j] == solution[i, j])
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("It's not over yet!");
                        return false;
                    }
                }
            }
            Console.WriteLine("You've won");
            return true;
        }
    }
}
