namespace FinalProjectSudoku
{
    public class Players
    {
        public string Name { get; set; }
        public int TimeElapsed { get; set; } //data type depends on the timer
        public string Place { get; set; }
        public bool didPlayerWin { get; set; }

        public Players(string name, int timeElapsed, string place, bool DidPlayerWin)
        {
            Name = name;
            TimeElapsed = timeElapsed;
            Place = place;
            didPlayerWin = DidPlayerWin;
        }
        
    }
}