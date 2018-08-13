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
            foreach (var i in CurrentGrid.GetLivingCells().ToList())
            {
                var livingCells = CurrentGrid.GetLivingCells();
                var numberOfNeighboursOfCell = CurrentGrid.GetNumberOfNeighboursOfCell(i);
                
                if (LiveEvolutionRules.CellLives(livingCells, i, numberOfNeighboursOfCell))
                {
                    CurrentGrid.AddCell(i);
                }

                if (DeadEvolutionRules.CellDies(livingCells, i, numberOfNeighboursOfCell))
                {
                    CurrentGrid.RemoveCell(i);
                }
            }
        }
    }
}