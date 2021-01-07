namespace FinalProjectSudoku
{
    public class Players
    {
        public string Name { get; set; }
        public int TimeElapsed { get; set; } //data type depends on the timer
        public string Place { get; set; }
        public bool didPlayerWin { get; set; }
    }
}