using System;

namespace Sudoku_1
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int i = 0; i <3; i++)
            {
                PrintSudokuHorizontal();
                System.Threading.Thread.Sleep(400);
                Console.Clear();
                PrintSudoku();
                System.Threading.Thread.Sleep(400);
                Console.Clear();
            }
            InfoAboutGame(); 
            Console.WriteLine();
            Console.WriteLine("Press Enter to start a new game!");
            Console.ReadKey(); //here Enter would leave to a place where we choose level/see grid/see keys
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



        }

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

        }

        static void InfoAboutGame()
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.SetCursorPosition(25, 2);
            Console.WriteLine("GAME  'SUDOKU'");
            Console.SetCursorPosition(5, 4);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
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

        }

    }

}
