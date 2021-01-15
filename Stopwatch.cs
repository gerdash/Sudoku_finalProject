using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectSudoku
{
    public class Stopwatch
    {
        public DateTime _start;
        public DateTime _stop;
        public Random _rand;
        public bool _isRunning;

        public Stopwatch()
        {
            _start = new DateTime();
            _stop = new DateTime();
            _rand = new Random();
            _isRunning = false;
        }
        public void Start()
        {
            //handling exceptions with throw?? 

            _start = DateTime.Now;
            _isRunning = true; //while !gameFinished this timer is on
            Console.WriteLine($"Game started: {_start.Hour} : {_start.Minute} : {_start.Second} "); //could do player name here? Or maybe above the timer when it shows at the end of the game?
        }
        public void Stop()
        {
            System.Threading.Thread.Sleep(_rand.Next(2000, 8000)); //this has to be game length instead of a random time!

            _stop = DateTime.Now;
            _isRunning = false;
            Console.WriteLine($"Game ended: {_stop.Hour} : {_stop.Minute} : {_stop.Second} ");
            TimeSpan duration = _stop - _start;
            Duration(duration);
        }
        public void Duration(TimeSpan duration)
        {
            Console.WriteLine($"Puzzle was finished in {duration.Minutes} min {duration.Seconds} sec");
        }
    }
}
