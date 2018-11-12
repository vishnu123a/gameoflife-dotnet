using System;

namespace GameOfLifeDotNet.App
{
    using GameOfLife;

    class Program
    {
        static void Main(string[] args)
        {
            var seed = new[,]
            {
                {0, 0, 1, 0, 0, 0 }, 
                {1, 0, 0, 1, 0, 0 }, 
                {1, 0, 0, 1, 0, 0 }, 
                {0, 1, 0, 0, 0, 0 }, 
                {0, 0, 0, 0, 0, 0 }, 
                {0, 0, 0, 0, 0, 0 }
            };
            var universe = new Universe(seed);

            bool nextTick = true;
            int currentGeneration = 0;
            while (nextTick)
            {
                Console.WriteLine($"Current generation: {currentGeneration}");

                for (int rowIndex = 0; rowIndex < universe.Cells.GetLength(0); rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < universe.Cells.GetLength(1); columnIndex++)
                        Console.Write(universe.Cells[rowIndex, columnIndex] == 1 ? "* " : ". ");

                    Console.WriteLine();
                } 

                Console.Write("Continue? (y/n): ");
                nextTick = Console.ReadKey().KeyChar == 'y';

                Console.Clear();
                universe.Tick();
                currentGeneration++;
            }
        }
    }
}
