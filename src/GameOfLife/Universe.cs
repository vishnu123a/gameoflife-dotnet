namespace GameOfLife
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Universe
    {
        private readonly int height;
        private readonly int width;

        public Universe(int[,] seed)
        {
            Cells = seed;
            height = Cells.GetLength(0);
            width = Cells.GetLength(1);
        }

        public int[,] Cells { get; private set; }

        public void Tick()
        {
            var nextGeneration = new int[height, width];

            for (int rowIndex = 0; rowIndex < height; rowIndex++)
            for (int columnIndex = 0; columnIndex < width; columnIndex++)
                nextGeneration[rowIndex, columnIndex] = GetNextGenerationCellState(rowIndex, columnIndex);

            Cells = nextGeneration;
        }

        private int GetNextGenerationCellState(int rowIndex, int columnIndex) => CellLivesInNextGeneration(rowIndex, columnIndex) ? 1 : 0;

        private bool CellLivesInNextGeneration(int rowIndex, int columnIndex)
        {
            bool isAlive = IsCellAlive(rowIndex, columnIndex);
            int liveNeighbours = GetLiveNeighbours(rowIndex, columnIndex);

            return (isAlive && liveNeighbours == 2) || liveNeighbours == 3;
        }

        private bool IsCellAlive(int rowIndex, int columnIndex) => Cells[rowIndex, columnIndex] == 1;

        private int GetLiveNeighbours(int rowIndex, int columnIndex)
        {
            var neighbours = GetNeighbours(rowIndex, columnIndex);

            return neighbours.Sum();
        }

        private IEnumerable<int> GetNeighbours(int rowIndex, int columnIndex)
        {
            var neighbours = new List<int>();
            if (rowIndex > 0)
            {
                if (columnIndex > 0)
                    neighbours.Add(Cells[rowIndex - 1, columnIndex - 1]);
                neighbours.Add(Cells[rowIndex - 1, columnIndex]);
                if (columnIndex < width - 1)
                    neighbours.Add(Cells[rowIndex - 1, columnIndex + 1]);
            }

            if (columnIndex > 0)
                neighbours.Add(Cells[rowIndex, columnIndex - 1]);

            if (columnIndex < width - 1)
                neighbours.Add(Cells[rowIndex, columnIndex + 1]);

            if (rowIndex < height - 1)
            {
                if (columnIndex > 0)
                    neighbours.Add(Cells[rowIndex + 1, columnIndex - 1]);
                neighbours.Add(Cells[rowIndex + 1, columnIndex]);
                if (columnIndex < width - 1)
                    neighbours.Add(Cells[rowIndex + 1, columnIndex + 1]);
            }

            return neighbours;
        }
    }
}
