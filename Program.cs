using System;

namespace inspo_maze
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.SetWindowSize(90, 40);
            Game myGame = new Game();
            myGame.Start();
            //#endregion
            //#region Stopwatch
            //var timer = new Stopwatch();
            //timer.Start();
            //timer.Stop();
            //#endregion
            //myGame.PrintGameBoard(myGame.Puzzle);

        }

        
        //static void readFromLeaderboard()
        //{
        //    string leaderboard = @"C:\Users\Sandra Aunina\source\repos\Sudoku_finalProject\Leaderboard.txt";
        //    string[] leaderboardlines = File.ReadAllLines(leaderboard);
        //    foreach (var item in leaderboardlines)
        //    {
        //        Console.WriteLine(item);
        //    }
        //    Console.WriteLine("Press 'M' to return to menu.");
        //    string backtomenu = Console.ReadLine();

        //    switch (backtomenu)
        //    {
                
        //        case "m":
        //            InfoAboutGame();
        //            break;
        //        case "M":
        //            InfoAboutGame();
        //            break;
        //    }
        //    System.Threading.Thread.Sleep(1000000);
        //}
        //static void addToLeaderboard() //not finished
        //{

        //    string leaderboard = @"C:\Users\Sandra Aunina\source\repos\Sudoku_finalProject\Leaderboard.txt";
        //    using (System.IO.StreamWriter file = new StreamWriter(leaderboard, true))
        //        file.WriteLine("Leaderboard");
            
        //    for (int i = 0; i < 50; i++)
        //    {
        //        //here would be something like file.write(i + playersname + time from timer). No idea how to make asc order by fastest time 
                
        //    }



        //}
    }
}
