using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Game
    {
        public Grid CurrentGrid { get; }
        private readonly DeadEvolutionRules DeadEvolutionRules;
        private readonly LiveEvolutionRules LiveEvolutionRules;


        public Game(Grid currentGrid)
        {
            CurrentGrid = currentGrid;
            DeadEvolutionRules = new DeadEvolutionRules();
            LiveEvolutionRules = new LiveEvolutionRules();
        }

        public void SetInitialStateOfGrid(List<Cell> livingCells)
        {
            livingCells.ForEach(cell => CurrentGrid.AddCell(cell));
        }

        public void Evolve()
        {
            IterateGrid();
        }

        private void IterateGrid()
        {
            var livingCells = CurrentGrid.GetLivingCells().ToList();
            var copyOfGrid = CurrentGrid;
            foreach (var cell in livingCells)
            {
                var numberOfNeighboursOfCell = CurrentGrid.GetNumberOfNeighboursOfCell( cell);

                if (LiveEvolutionRules.CellLives(livingCells, cell, numberOfNeighboursOfCell))
                {
                    CurrentGrid.AddCell(cell);
                }

                if (DeadEvolutionRules.CellDies(livingCells, cell, numberOfNeighboursOfCell))
                {
                    CurrentGrid.RemoveCell(cell);
                }
            }
        }
    }
}