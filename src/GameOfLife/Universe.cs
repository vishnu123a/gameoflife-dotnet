namespace GameOfLife
{
    public class Universe
    {
        public Universe(int[,] seed)
        {
            Cells = seed;
        }

        public int[,] Cells { get; }

        public void Tick()
        { }
    }
}
